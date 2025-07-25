using System;
using BikeStoreDBwithLinq.Data;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new BikeStoreDbContext())
        {
            var canConnect = context.Database.CanConnect();
            //to ensure connection
            Console.WriteLine(canConnect ? "Connected!...." : "Field To Connecting.");
            
            Console.WriteLine($"Total Customers: {context.Customers.Count()}");

        }

        Console.ReadKey();
    }
}
