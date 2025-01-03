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
    public class MgClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [NotMapped]
        public ObjectId Id { get; set; }
        public string ClassId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? IdEs { get; set; }
        public string? IdLectuerSubject { get; set; }
        public int? LocationId { get; set; }
        public string AuditableId { get; set; }
    }
}
