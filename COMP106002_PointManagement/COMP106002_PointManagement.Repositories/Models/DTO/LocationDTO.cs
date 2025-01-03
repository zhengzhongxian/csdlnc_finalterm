using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class LocationDTO
    {
        [JsonPropertyName("locationId")]
        public int LocationId { get; set; }

        [JsonPropertyName("locationName")]
        public string LocationName { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("mongoDbName")]
        public string MongoDbName { get; set; }
    }
}
