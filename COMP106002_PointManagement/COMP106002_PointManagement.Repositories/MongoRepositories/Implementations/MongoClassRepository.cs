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
    public class MongoClassRepository : IMongoClassRepository
    {
        private readonly MongoDbContext _dbContext;
        public MongoClassRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IMongoCollection<MgClass> GetCollection(int locationId)
        {
            return _dbContext.GetCollection<MgClass>(locationId, "Classes");
        }

        public async Task AddClass(MgClass mgClass)
        {
            int? locationId = mgClass.LocationId;

            await GetCollection(locationId.Value).InsertOneAsync(mgClass);
        }

        public async Task UpdateClass(MgClass mgClass)
        {
            var filter = Builders<MgClass>.Filter.Eq(c => c.ClassId, mgClass.ClassId);

            var update = Builders<MgClass>.Update
                .Set(c => c.StartDate, mgClass.StartDate)
                .Set(c => c.EndDate, mgClass.EndDate)
                .Set(c => c.IdEs, mgClass.IdEs)
                .Set(c => c.IdLectuerSubject, mgClass.IdLectuerSubject)
                .Set(c => c.LocationId, mgClass.LocationId);

            await GetCollection(mgClass.LocationId.Value).UpdateOneAsync(filter, update);
        }
    }
}
