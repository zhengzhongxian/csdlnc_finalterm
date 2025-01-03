using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.CoreHeplers;
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
    public class Metadata : IMetadata
    {
        private readonly MongoDbContext _mgdb;
        public Metadata(MongoDbContext mgdb)
        {
            _mgdb = mgdb;
        }
        private IMongoCollection<Auditable> GetCollection()
        {
            return _mgdb.GetCollectionMetaData<Auditable>("MetaData");
        }

        public async Task AddMetadaAsync(Auditable _auditable)
        {
            await GetCollection().InsertOneAsync(_auditable);
        }

        public async Task UpdateMetadaAsync(string made_by, string auditable_id, int locationId, int isMethod)
        {
            var filter = Builders<Auditable>.Filter.Eq(s => s.auditable_id, auditable_id);
            UpdateDefinition<Auditable> update;
            if (isMethod == 1)
            {
                update = Builders<Auditable>.Update
                    .Set(s => s.updated_at, DateTime.UtcNow)
                    .Set(s => s.updated_by, made_by);
            }
            else if (isMethod == 2)
            {
                update = Builders<Auditable>.Update
                    .Set(s => s.deleted_at, DateTime.UtcNow)
                    .Set(s => s.deleted_by, made_by)
                    .Set(s => s.status, 0);
            }
            else
            {
                update = Builders<Auditable>.Update
                    .Set(s => s.restored_at, DateTime.UtcNow)
                    .Set(s => s.restored_by, made_by)
                    .Set(s => s.status, 1);
            }

            await GetCollection().UpdateOneAsync(filter, update);
        }

        public async Task<Auditable> GetMetadabyIdAsync(string auditable_id)
        {
            var auditable = await GetCollection().Find(s => s.auditable_id == auditable_id).FirstOrDefaultAsync();
            return auditable;
        }
    }
}
