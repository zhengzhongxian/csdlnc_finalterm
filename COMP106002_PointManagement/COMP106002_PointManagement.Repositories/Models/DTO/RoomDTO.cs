using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class RoomDTO
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; } 
        public int? Capacity { get; set; }
        //public int LocationId { get; set; }
    }
    public class Create_RoomDTO
    {
        public string RoomName { get; set; }
        public int? Capacity { get; set; }
    }
}
