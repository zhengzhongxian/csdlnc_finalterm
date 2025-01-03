using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.MongoDTO
{
    public class MgRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [NotMapped]
        public ObjectId Id { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public int? Capacity { get; set; }
        public int LocationId { get; set; }
    }
}
