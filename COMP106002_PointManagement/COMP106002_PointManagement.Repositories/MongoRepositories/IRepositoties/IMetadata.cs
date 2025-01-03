using COMP106002_PointManagement.Repositories.CoreHeplers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties
{
    public interface IMetadata
    {
        Task AddMetadaAsync(Auditable _auditable);
        Task UpdateMetadaAsync(string made_by, string auditable_id, int locationId, int isMethod);
        Task<Auditable> GetMetadabyIdAsync(string auditable_id);
    }
}
