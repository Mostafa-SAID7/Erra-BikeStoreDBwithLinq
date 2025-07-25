using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDBwithLinq.Models
{
    public  class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? StoreId { get; set; }
        public int? StaffId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public Store Store { get; set; } = null!;
        public Staff Staff { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
