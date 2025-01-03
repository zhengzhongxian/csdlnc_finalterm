using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.DbContext;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.Implementations
{
    public class MongoStudentRepository : IMongoStudentRepository
    {
        private readonly MongoDbContext _mgdb;
        public MongoStudentRepository(MongoDbContext mgdb)
        {
            _mgdb = mgdb;
        }

        private IMongoCollection<MgStudentDTO> GetCollection(int locationId)
        {
            return _mgdb.GetCollection<MgStudentDTO>(locationId, "Students");
        }

        public async Task AddStudentAsync(MgStudentDTO student)
        {
            int? locationId = student.LocationId;

            await GetCollection(locationId.Value).InsertOneAsync(student);
        }

        public async Task DeleteStudentAsync(string studentId)
        {
            int? locationId = int.Parse(studentId.Substring(0, 1));
            await GetCollection(locationId.Value).DeleteOneAsync(s => s.StudentId == studentId);
        }

        public async Task<List<MgStudentDTO>> GetAllStudentsAsync(int locationId)
        {
            var students = await GetCollection(locationId).Find(_ => true).ToListAsync();
            return students;
        }

        public async Task<MgStudentDTO> GetStudentByIdAsync(string studentId)
        {
            int locationId = int.Parse(studentId.Substring(0, 1));
            var student = await GetCollection(locationId).Find(s => s.StudentId == studentId).FirstOrDefaultAsync();
            return student;
        }

        public async Task UpdateStudentAsync(MgStudentDTO student)
        {
            var studentId = student.StudentId;
            int locationId = int.Parse(studentId.Substring(0, 1));
            var filter = Builders<MgStudentDTO>.Filter.Eq(s => s.StudentId, studentId);
            var update = Builders<MgStudentDTO>.Update
                .Set(s => s.StudentName, student.StudentName)
                .Set(s => s.Gender, student.Gender)
                .Set(s => s.Dayofbirth, student.Dayofbirth)
                .Set(s => s.Email, student.Email)
                .Set(s => s.Address, student.Address)
                .Set(s => s.PhoneNumber, student.PhoneNumber)
                .Set(s => s.Photo, student.Photo);
            await GetCollection(locationId).UpdateOneAsync(filter, update);
        }
    }
}
