using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreDBwithLinq.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ModelYear { get; set; }

        public decimal ListPrice { get; set; }

        // Navigation properties
        public Brand Brand { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
