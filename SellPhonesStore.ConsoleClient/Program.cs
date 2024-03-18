using SellPhonesStore.DataAccess;
using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create a new phone
            var phone = new Phone
            {
                PhoneDescription = "Samsung S20 Ultra",
                Price = 999.99f,
                ManufacturingDate = DateTime.Now,
                BrandName = "Samsung",
                InStock = 50
            };

            // Create a new customer
            var customer = new Customer
            {
                CustomerName = "Joji",
                EmailId = "joji@example.com",
                City = "New York",
                StreetName = "10 Downing Street",
                PinCode = "10012",
                MobileNo = 9994567890
            };

            // Create a new customer order
            var order = new CustomerOrder
            {
                OrderDate = DateTime.Now,
                Customer = customer,
                OrderTotal = 999.99f
            };

            // Create a new ordered phone
            var orderedPhone = new OrderedPhone
            {
                TheOrderedPhone = phone,
                Quantity = 2
            };

            // Initialize the repository
            IPhoneRepository phoneRepository = new PhoneRepository();

            // Save the phone
            long phoneId = phoneRepository.SavePhone(phone);

            // Save the customer
            long customerId = phoneRepository.SaveCustomer(customer);

            // Save the order
            long orderId = phoneRepository.SaveOrder(order);

            // Save the ordered phone
            long orderedPhoneId = phoneRepository.SaveOrderedPhone(orderedPhone, orderId);

            // Retrieve all customer orders
            var allOrders = phoneRepository.GetAllCustomerOrders();
            Console.WriteLine("All Customer Orders:");
            foreach (var o in allOrders)
            {
                Console.WriteLine($"Order ID: {o.OrderId}, Customer ID: {o.Customer.CustomerId}");
            }

            // Retrieve orders for a specific customer
            var customerOrders = phoneRepository.GetCustomerOrders(customerId);
            Console.WriteLine("\nCustomer Orders:");
            foreach (var o in customerOrders)
            {
                Console.WriteLine($"Order ID: {o.OrderId}, Customer ID: {o.Customer.CustomerId}");
            }
        }
    }
}
