﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class SubjectDTO
    {
        public string SubjectId { get; set; } = null!;
        public string? SubjectName { get; set; }
        public int? Credits { get; set; }
        public string? FacultyName { get; set; }
        public int? TypescoreId { get; set; }
        public int? SemesterId { get; set; }
    }
}
