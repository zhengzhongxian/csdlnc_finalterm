using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync(int location_id);
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task<Room> GetRoomById(string id);
        Task Delete(string id);
    }
}
