using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace COMP106002_PointManagement.Repositories.Models.MongoDTO
{
    public class MgStudentDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [NotMapped]
        public ObjectId Id { get; set; }
        //[BsonElement("student_id")]
        public string StudentId { get; set; } = null!;

        public string? StudentName { get; set; }

        public string? Photo { get; set; }

        public string? Gender { get; set; }

        public DateOnly? Dayofbirth { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        [JsonIgnore]
        public string? AuditableId { get; set; }
        public int? LocationId { get; set; }
    }
}
