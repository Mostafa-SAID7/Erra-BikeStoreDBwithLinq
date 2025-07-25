using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDBwithLinq.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;

        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
