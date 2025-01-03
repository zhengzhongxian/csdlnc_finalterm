﻿using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(int id);
    }
}
