using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDBwithLinq.Models
{
    public class Stock
    {
        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // Navigation properties
        public Store Store { get; set; }

        public Product Product { get; set; }
    }
}
