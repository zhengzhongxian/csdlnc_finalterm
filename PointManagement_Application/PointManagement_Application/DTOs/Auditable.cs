using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class Auditable
    {
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public string updated_by { get; set; }
        public DateTime? deleted_at { get; set; }
        public string deleted_by { get; set; }
        public DateTime? transfered_at { get; set; }
        public string transfered_by { get; set; }
        public DateTime? restored_at { get; set; }
        public string restored_by { get; set; }
        public int status;
    }
}
