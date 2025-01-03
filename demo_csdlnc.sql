USE [master]
GO
/****** Object:  Database [csdlnc]    Script Date: 1/3/2025 10:31:01 PM ******/
CREATE DATABASE [csdlnc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'csdlnc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ZHENG\MSSQL\DATA\csdlnc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'csdlnc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ZHENG\MSSQL\DATA\csdlnc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [csdlnc] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [csdlnc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [csdlnc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [csdlnc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [csdlnc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [csdlnc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [csdlnc] SET ARITHABORT OFF 
GO
ALTER DATABASE [csdlnc] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [csdlnc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [csdlnc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [csdlnc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [csdlnc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [csdlnc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [csdlnc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [csdlnc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [csdlnc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [csdlnc] SET  ENABLE_BROKER 
GO
ALTER DATABASE [csdlnc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [csdlnc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [csdlnc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [csdlnc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [csdlnc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [csdlnc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [csdlnc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [csdlnc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [csdlnc] SET  MULTI_USER 
GO
ALTER DATABASE [csdlnc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [csdlnc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [csdlnc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [csdlnc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [csdlnc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [csdlnc] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [csdlnc] SET QUERY_STORE = ON
GO
ALTER DATABASE [csdlnc] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [csdlnc]
GO
/****** Object:  Table [dbo].[academic_year]    Script Date: 1/3/2025 10:31:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[academic_year](
	[id_academic_year] [varchar](10) NOT NULL,
	[year_academic_year] [varchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_academic_year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Student]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Student](
	[id] [char](36) NOT NULL,
	[class_id] [varchar](50) NULL,
	[student_id] [varchar](36) NULL,
	[score] [decimal](5, 2) NULL,
 CONSTRAINT [PK__Class_St__3213E83FA0E0213A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[class_id] [varchar](50) NOT NULL,
	[class_name] [nvarchar](100) NULL,
	[quantity] [int] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[id_es] [char](2) NULL,
	[id_lectuer_subject] [char](36) NULL,
	[location_id] [int] NULL,
	[auditable_id] [char](36) NULL,
 CONSTRAINT [PK__Classes__FDF47986126DA13E] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[education_system]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[education_system](
	[id_es] [char](2) NOT NULL,
	[name_es] [nvarchar](100) NULL,
 CONSTRAINT [PK__educatio__00B7CEA9C6387FC4] PRIMARY KEY CLUSTERED 
(
	[id_es] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Results]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Results](
	[result_id] [char](36) NOT NULL,
	[score] [decimal](5, 2) NULL,
	[lecturer_id] [char](36) NULL,
	[exam_id] [char](36) NULL,
	[student_id] [varchar](36) NULL,
 CONSTRAINT [PK__Exam_Res__AFB3C3162D73720F] PRIMARY KEY CLUSTERED 
(
	[result_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[exam_id] [char](36) NOT NULL,
	[subject_id] [char](36) NULL,
	[exam_type] [nvarchar](50) NULL,
	[exam_date] [date] NULL,
	[time_slot] [time](7) NULL,
	[duration] [int] NULL,
	[invigilator_id] [char](36) NULL,
	[vacant_seat] [int] NULL,
	[room_id] [varchar](50) NULL,
	[auditable_id] [char](36) NULL,
	[location_id] [int] NULL,
 CONSTRAINT [PK__Exams__9C8C7BE9E5E732C8] PRIMARY KEY CLUSTERED 
(
	[exam_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[faculty_id] [char](3) NOT NULL,
	[faculty_name] [nvarchar](100) NULL,
 CONSTRAINT [PK__Facultie__7B00413CEF8B8B6A] PRIMARY KEY CLUSTERED 
(
	[faculty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturer_Subject]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturer_Subject](
	[id] [char](36) NOT NULL,
	[lecturer_id] [char](36) NULL,
	[subject_id] [char](36) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturers]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturers](
	[lecturer_id] [char](36) NOT NULL,
	[degree] [nvarchar](100) NULL,
	[years_of_experience] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[lecturer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[location]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[location_id] [int] NOT NULL,
	[location_name] [nvarchar](100) NULL,
	[address] [nvarchar](max) NULL,
	[mongoDb_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[room_id] [varchar](50) NOT NULL,
	[room_name] [nvarchar](100) NULL,
	[capacity] [int] NULL,
	[location_id] [int] NULL,
 CONSTRAINT [PK__Rooms__19675A8AFE2A5DDF] PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[schedule_id] [char](36) NOT NULL,
	[exam_id] [char](36) NULL,
	[student_id] [varchar](36) NULL,
	[seat_number] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK__Schedule__C46A8A6F44E8B2BD] PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[semester]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[semester](
	[semester_id] [int] NOT NULL,
	[semester_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_semester] PRIMARY KEY CLUSTERED 
(
	[semester_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[student_id] [varchar](36) NOT NULL,
	[student_name] [nvarchar](100) NULL,
	[photo] [nvarchar](100) NULL,
	[gender] [nvarchar](10) NULL,
	[dayofbirth] [date] NULL,
	[email] [varchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[phone_number] [varchar](15) NULL,
	[id_es] [char](2) NULL,
	[id_academic_year] [varchar](10) NULL,
	[faculty_id] [char](3) NULL,
	[location_id] [int] NULL,
	[auditable_id] [char](36) NULL,
 CONSTRAINT [PK__Students__2A33069A5228691C] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[subject_id] [char](36) NOT NULL,
	[subject_name] [nvarchar](100) NULL,
	[credits] [int] NULL,
	[faculty_id] [char](3) NULL,
	[typescore_id] [int] NULL,
	[semester_id] [int] NULL,
 CONSTRAINT [PK__Subjects__5004F660AE14DCFC] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timetable]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timetable](
	[timetable_id] [char](36) NOT NULL,
	[class_id] [varchar](50) NULL,
	[day_of_week] [varchar](10) NULL,
	[start_time] [time](7) NULL,
	[end_time] [time](7) NULL,
	[room_id] [varchar](50) NULL,
 CONSTRAINT [PK_Timetable] PRIMARY KEY CLUSTERED 
(
	[timetable_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[typescore]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typescore](
	[typesocre_id] [int] NOT NULL,
	[process_score] [int] NULL,
	[end_score] [int] NULL,
 CONSTRAINT [PK_typescore] PRIMARY KEY CLUSTERED 
(
	[typesocre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/3/2025 10:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [char](36) NOT NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](255) NULL,
	[role] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[dob] [date] NULL,
	[gender] [nvarchar](10) NULL,
	[address] [nvarchar](255) NULL,
	[photo] [varbinary](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[last_accessed] [datetime] NULL,
	[phone_number] [varchar](15) NULL,
	[location_id] [int] NULL,
 CONSTRAINT [PK__Users__B9BE370F189C13A9] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[academic_year] ([id_academic_year], [year_academic_year]) VALUES (N'K48', N'2022')
GO
INSERT [dbo].[education_system] ([id_es], [name_es]) VALUES (N'01', N'Chính Quy')
GO
INSERT [dbo].[Faculties] ([faculty_id], [faculty_name]) VALUES (N'104', N'Công Nghệ Thông Tin')
GO
INSERT [dbo].[Lecturer_Subject] ([id], [lecturer_id], [subject_id]) VALUES (N'3407a928-1306-4e44-9e5c-acfdbcb14e5f', N'c7523c42-6405-46ed-bdef-cd196f2a5942', N'df974a54-433f-45c6-966a-84a4a04969c5')
GO
INSERT [dbo].[Lecturers] ([lecturer_id], [degree], [years_of_experience]) VALUES (N'c7523c42-6405-46ed-bdef-cd196f2a5942', N'Thạc sĩ', 8)
GO
INSERT [dbo].[location] ([location_id], [location_name], [address], [mongoDb_name]) VALUES (1, N'Hà Nội', N'Hồ Gươm', N'db_hanoi')
INSERT [dbo].[location] ([location_id], [location_name], [address], [mongoDb_name]) VALUES (2, N'Thành phố Hồ Chí Minh', N'Quận 5', N'db_tphcm')
GO
INSERT [dbo].[Rooms] ([room_id], [room_name], [capacity], [location_id]) VALUES (N'E.104', N'E.104', 100, 2)
INSERT [dbo].[Rooms] ([room_id], [room_name], [capacity], [location_id]) VALUES (N'I.102', N'I.102', 40, 2)
INSERT [dbo].[Rooms] ([room_id], [room_name], [capacity], [location_id]) VALUES (N'I.202', N'I.202', 45, 1)
GO
INSERT [dbo].[semester] ([semester_id], [semester_name]) VALUES (1, N'Kỳ 1')
GO
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.001', N'Trịnh Trung Hiển', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735334554/1_K48_01_104_001.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'trunghien04@gmail.com', N'Bình Dương', N'01223153811', N'01', N'K48', N'104', 1, N'dd7f3f93-7c40-47ed-9ed9-b0eb422bf5da')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.002', N'Nguyễn Văn Long', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735334670/1_K48_01_104_002.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'121212', N'1212', N'1121212', N'01', N'K48', N'104', 1, N'eb7fa19d-54be-48d8-8b57-5783539b6fdc')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.003', N'Nguyễn Thế Mạnh', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735354224/1_K48_01_104_003.png', N'Nam', CAST(N'2024-10-20' AS Date), N'sdsdsd', N'ssdsd', N'12222312âsasas', N'01', N'K48', N'104', 1, N'3e9cc593-f6fc-486b-99f4-5859b00bc730')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.004', N'Lê Thanh Nhã', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735335039/1_K48_01_104_004.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'121sfb', N'dsd', N'1212scfd', N'01', N'K48', N'104', 1, N'c1660c15-5066-4a48-971f-bc8d2df12fa0')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.005', N'Trần Mộng Tuyền', NULL, N'Nam', CAST(N'2024-10-20' AS Date), N'1212c', N'112', N'1212cd', N'01', N'K48', N'104', 1, N'f7594e44-3591-4f09-9641-79235a094c8b')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.006', N'Nguyễn Lâm Khánh Chi', NULL, N'Nữ', CAST(N'2024-10-20' AS Date), N'sdsd', N'sdsd', N'dsdsdc', N'01', N'K48', N'104', 1, N'c13cf1aa-8f66-4aa3-9792-01682573388b')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.007', N'Tạ Trần Mỹ Linh', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735335617/1_K48_01_104_007.png', N'Nữ', CAST(N'2024-10-20' AS Date), N'âsas', N'âs', N'âsas', N'01', N'K48', N'104', 1, N'6d4ed0ae-1ad6-40da-981c-a73af479c8a0')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.008', N'Nguyễn Giao Bảo', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735335807/1_K48_01_104_008.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'uewewe', N'ưewe', N'uewew', N'01', N'K48', N'104', 1, N'67a8c61a-d990-4e70-8bc9-f86e2c4fa5a0')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.009', N'Trần Hạo Nam', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735336166/1_K48_01_104_009.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'queqwe', N'ưeqwewqe', N'uqeqwe', N'01', N'K48', N'104', 1, N'5cbca51c-c5d6-4c45-849f-807c3f785e6f')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.010', N'Nguyễn Xuân Son', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735337276/1_K48_01_104_010.png', N'Nữ', CAST(N'2024-10-20' AS Date), N'uqeqwe', N'qưewqe', N'uqeqwewqe', N'01', N'K48', N'104', 1, N'0c64813d-671a-46f9-976f-4641ec2dc430')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.011', N'Vương Thế Hùng', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735351981/1_K48_01_104_011.jpg', N'Nữ', CAST(N'2024-10-20' AS Date), N'121212fdfd', N'đsd', N'12121212', N'01', N'K48', N'104', 1, N'13c98ae9-b0c5-49e9-802c-4e70ecdee58f')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.012', N'Hồ Văn Cường', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735351945/1_K48_01_104_012.png', N'Nam', CAST(N'2024-10-20' AS Date), N'uewe', N'ewew', N'uewewe', N'01', N'K48', N'104', 1, N'6e00816e-9796-46ed-b1d6-22cec8e1e523')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.013', N'Vương Nhẹ Nhàng', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735352090/1_K48_01_104_013.jpg', N'Nữ', CAST(N'2024-10-20' AS Date), N'ádasdasdsd', N'sdasdsad', N'ádasdsd', N'01', N'K48', N'104', 1, N'2773a70b-7f94-47e4-8618-4c776c7b4c84')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.014', N'Ngô Gia Nữ', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735352127/1_K48_01_104_014.jpg', N'Nữ', CAST(N'2024-10-20' AS Date), N'ádasd', N'ádsad', N'ádad', N'01', N'K48', N'104', 1, N'2320380c-effd-4c5d-b20e-aa704e12129d')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.015', N'Trịnh Trung Hiển', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735356296/1_K48_01_104_015.png', N'Nữ', CAST(N'2024-10-20' AS Date), N'21212', N'121212', N'121212', N'01', N'K48', N'104', 1, NULL)
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.016', N'Nguyễn Mạnh', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735360880/1_K48_01_104_016.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'vanmanh@gmail.com', N'sdsđssd', N'21212141', N'01', N'K48', N'104', 1, N'469ba7a5-8655-490e-aa65-1b496cd6ba03')
INSERT [dbo].[Students] ([student_id], [student_name], [photo], [gender], [dayofbirth], [email], [address], [phone_number], [id_es], [id_academic_year], [faculty_id], [location_id], [auditable_id]) VALUES (N'1.K48.01.104.017', N'nguyen khanh hoa12', N'https://res.cloudinary.com/dvxnesld4/image/upload/v1735363061/1_K48_01_104_017.jpg', N'Nam', CAST(N'2024-10-20' AS Date), N'ghgh', N'hjhj', N'hjhjh', N'01', N'K48', N'104', 1, N'8f0b9162-240b-48c0-8431-db46bf4f0f07')
GO
INSERT [dbo].[Subjects] ([subject_id], [subject_name], [credits], [faculty_id], [typescore_id], [semester_id]) VALUES (N'df974a54-433f-45c6-966a-84a4a04969c5', N'Công nghệ thông tin', 4, N'104', 1, 1)
GO
INSERT [dbo].[typescore] ([typesocre_id], [process_score], [end_score]) VALUES (1, 40, 60)
GO
INSERT [dbo].[Users] ([user_id], [username], [password], [role], [email], [name], [dob], [gender], [address], [photo], [created_at], [updated_at], [last_accessed], [phone_number], [location_id]) VALUES (N'2b83c1f0-ae18-4ead-a573-13fbaa9e6b67', N'Trịnh Trung Hiển', N'$2a$11$PBJLyYVU6znqOQ2MKnXmBOwFrVw4mm//ouo/IeenRot9FDXm/rDOm', N'Admin', N'trunghien11@gmail.com', NULL, NULL, NULL, NULL, NULL, CAST(N'2024-12-25T19:23:28.277' AS DateTime), CAST(N'2024-12-25T19:23:28.447' AS DateTime), CAST(N'2024-12-26T18:57:46.837' AS DateTime), NULL, 2)
INSERT [dbo].[Users] ([user_id], [username], [password], [role], [email], [name], [dob], [gender], [address], [photo], [created_at], [updated_at], [last_accessed], [phone_number], [location_id]) VALUES (N'c7523c42-6405-46ed-bdef-cd196f2a5942', N'trunghien765@gmail.com', N'$2a$11$XMM.1dxGIu4lFKrj1UmyreeLHL6iHOVuXupilzJQA6iecIfySyGD.', N'lecturer', N'trunghien765@gmail.com', N'Nguyễn Kiến Phúc', CAST(N'2024-12-25' AS Date), N'Nam', N'BD', NULL, CAST(N'2024-12-25T06:04:08.030' AS DateTime), CAST(N'2024-12-25T13:04:08.073' AS DateTime), NULL, N'0775090884', NULL)
INSERT [dbo].[Users] ([user_id], [username], [password], [role], [email], [name], [dob], [gender], [address], [photo], [created_at], [updated_at], [last_accessed], [phone_number], [location_id]) VALUES (N'cc671700-cf83-444f-8b16-e13a120d8f4d', N'trunghien112', N'$2a$11$SclW56UOhe62J6MJr3w/o.2QQmWQ8CIrdIKYyoWIb8X8SIoZvxAbq', N'Admin', N'trunghienn765@gmail.com', NULL, NULL, NULL, NULL, NULL, CAST(N'2024-12-06T13:21:42.030' AS DateTime), CAST(N'2024-12-06T13:21:42.640' AS DateTime), CAST(N'2024-12-28T12:16:14.573' AS DateTime), NULL, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Class_St__4F5749EEA8348185]    Script Date: 1/3/2025 10:31:02 PM ******/
ALTER TABLE [dbo].[Class_Student] ADD  CONSTRAINT [UQ__Class_St__4F5749EEA8348185] UNIQUE NONCLUSTERED 
(
	[class_id] ASC,
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Exam_Results]    Script Date: 1/3/2025 10:31:02 PM ******/
ALTER TABLE [dbo].[Exam_Results] ADD  CONSTRAINT [UQ_Exam_Results] UNIQUE NONCLUSTERED 
(
	[lecturer_id] ASC,
	[exam_id] ASC,
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Lecturer__C1D195D699F4B1E8]    Script Date: 1/3/2025 10:31:02 PM ******/
ALTER TABLE [dbo].[Lecturer_Subject] ADD UNIQUE NONCLUSTERED 
(
	[lecturer_id] ASC,
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E616495CBF389]    Script Date: 1/3/2025 10:31:02 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__AB6E616495CBF389] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC572F86B246B]    Script Date: 1/3/2025 10:31:02 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__F3DBC572F86B246B] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__created_a__3A81B327]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__updated_a__3B75D760]  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[Class_Student]  WITH CHECK ADD  CONSTRAINT [FK_Class_Student_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Class_Student] CHECK CONSTRAINT [FK_Class_Student_Classes]
GO
ALTER TABLE [dbo].[Class_Student]  WITH CHECK ADD  CONSTRAINT [FK_Class_Student_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([student_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Class_Student] CHECK CONSTRAINT [FK_Class_Student_Students]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_education_system] FOREIGN KEY([id_es])
REFERENCES [dbo].[education_system] ([id_es])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_education_system]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Lecturer_Subject] FOREIGN KEY([id_lectuer_subject])
REFERENCES [dbo].[Lecturer_Subject] ([id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Lecturer_Subject]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_location]
GO
ALTER TABLE [dbo].[Exam_Results]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Results_Exams] FOREIGN KEY([exam_id])
REFERENCES [dbo].[Exams] ([exam_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exam_Results] CHECK CONSTRAINT [FK_Exam_Results_Exams]
GO
ALTER TABLE [dbo].[Exam_Results]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Results_Lecturers] FOREIGN KEY([lecturer_id])
REFERENCES [dbo].[Lecturers] ([lecturer_id])
GO
ALTER TABLE [dbo].[Exam_Results] CHECK CONSTRAINT [FK_Exam_Results_Lecturers]
GO
ALTER TABLE [dbo].[Exam_Results]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Results_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([student_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Exam_Results] CHECK CONSTRAINT [FK_Exam_Results_Students]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK__Exams__subject_i__5165187F] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK__Exams__subject_i__5165187F]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Lecturers] FOREIGN KEY([invigilator_id])
REFERENCES [dbo].[Lecturers] ([lecturer_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Lecturers]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_location]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Rooms] FOREIGN KEY([room_id])
REFERENCES [dbo].[Rooms] ([room_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Rooms]
GO
ALTER TABLE [dbo].[Lecturer_Subject]  WITH CHECK ADD  CONSTRAINT [FK_Lecturer_Subject_Lecturers1] FOREIGN KEY([lecturer_id])
REFERENCES [dbo].[Lecturers] ([lecturer_id])
GO
ALTER TABLE [dbo].[Lecturer_Subject] CHECK CONSTRAINT [FK_Lecturer_Subject_Lecturers1]
GO
ALTER TABLE [dbo].[Lecturer_Subject]  WITH CHECK ADD  CONSTRAINT [FK_Lecturer_Subject_Subjects] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[Lecturer_Subject] CHECK CONSTRAINT [FK_Lecturer_Subject_Subjects]
GO
ALTER TABLE [dbo].[Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Lecturers_Users] FOREIGN KEY([lecturer_id])
REFERENCES [dbo].[Users] ([user_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lecturers] CHECK CONSTRAINT [FK_Lecturers_Users]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_location]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK__Schedules__exam___5FB337D6] FOREIGN KEY([exam_id])
REFERENCES [dbo].[Exams] ([exam_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK__Schedules__exam___5FB337D6]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Students] FOREIGN KEY([student_id])
REFERENCES [dbo].[Students] ([student_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_academic_year] FOREIGN KEY([id_academic_year])
REFERENCES [dbo].[academic_year] ([id_academic_year])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_academic_year]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_education_system] FOREIGN KEY([id_es])
REFERENCES [dbo].[education_system] ([id_es])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_education_system]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([faculty_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_location]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([faculty_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Faculties]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_semester] FOREIGN KEY([semester_id])
REFERENCES [dbo].[semester] ([semester_id])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_semester]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_typescore] FOREIGN KEY([typescore_id])
REFERENCES [dbo].[typescore] ([typesocre_id])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_typescore]
GO
ALTER TABLE [dbo].[Timetable]  WITH CHECK ADD  CONSTRAINT [FK_Timetable_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[Timetable] CHECK CONSTRAINT [FK_Timetable_Classes]
GO
ALTER TABLE [dbo].[Timetable]  WITH CHECK ADD  CONSTRAINT [FK_Timetable_Rooms1] FOREIGN KEY([room_id])
REFERENCES [dbo].[Rooms] ([room_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Timetable] CHECK CONSTRAINT [FK_Timetable_Rooms1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_location]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__role__398D8EEE] CHECK  (([role]='lecturer' OR [role]='admin'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__role__398D8EEE]
GO
USE [master]
GO
ALTER DATABASE [csdlnc] SET  READ_WRITE 
GO
