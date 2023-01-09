using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBase.Model
{
    public class Staff
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string Manager { get; set; }
        public List<Subvision> Subvisions { get; set; }

        [NotMapped]
        public List<Subvision> StaffSubvisions
        {
            get
            {
                return DataWorker.GetAllSubvisionsByStaffId(Id);
            }
        }
    }
}
