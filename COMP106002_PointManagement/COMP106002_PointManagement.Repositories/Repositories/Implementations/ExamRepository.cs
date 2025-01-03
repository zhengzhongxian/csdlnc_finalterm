using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class ExamRepository : IExamRepository
    {
        private readonly PM_App _context;

        public ExamRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync(int location_id)
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.Room) 
                .Include(e => e.Invigilator)
                    .ThenInclude(l => l.LecturerNavigation)
                .Where(e => e.LocationId == location_id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Exam>> GetTotalExamsAsync()
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.Room)
                .Include(e => e.Invigilator)
                    .ThenInclude(l => l.LecturerNavigation)
                .ToListAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(string id)
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.Room)
                .Include(e => e.Invigilator)
                    .ThenInclude(l => l.LecturerNavigation)
                .FirstOrDefaultAsync(e => e.ExamId == id);
        }

        public async Task CreateExamAsync(Exam exam)
        {
            exam.VacantSeat = _context.Rooms.FirstOrDefault(r => r.RoomId == exam.RoomId)?.Capacity ?? 0;
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExamAsync(string id)
        {
            var exam = await GetExamByIdAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsRoomAvailable(string roomId, DateOnly? examDate, TimeOnly timeSlot, int? duration, string excludeExamId = null)
        {
            if (!examDate.HasValue) return false;

            var examStartTime = examDate.Value.ToDateTime(timeSlot);
            var examEndTime = examStartTime.AddMinutes(duration.GetValueOrDefault() + 15); // 15 phút nghỉ

            var examsInRoom = await _context.Exams
                .Where(e => e.RoomId == roomId && (excludeExamId == null || e.ExamId != excludeExamId))
                .ToListAsync();

            foreach (var exam in examsInRoom)
            {
                var existingExamStartTime = exam.ExamDate?.ToDateTime(exam.TimeSlot.GetValueOrDefault()) ?? DateTime.MinValue;
                var existingExamEndTime = existingExamStartTime.AddMinutes(exam.Duration.GetValueOrDefault() + 15);

                // Kiểm tra nếu thời gian bắt đầu hoặc kết thúc của kỳ thi mới nằm trong khoảng thời gian của kỳ thi cũ và ngược lại
                if (examStartTime < existingExamEndTime && examEndTime > existingExamStartTime)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly examDate, TimeOnly timeSlot, int duration, int location_id, string excludeExamId = null)
        {
            var startTime = new DateTime(examDate.Year, examDate.Month, examDate.Day, timeSlot.Hour, timeSlot.Minute, timeSlot.Second);
            var endTime = startTime.AddMinutes(duration).AddMinutes(15);

            var roomsWithConflicts = await _context.Exams
                .Where(e => e.ExamDate == examDate && e.LocationId == location_id &&
                            (excludeExamId == null || e.ExamId != excludeExamId) &&
                            ((e.TimeSlot <= timeSlot && e.TimeSlot.Value.AddMinutes(e.Duration.GetValueOrDefault() + 15) > timeSlot) ||
                             (e.TimeSlot < TimeOnly.FromDateTime(endTime) && e.TimeSlot.Value.AddMinutes(e.Duration.GetValueOrDefault() + 15) >= TimeOnly.FromDateTime(endTime)) ||
                             (e.TimeSlot >= timeSlot && e.TimeSlot <= TimeOnly.FromDateTime(endTime))))
                .Select(e => e.RoomId)
                .Distinct()
                .ToListAsync();

            var availableRooms = await _context.Rooms
                .Where(r => !roomsWithConflicts.Contains(r.RoomId) && r.LocationId == location_id)
                .ToListAsync();

            return availableRooms;
        }

        public async Task<bool> IsLecturerAvailableAsync(string lecturerId, DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null)
        {
            var examStartTime = examDate.ToDateTime(timeSlot);
            var examEndTime = examStartTime.AddMinutes(duration + 15);

            var classConflict = await _context.Classes
                .Where(c => c.IdLectuerSubjectNavigation.LecturerId == lecturerId && c.StartDate <= examDate && c.EndDate >= examDate)
                .Join(_context.Timetables,
                      c => c.ClassId,
                      t => t.ClassId,
                      (c, t) => new { t.DayOfWeek, t.StartTime, t.EndTime })
                .AnyAsync(t => t.DayOfWeek == examDate.DayOfWeek.ToString() &&
                               ((t.StartTime <= timeSlot && t.EndTime > timeSlot) ||
                                (t.StartTime < TimeOnly.FromDateTime(examEndTime) && t.EndTime >= TimeOnly.FromDateTime(examEndTime))));

            return !classConflict;
        }

        public async Task<IEnumerable<Lecturer>> GetAvailableLecturersAsync(DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null)
        {
            var examStartTime = new DateTime(examDate.Year, examDate.Month, examDate.Day, timeSlot.Hour, timeSlot.Minute, timeSlot.Second);
            var examEndTime = examStartTime.AddMinutes(duration);

            var busyLecturers = await _context.Classes
                .Where(c => c.StartDate <= examDate && c.EndDate >= examDate)
                .Join(_context.Timetables,
                      c => c.ClassId,
                      t => t.ClassId,
                      (c, t) => new { c.IdLectuerSubjectNavigation.LecturerId, t.DayOfWeek, t.StartTime, t.EndTime })
                .Where(t => t.DayOfWeek == examDate.DayOfWeek.ToString() &&
                            ((t.StartTime <= timeSlot && (t.EndTime.HasValue && t.EndTime.Value.AddMinutes(20) > timeSlot)) ||
                             (t.StartTime < TimeOnly.FromDateTime(examEndTime.AddMinutes(20)) && (t.EndTime.HasValue && t.EndTime.Value >= TimeOnly.FromDateTime(examEndTime)))))
                .Select(t => t.LecturerId)
                .Distinct()
                .ToListAsync();

            var busyInvigilators = await _context.Exams
                .Where(e => e.ExamDate == examDate &&
                            (excludeExamId == null || e.ExamId != excludeExamId) &&
                            ((e.TimeSlot <= timeSlot && e.TimeSlot.Value.AddMinutes(e.Duration.GetValueOrDefault() + 20) > timeSlot) ||
                             (e.TimeSlot < TimeOnly.FromDateTime(examEndTime.AddMinutes(20)) && e.TimeSlot.Value.AddMinutes(e.Duration.GetValueOrDefault()) >= TimeOnly.FromDateTime(examEndTime))))
                .Select(e => e.InvigilatorId)
                .Distinct()
                .ToListAsync();

            busyLecturers.AddRange(busyInvigilators);
            var distinctBusyLecturers = busyLecturers.Distinct();

            return await _context.Lecturers
                .Include(l => l.LecturerNavigation)
                .Where(l => !distinctBusyLecturers.Contains(l.LecturerId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetExamsByFacultyIdAsync(string facultyId, int location_id)
        {
            return await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.Room)
                .Include(e => e.Invigilator)
                    .ThenInclude(l => l.LecturerNavigation)
                .Where(e => e.Subject != null && e.Subject.FacultyId == facultyId && e.LocationId == location_id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lecturer>> GetLecturersByExamIdAsync(string examId)
        {

            var exam = await _context.Exams
                    .Include(e => e.Subject)
                    .FirstOrDefaultAsync(e => e.ExamId == examId);

            if (exam?.Subject == null)
                return Enumerable.Empty<Lecturer>();

            return await _context.LecturerSubjects
                .Include(ls => ls.Lecturer)
                    .ThenInclude(l => l.LecturerNavigation) 
                .Where(ls => ls.SubjectId == exam.SubjectId)
                .Select(ls => ls.Lecturer)
                .ToListAsync();
        }
    }
}
