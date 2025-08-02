// Models/Customer.cs

using System.ComponentModel.DataAnnotations;﻿

namespace BikeStoreDBwithLinq.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [MaxLength(255)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; } = null!;
        [MaxLength(255)]
        public string Street { get; set; } = null!;
        [MaxLength(50)]
        public string City { get; set; } = null!;
        [MaxLength(50)]
        public string State { get; set; } = null!;
        [MaxLength(25)]
        public string ZipCode { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

