using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties
{
    public interface IMongoExamRepository
    {
        Task AddExamInMongo(MgExam mgExam);
        Task<List<MgExam>> GetAllExamInMongo(int location_id);
        Task<MgExam> GetExamInMongo(string exam_id, int location_id);
        Task UpdateExaminMongo(MgExam mgExam, int location_id);
    }
}
