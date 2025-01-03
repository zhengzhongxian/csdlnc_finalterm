using Azure;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace COMP106002_PointManagement.Repositories.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoClient _mongoClient;
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly ILogger<MongoDbContext> _logger;
        public MongoDbContext(IConfiguration configuration, HttpClient httpClient, ILogger<MongoDbContext> logger)
        {
            _mongoClient = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _httpClient = httpClient;
            _apiUrl = configuration["Jwt:Issuer"];
            _logger = logger;
        }

        public async Task<IMongoDatabase> GetDatabaseByLocationAsync(int locationId)
        {

            var location = await GetLocationFromApiAsync(locationId);
            if (location == null)
            {
                throw new Exception($"Location with ID {locationId} not found.");
            }
            string dbName = location;

            if (string.IsNullOrEmpty(dbName))
            {
                throw new Exception($"Database name is null or empty for location with ID {locationId}");
            }

            return _mongoClient.GetDatabase(dbName);
        }

        public async Task<IMongoDatabase> GetDatabaseMetadatainMongo()
        {
            return _mongoClient.GetDatabase("db_metadata");
        }

        private async Task<string> GetLocationFromApiAsync(int locationId)
        {

            var response = await _httpClient.GetAsync($"{_apiUrl}/api/Location/{locationId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var locationResponse = JsonSerializer.Deserialize<LocationDTO>(content);
                return locationResponse.MongoDbName;
               
            }

            return null;
        }

        public IMongoCollection<T> GetCollection<T>(int locationId, string collectionName)
        {
            var database = GetDatabaseByLocationAsync(locationId).Result;
            return database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> GetCollectionMetaData<T>(string collectionName)
        {
            var database = GetDatabaseMetadatainMongo().Result;
            return database.GetCollection<T>(collectionName);
        }
    }
}
