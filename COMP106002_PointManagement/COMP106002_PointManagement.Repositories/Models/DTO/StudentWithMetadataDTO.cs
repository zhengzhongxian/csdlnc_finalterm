using COMP106002_PointManagement.Repositories.CoreHeplers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class StudentWithMetadataDTO : StudentDTO
    {
        public Auditable auditable {  get; set; }
    }
}
