using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IMongoRoomRepository _mongoRoomRepository;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IMongoRoomRepository mongoRoomRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _mongoRoomRepository = mongoRoomRepository;
        }

        public async Task<ServiceResponse<IEnumerable<RoomDTO>>> GetAllRoomsAsync(int location_id)
        {
            var response = new ServiceResponse<IEnumerable<RoomDTO>>();
            try
            {
                var rooms = await _roomRepository.GetAllRoomsAsync(location_id);
                response.Data = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
                response.Message = "Lấy danh sách phòng thành công.";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> AddRoom(Create_RoomDTO roomDTO, int location_id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var newroom = _mapper.Map<Room>(roomDTO);
                newroom.LocationId = location_id;
                newroom.RoomId = newroom.RoomName ?? "No Name";
                var mongo = _mapper.Map<MgRoom>(newroom);
                await _roomRepository.AddRoom(newroom);
                await _mongoRoomRepository.AddRoom(mongo);
                response.Message = "Thêm phòng thành công";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Thêm phòng thành công";
            }
            return response;
        }
    }
}
