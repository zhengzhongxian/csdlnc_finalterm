using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.CoreHeplers;
using COMP106002_PointManagement.Repositories.DbContext;
using COMP106002_PointManagement.Repositories.MongoRepositories.Implementations;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using COMP106002_PointManagement.Repositories.Repositories.Implementations;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.CoreHeplers;
using COMP106002_PointManagement.Services.Services.Email;
using COMP106002_PointManagement.Services.Services.Implementations;
using COMP106002_PointManagement.Services.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SwaggerFileUploadOperationFilter>();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "郑忠显", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme //thêm cấu hình để hỗ trợ authorize với bearer token
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token JWT của bạn vào ô phía dưới",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddLogging();
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy => policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials() // Hỗ trợ WebSocket
              .SetIsOriginAllowed(_ => true));
    // Cho phép mọi origin);
}
);
builder.Services.AddDbContext<PM_App>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();
builder.Services.AddScoped<ILecturerService, LecturerService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
builder.Services.AddScoped<IExamResultService, ExamResultService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
builder.Services.AddScoped<IAcademicYearService, AcademicYearService>();
builder.Services.AddScoped<IEducationSystemRepository, EducationSystemRepository>();
builder.Services.AddScoped<IEducationSystemService, EducationSystemService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ILecturerSubjectRepository, LecturerSubjectRepository>();
builder.Services.AddScoped<ILecturerSubjectService, LecturerSubjectService>();
builder.Services.AddScoped<IClassStudentRepository, ClassStudentRepository>();
builder.Services.AddScoped<IClassStudentService, ClassStudentService>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMongoStudentRepository, MongoStudentRepository>();
builder.Services.AddScoped<IMetadata, Metadata>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMongoExamRepository, MongoExamRepository>();
builder.Services.AddScoped<IMongoRoomRepository, MongoRoomRepository>();
builder.Services.AddScoped<IMongoClassRepository, MongoClassRepository>();
builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<CloudinaryHelper>();
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Lecturer", policy => policy.RequireRole("Lecturer"));
});

//builder.Services.AddAutoMapper(typeof(StudentProfile));
//builder.Services.AddAutoMapper(typeof(LecturerProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "郑忠显");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors();
app.MapHub<ProgressHub>("/progressHub");
app.Run();
