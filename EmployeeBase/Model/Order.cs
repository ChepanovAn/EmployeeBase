using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBase.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string ProductName { get; set; }

        public int SubvisionId { get; set; }
        public virtual Subvision Subvision { get; set; }

        [NotMapped]
        public Subvision OrderSubvision
        {
            get
            {
                return DataWorker.GetSubvisionById(SubvisionId);
            }
        }
    }
}
