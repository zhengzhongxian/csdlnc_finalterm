using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        private readonly PM_App _context;

        public RoomRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync(int location_id)
        {
            return await _context.Rooms.Where(s => s.LocationId == location_id).ToListAsync();
        }
        
        public async Task AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoomById(string id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(s => s.RoomId == id);
        }

        public async Task Delete(string id)
        {
            var remove = await GetRoomById(id);
            _context.Rooms.Remove(remove);
            await _context.SaveChangesAsync();
        }
    }
}
