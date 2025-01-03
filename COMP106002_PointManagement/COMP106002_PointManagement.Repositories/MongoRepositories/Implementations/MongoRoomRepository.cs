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
    public class MongoRoomRepository : IMongoRoomRepository
    {
        private readonly MongoDbContext _dbContext;
        public MongoRoomRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IMongoCollection<MgRoom> GetCollection(int locationId)
        {
            return _dbContext.GetCollection<MgRoom>(locationId, "Rooms");
        }

        public async Task AddRoom(MgRoom mgRoom)
        {
            int? locationId = mgRoom.LocationId;

            await GetCollection(locationId.Value).InsertOneAsync(mgRoom);
        }
    }
}
