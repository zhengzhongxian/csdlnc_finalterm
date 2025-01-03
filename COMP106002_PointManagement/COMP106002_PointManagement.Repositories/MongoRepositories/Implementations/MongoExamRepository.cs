using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.DbContext;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.Implementations
{
    public class MongoExamRepository : IMongoExamRepository
    {
        private readonly MongoDbContext _mgdb;
        public MongoExamRepository(MongoDbContext mgdbb)
        {
            _mgdb = mgdbb;
        }
        private IMongoCollection<MgExam> GetCollection(int locationId)
        {
            return _mgdb.GetCollection<MgExam>(locationId, "Exams");
        }

        public async Task AddExamInMongo(MgExam mgExam)
        {
            int? locationId = mgExam.LocationId;

            await GetCollection(locationId.Value).InsertOneAsync(mgExam);
        }

        public async Task<List<MgExam>> GetAllExamInMongo(int location_id)
        {
            var exams = await GetCollection(location_id).Find(_ => true).ToListAsync();
            return exams;
        }

        public async Task<MgExam> GetExamInMongo(string exam_id, int location_id)
        {
            var exam = await GetCollection(location_id).Find(s => s.ExamId == exam_id).FirstOrDefaultAsync();
            return exam;
        }

        public async Task UpdateExaminMongo(MgExam mgExam, int location_id)
        {
            var filter = Builders<MgExam>.Filter.Eq(e => e.ExamId, mgExam.ExamId);
            var update = Builders<MgExam>.Update
                .Set(e => e.SubjectId, mgExam.SubjectId)
                .Set(e => e.RoomId, mgExam.RoomId)
                .Set(e => e.ExamDate, mgExam.ExamDate)
                .Set(e => e.TimeSlot, mgExam.TimeSlot)
                .Set(e => e.Duration, mgExam.Duration)
                .Set(e => e.InvigilatorId, mgExam.InvigilatorId)
                .Set(e => e.ExamType, mgExam.ExamType);

            await GetCollection(location_id).UpdateOneAsync(filter, update);
        }
    }
}
