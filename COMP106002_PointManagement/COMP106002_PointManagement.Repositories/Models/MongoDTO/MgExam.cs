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
    public class MgExam
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [NotMapped]
        public ObjectId Id { get; set; }
        public string ExamId { get; set; }
        public string SubjectId { get; set; }
        public string RoomId { get; set; }
        public DateOnly ExamDate { get; set; }
        public TimeOnly TimeSlot { get; set; }
        public int Duration { get; set; }
        public string? InvigilatorId { get; set; }
        public string ExamType { get; set; }
        [JsonIgnore]
        public string? AuditableId { get; set; }
        public int? LocationId { get; set; }
    }
}
