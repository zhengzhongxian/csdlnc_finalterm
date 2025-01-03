using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly PM_App _context;
        private readonly IMapper _mapper;

        public ScheduleRepository(PM_App context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetSchedulesByExamIdAsync(string examId)
        {
            var schedules = await _context.Schedules
                .Where(s => s.ExamId == examId)
                .Include(s => s.Student)
                .Include(s => s.Exam)
                    .ThenInclude(e => e.ExamResults)
                        .ThenInclude(er => er.Lecturer)
                            .ThenInclude(l => l.LecturerNavigation) 
                .ToListAsync();

            return _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        }

        public async Task CreateScheduleAsync(ScheduleCreateUpdateDTO scheduleDto)
        {
            var exam = await _context.Exams.Include(e => e.Room).FirstOrDefaultAsync(e => e.ExamId == scheduleDto.ExamId);
            if (exam == null) throw new Exception("Không tìm thấy kỳ thi.");

            var isEnrolled = await IsStudentEnrolledInSubject(scheduleDto.StudentId, exam.SubjectId);
            if (!isEnrolled) throw new Exception("Sinh viên không học môn này.");

            var isSeatOccupied = await IsSeatOccupiedAsync(scheduleDto.ExamId, scheduleDto.SeatNumber);
            if (isSeatOccupied) throw new Exception("Ghế đã được chọn.");

            var schedule = _mapper.Map<Schedule>(scheduleDto);
            schedule.ScheduleId = Guid.NewGuid().ToString();
            schedule.Status = 1;
            await _context.Schedules.AddAsync(schedule);
            await UpdateVacantSeatAsync(exam.ExamId, false);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(string scheduleId, int seatNumber)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null) throw new Exception("Không tìm thấy lịch thi.");

            var isSeatOccupied = await IsSeatOccupiedAsync(schedule.ExamId, seatNumber);
            if (isSeatOccupied) throw new Exception("Ghế đã được chọn.");

            schedule.SeatNumber = seatNumber;
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(string examId, string studentId)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(s => s.ExamId == examId && s.StudentId == studentId);
            if (schedule == null) throw new Exception("Không tìm thấy lịch thi.");

            var exam = await _context.Exams.Include(e => e.Room).FirstOrDefaultAsync(e => e.ExamId == examId);

            _context.Schedules.Remove(schedule);
            await UpdateVacantSeatAsync(exam.ExamId, true); // Tăng sức chứa của phòng
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsStudentEnrolledInSubject(string studentId, string subjectId)
        {
            return await _context.ClassStudents
                .Include(cs => cs.Class)
                .AnyAsync(cs => cs.StudentId == studentId && cs.Class.IdLectuerSubjectNavigation.SubjectId == subjectId);
        }

        public async Task<IEnumerable<int>> GetOccupiedSeatsAsync(string examId)
        {
            var occupiedSeats = await _context.Schedules
                .Where(s => s.ExamId == examId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<int>>(occupiedSeats.Select(s => s.SeatNumber ?? 0)); 
        }

        public async Task<bool> IsSeatOccupiedAsync(string examId, int seatNumber)
        {
            return await _context.Schedules
                .AnyAsync(s => s.ExamId == examId && s.SeatNumber == seatNumber);
        }

        public async Task UpdateVacantSeatAsync(string examId, bool increase)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam == null) throw new Exception("Không tìm thấy kỳ thi.");

            if (exam.VacantSeat == null)
                throw new Exception("Số ghế trống không được xác định.");

            exam.VacantSeat = increase ? exam.VacantSeat + 1 : exam.VacantSeat - 1;

            if (exam.VacantSeat < 0)
                throw new Exception("Số ghế trống không thể âm.");

            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OtherStudentDTO>> GetStudentsNotInScheduleAsync(string examId)
        {
            var exam = await _context.Exams
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(e => e.ExamId == examId);

            if (exam == null)
                throw new Exception("Không tìm thấy kỳ thi.");

            var enrolledStudents = await _context.ClassStudents
                .Include(cs => cs.Student)
                .Where(cs => cs.Class.IdLectuerSubjectNavigation.SubjectId == exam.SubjectId)
                .Select(cs => cs.Student)
                .ToListAsync();

            var studentsInCurrentSchedule = await _context.Schedules
                .Where(s => s.ExamId == examId)
                .Select(s => s.StudentId)
                .ToListAsync();

            var studentsInOtherSchedulesForSameSubject = await _context.Schedules
                .Where(s => s.ExamId != examId && s.Exam.SubjectId == exam.SubjectId)
                .Select(s => s.StudentId)
                .ToListAsync();

            var studentsNotInSchedule = enrolledStudents
                .Where(s =>
                    !studentsInCurrentSchedule.Contains(s.StudentId) &&
                    !studentsInOtherSchedulesForSameSubject.Contains(s.StudentId))
                .ToList();

            // Map kết quả sang DTO
            return _mapper.Map<IEnumerable<OtherStudentDTO>>(studentsNotInSchedule);
        }

        public async Task<int> GetRoomCapacityAsync(string examId)
        {
            var exam = await _context.Exams
                .Include(e => e.Room)
                .FirstOrDefaultAsync(e => e.ExamId == examId);

            return exam?.Room.Capacity ?? 0;
        }

        public async Task<IEnumerable<int>> GetAvailableSeatsAsync(string examId)
        {

            int capacity = await GetRoomCapacityAsync(examId);

            var occupiedSeats = await GetOccupiedSeatsAsync(examId);

            var availableSeats = Enumerable.Range(1, capacity).Except(occupiedSeats);

            return availableSeats;
        }

        public async Task UpdateScheduleStatusToTwoAsync(string scheduleId)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null) throw new Exception("Không tìm thấy lịch thi.");

            schedule.Status = 2;
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
    }
}
