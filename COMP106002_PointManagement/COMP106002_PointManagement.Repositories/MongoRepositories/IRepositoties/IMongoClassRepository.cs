using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties
{
    public interface IMongoClassRepository
    {
        Task AddClass(MgClass mgClass);
        Task UpdateClass(MgClass mgClass);
    }
}
