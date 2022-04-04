using Delegates.Models;
using System;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Customer newCustomer = new("Jim", "Halpert", Level.New, "Brown str. 67, Imaginary City");
            Customer smallCustomer = new("Dwight", "Schrute", Level.SmallOrdersPermanent, "Green str. 18, Imaginary City");
            Customer largeCustomer = new("Pam", "Beesly", Level.LargeOrdersPermanent, "Potter str. 19, Imaginary City");

            Order order1 = new(1, "January 18, 2022", 10000);
            Order order2 = new(2, "February 2, 2022", 123000);
            Order order3 = new(3, "March 1, 2022", 5000);

            Console.WriteLine($"New Customer, {newCustomer.Name}, Address: {newCustomer.Address}");
            Console.WriteLine(newCustomer.Calculation(order1));
            Console.WriteLine(newCustomer.Calculation(order2));
            Console.WriteLine(newCustomer.Calculation(order3));

            Console.WriteLine($"Permanent Customer with Small Orders, {smallCustomer.Name}, Address: {smallCustomer.Address}");
            Console.WriteLine(smallCustomer.Calculation(order1));
            Console.WriteLine(smallCustomer.Calculation(order2));
            Console.WriteLine(smallCustomer.Calculation(order3));

            Console.WriteLine($"Permanent Customer with Large Orders, {largeCustomer.Name}, Address: {largeCustomer.Address}");
            Console.WriteLine(largeCustomer.Calculation(order1));
            Console.WriteLine(largeCustomer.Calculation(order2));
            Console.WriteLine(largeCustomer.Calculation(order3));
        }
    }
}