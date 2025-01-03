using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IRoomService
    {
        Task<ServiceResponse<IEnumerable<RoomDTO>>> GetAllRoomsAsync(int location_id);
        Task<ServiceResponse<bool>> AddRoom(Create_RoomDTO roomDTO, int location_id);
    }
}
