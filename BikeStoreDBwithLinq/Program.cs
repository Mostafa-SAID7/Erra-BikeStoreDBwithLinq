using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BikeStoreDbContext();

            // 1. List all customers' first and last names along with their email addresses.
            var customers = context.Customers.Select(c => new { c.FirstName, c.LastName, c.Email }).ToList();
            Console.WriteLine("All Customers:");
            customers.ForEach(c => Console.WriteLine($"{c.FirstName} {c.LastName} - {c.Email}"));

            // 2. Orders by staff_id = 3
            var ordersByStaff = context.Orders.Where(o => o.StaffId == 3).ToList();
            Console.WriteLine("\nOrders Processed by Staff ID 3:");
            ordersByStaff.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}"));

            // 3. Products in 'Mountain Bikes' category
            var mountainBikes = context.Products.Where(p => p.Category.Name == "Mountain Bikes").ToList();
            Console.WriteLine("\nMountain Bikes:");
            mountainBikes.ForEach(p => Console.WriteLine(p.ProductName));

            // 4. Total number of orders per store
            var ordersPerStore = context.Orders.GroupBy(o => o.StoreId)
                .Select(g => new { StoreId = g.Key, Count = g.Count() }).ToList();
            Console.WriteLine("\nOrders per Store:");
            ordersPerStore.ForEach(s => Console.WriteLine($"Store ID: {s.StoreId}, Orders: {s.Count}"));

            // 5. Orders not shipped yet
            var unshippedOrders = context.Orders.Where(o => o.ShippedDate == null).ToList();
            Console.WriteLine("\nUnshipped Orders:");
            unshippedOrders.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}"));

            // 6. Customer full name with order count
            var customerOrders = context.Customers
                .Select(c => new { FullName = c.FirstName + " " + c.LastName, Orders = c.Orders.Count() }).ToList();
            Console.WriteLine("\nCustomer Order Counts:");
            customerOrders.ForEach(c => Console.WriteLine($"{c.FullName}: {c.Orders} orders"));

            // 7. Products never ordered
            var neverOrderedProducts = context.Products.Where(p => !p.OrderItems.Any()).ToList();
            Console.WriteLine("\nNever Ordered Products:");
            neverOrderedProducts.ForEach(p => Console.WriteLine(p.ProductName));

            // 8. Products with stock < 5
            var lowStockProducts = context.Stocks.Where(s => s.Quantity < 5).Select(s => s.Product).Distinct().ToList();
            Console.WriteLine("\nLow Stock Products (<5):");
            lowStockProducts.ForEach(p => Console.WriteLine(p.ProductName));

            // 9. First product
            var firstProduct = context.Products.FirstOrDefault();
            Console.WriteLine("\nFirst Product:");
            Console.WriteLine(firstProduct?.ProductName);

            // 10. Products by model year
            int modelYear = 2024;
            var productsByYear = context.Products.Where(p => p.ModelYear == modelYear).ToList();
            Console.WriteLine($"\nProducts of Model Year {modelYear}:");
            productsByYear.ForEach(p => Console.WriteLine(p.ProductName));

            // 11. Product order counts
            var productOrderCounts = context.Products
                .Select(p => new { p.ProductName, OrderCount = p.OrderItems.Count() }).ToList();
            Console.WriteLine("\nProduct Order Counts:");
            productOrderCounts.ForEach(p => Console.WriteLine($"{p.ProductName}: {p.OrderCount}"));

            // 12. Count of products in category
            int categoryId = 2;
            var productCount = context.Products.Count(p => p.CategoryId == categoryId);
            Console.WriteLine($"\nNumber of Products in Category ID {categoryId}: {productCount}");

            // 13. Average list price
            var avgPrice = context.Products.Average(p => p.ListPrice);
            Console.WriteLine($"\nAverage List Price of Products: {avgPrice:C}");

            // 14. Specific product by ID
            int productId = 10;
            var specificProduct = context.Products.FirstOrDefault(p => p.ProductId == productId);
            Console.WriteLine($"\nProduct ID {productId}: {specificProduct?.ProductName}");

            // 15. Products ordered with quantity > 3
            var productsWithLargeOrders = context.OrderItems.Where(oi => oi.Quantity > 3)
                .Select(oi => oi.Product).Distinct().ToList();
            Console.WriteLine("\nProducts Ordered with Quantity > 3:");
            productsWithLargeOrders.ForEach(p => Console.WriteLine(p.ProductName));

            // 16. Staff with order counts
            var staffOrderCounts = context.Staffs.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                OrdersProcessed = s.Orders.Count()
            }).ToList();
            Console.WriteLine("\nStaff Order Counts:");
            staffOrderCounts.ForEach(s => Console.WriteLine($"{s.FullName}: {s.OrdersProcessed}"));

            // 17. Active staff with phone numbers
            var activeStaff = context.Staffs.Where(s => s.Active)
                .Select(s => new { FullName = s.FirstName + " " + s.LastName, s.Phone }).ToList();
            Console.WriteLine("\nActive Staff Members:");
            activeStaff.ForEach(s => Console.WriteLine($"{s.FullName} - {s.Phone}"));

            // 18. Products with brand & category names
            var productDetails = context.Products
                .Select(p => new { p.ProductName, BrandName = p.Brand.Name, CategoryName = p.Category.Name }).ToList();
            Console.WriteLine("\nProduct Details:");
            productDetails.ForEach(p => Console.WriteLine($"{p.ProductName} - Brand: {p.BrandName}, Category: {p.CategoryName}"));

            // 19. Completed Orders
            var completedOrders = context.Orders.Where(o => o.OrderStatus == 4).ToList();
            Console.WriteLine("\nCompleted Orders:");
            completedOrders.ForEach(o => Console.WriteLine($"Order ID: {o.OrderId}"));

            // 20. Products with total quantity sold
            var productSales = context.Products.Select(p => new
            {
                p.ProductName,
                TotalQuantitySold = p.OrderItems.Sum(oi => (int?)oi.Quantity) ?? 0
            }).ToList();
            Console.WriteLine("\nTotal Quantity Sold per Product:");
            productSales.ForEach(p => Console.WriteLine($"{p.ProductName}: {p.TotalQuantitySold}"));
        }
    }
}


