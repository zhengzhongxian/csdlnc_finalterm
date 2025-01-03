using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly PM_App _pm_App;

        public LocationRepository(PM_App pm_App)
        {
            _pm_App = pm_App;
        }

        public async Task<List<Location>> GetAllLocations()
        {

            return await _pm_App.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _pm_App.Locations.FirstOrDefaultAsync(s => s.LocationId == id);
        }
    }
}
