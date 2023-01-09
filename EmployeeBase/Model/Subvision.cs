using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBase.Model
{
    public class Subvision
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public List<Order> Orders { get; set; }

        [NotMapped]
        public Staff SubvisionStaff
        {
            get
            {
                return DataWorker.GetStaffById(StaffId);
            }
        }
        [NotMapped]
        public List<Order> SubvisionOrders
        {
            get
            {
                return DataWorker.GetAllOrdersBySubvisionId(Id);
            }
        }
    }
}
