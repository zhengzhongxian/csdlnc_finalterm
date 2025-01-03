using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace COMP106002_PointManagement.Repositories.CoreHeplers
{
    public class Auditable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        [NotMapped]
        public ObjectId Id { get; set; }
        [JsonIgnore]
        public string auditable_id;
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public string updated_by { get; set; }
        public DateTime? deleted_at { get; set; }
        public string deleted_by { get; set; }
        public DateTime? transfered_at { get; set; }
        public string transfered_by { get; set; }
        public DateTime? restored_at {  get; set; }
        public string restored_by { get; set; }
        public int status;
    }
}
