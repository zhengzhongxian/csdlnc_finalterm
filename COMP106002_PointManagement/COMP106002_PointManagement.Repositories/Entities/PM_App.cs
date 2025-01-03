using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace COMP106002_PointManagement.API;

public partial class PM_App : DbContext
{
    public PM_App()
    {
    }

    public PM_App(DbContextOptions<PM_App> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassStudent> ClassStudents { get; set; }

    public virtual DbSet<EducationSystem> EducationSystems { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<LecturerSubject> LecturerSubjects { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    public virtual DbSet<Typescore> Typescores { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.IdAcademicYear).HasName("PK__academic__DCDBA805B871585E");

            entity.ToTable("academic_year");

            entity.Property(e => e.IdAcademicYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_academic_year");
            entity.Property(e => e.YearAcademicYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("year_academic_year");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__FDF47986126DA13E");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.AuditableId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("auditable_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(100)
                .HasColumnName("class_name");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IdEs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_es");
            entity.Property(e => e.IdLectuerSubject)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_lectuer_subject");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.IdEsNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdEs)
                .HasConstraintName("FK_Classes_education_system");

            entity.HasOne(d => d.IdLectuerSubjectNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdLectuerSubject)
                .HasConstraintName("FK_Classes_Lecturer_Subject");

            entity.HasOne(d => d.Location).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Classes_location");
        });

        modelBuilder.Entity<ClassStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class_St__3213E83FA0E0213A");

            entity.ToTable("Class_Student");

            entity.HasIndex(e => new { e.ClassId, e.StudentId }, "UQ__Class_St__4F5749EEA8348185").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("score");
            entity.Property(e => e.StudentId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("student_id");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassStudents)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Class_Student_Classes");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Class_Student_Students");
        });

        modelBuilder.Entity<EducationSystem>(entity =>
        {
            entity.HasKey(e => e.IdEs).HasName("PK__educatio__00B7CEA9C6387FC4");

            entity.ToTable("education_system");

            entity.Property(e => e.IdEs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_es");
            entity.Property(e => e.NameEs)
                .HasMaxLength(100)
                .HasColumnName("name_es");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__9C8C7BE9E5E732C8");

            entity.Property(e => e.ExamId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exam_id");
            entity.Property(e => e.AuditableId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("auditable_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ExamDate).HasColumnName("exam_date");
            entity.Property(e => e.ExamType)
                .HasMaxLength(50)
                .HasColumnName("exam_type");
            entity.Property(e => e.InvigilatorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("invigilator_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subject_id");
            entity.Property(e => e.TimeSlot).HasColumnName("time_slot");
            entity.Property(e => e.VacantSeat).HasColumnName("vacant_seat");

            entity.HasOne(d => d.Invigilator).WithMany(p => p.Exams)
                .HasForeignKey(d => d.InvigilatorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Exams_Lecturers");

            entity.HasOne(d => d.Location).WithMany(p => p.Exams)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Exams_location");

            entity.HasOne(d => d.Room).WithMany(p => p.Exams)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Exams_Rooms");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Exams__subject_i__5165187F");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Exam_Res__AFB3C3162D73720F");

            entity.ToTable("Exam_Results");

            entity.HasIndex(e => new { e.LecturerId, e.ExamId, e.StudentId }, "UQ_Exam_Results").IsUnique();

            entity.Property(e => e.ResultId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("result_id");
            entity.Property(e => e.ExamId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exam_id");
            entity.Property(e => e.LecturerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lecturer_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("score");
            entity.Property(e => e.StudentId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("student_id");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Exam_Results_Exams");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("FK_Exam_Results_Lecturers");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Exam_Results_Students");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__Facultie__7B00413CEF8B8B6A");

            entity.Property(e => e.FacultyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("faculty_id");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(100)
                .HasColumnName("faculty_name");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.LecturerId).HasName("PK__Lecturer__D4D1DAB15F007E35");

            entity.Property(e => e.LecturerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lecturer_id");
            entity.Property(e => e.Degree)
                .HasMaxLength(100)
                .HasColumnName("degree");
            entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");

            entity.HasOne(d => d.LecturerNavigation).WithOne(p => p.Lecturer)
                .HasForeignKey<Lecturer>(d => d.LecturerId)
                .HasConstraintName("FK_Lecturers_Users");
        });

        modelBuilder.Entity<LecturerSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturer__3213E83F20DEFB11");

            entity.ToTable("Lecturer_Subject");

            entity.HasIndex(e => new { e.LecturerId, e.SubjectId }, "UQ__Lecturer__C1D195D699F4B1E8").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.LecturerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lecturer_id");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subject_id");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.LecturerSubjects)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("FK_Lecturer_Subject_Lecturers1");

            entity.HasOne(d => d.Subject).WithMany(p => p.LecturerSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Lecturer_Subject_Subjects");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("location");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .HasColumnName("location_name");
            entity.Property(e => e.MongoDbName)
                .HasMaxLength(50)
                .HasColumnName("mongoDb_name");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__19675A8AFE2A5DDF");

            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.RoomName)
                .HasMaxLength(100)
                .HasColumnName("room_name");

            entity.HasOne(d => d.Location).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Rooms_location");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__C46A8A6F44E8B2BD");

            entity.Property(e => e.ScheduleId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("schedule_id");
            entity.Property(e => e.ExamId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exam_id");
            entity.Property(e => e.SeatNumber).HasColumnName("seat_number");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StudentId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("student_id");

            entity.HasOne(d => d.Exam).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Schedules__exam___5FB337D6");

            entity.HasOne(d => d.Student).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Schedules_Students");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.ToTable("semester");

            entity.Property(e => e.SemesterId)
                .ValueGeneratedNever()
                .HasColumnName("semester_id");
            entity.Property(e => e.SemesterName)
                .HasMaxLength(50)
                .HasColumnName("semester_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069A5228691C");

            entity.Property(e => e.StudentId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AuditableId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("auditable_id");
            entity.Property(e => e.Dayofbirth).HasColumnName("dayofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FacultyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("faculty_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.IdAcademicYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_academic_year");
            entity.Property(e => e.IdEs)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_es");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .HasColumnName("photo");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .HasColumnName("student_name");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Students)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK_Students_Faculties");

            entity.HasOne(d => d.IdAcademicYearNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdAcademicYear)
                .HasConstraintName("FK_Students_academic_year");

            entity.HasOne(d => d.IdEsNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdEs)
                .HasConstraintName("FK_Students_education_system");

            entity.HasOne(d => d.Location).WithMany(p => p.Students)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Students_location");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__5004F660AE14DCFC");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subject_id");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.FacultyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("faculty_id");
            entity.Property(e => e.SemesterId).HasColumnName("semester_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .HasColumnName("subject_name");
            entity.Property(e => e.TypescoreId).HasColumnName("typescore_id");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Subjects_Faculties");

            entity.HasOne(d => d.Semester).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_Subjects_semester");

            entity.HasOne(d => d.Typescore).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TypescoreId)
                .HasConstraintName("FK_Subjects_typescore");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.ToTable("Timetable");

            entity.Property(e => e.TimetableId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("timetable_id");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Timetable_Classes");

            entity.HasOne(d => d.Room).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Timetable_Rooms1");
        });

        modelBuilder.Entity<Typescore>(entity =>
        {
            entity.HasKey(e => e.TypesocreId);

            entity.ToTable("typescore");

            entity.Property(e => e.TypesocreId)
                .ValueGeneratedNever()
                .HasColumnName("typesocre_id");
            entity.Property(e => e.EndScore).HasColumnName("end_score");
            entity.Property(e => e.ProcessScore).HasColumnName("process_score");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F189C13A9");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616495CBF389").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572F86B246B").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.LastAccessed)
                .HasColumnType("datetime")
                .HasColumnName("last_accessed");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.Location).WithMany(p => p.Users)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Users_location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
