using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Class to represent a customer booking a viewing
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CurrentAddress { get; set; }
        public string Telephone { get; set; }
        public int MissedViewings { get; set; } = 0;
        public bool IsBanned { get; set; } = false;

        public Customer(int id, string fullName, string email, string currentAddress, string telephone)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            CurrentAddress = currentAddress;
            Telephone = telephone;
        }

        // Method to filter customers by name
        public static void FilterCustomerByName(List<Customer> customers)
        {
            // User enters the name to search for
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            List<Customer> foundCustomers = customers.Where(c => c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundCustomers.Count == 0)
            {
                // If no customers are found, display message
                Console.WriteLine("No customers found with that name.");
                return;
            }
            foreach (var customer in foundCustomers)
            {
                // Outputs the customers details
                Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.FullName}, Email: {customer.Email}, Banned: {customer.IsBanned}");
            }
        }
    }
}
