﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.CU_DTO
{
    public class SubjectCreateUpdateDTO
    {
        public string SubjectName { get; set; } = null!;
        public int? Credits { get; set; }
        public string? FacultyId { get; set; }
        public int? TypescoreId { get; set; }
        public int? SemesterId { get; set; }
    }
}
