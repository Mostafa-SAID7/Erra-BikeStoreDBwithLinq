using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDBwithLinq.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool Active { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public Store Store { get; set; } = null!;
        public Staff? Manager { get; set; }
        public ICollection<Staff> Subordinates { get; set; } = new List<Staff>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
