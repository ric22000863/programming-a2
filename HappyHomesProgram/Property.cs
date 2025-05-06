using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Class to represent a property that is for sale
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; } // detached, semi-detached, flat

        public Property(int id, string address, string type)
        {
            Id = id;
            Address = address;
            Type = type;
        }

        // Method to store property details
        public static void AddProperty(List<Property> properties, ref int nextPropertyId)
        {
            // User enters the details of the property
            Console.Write("Enter property address: ");
            string address = Console.ReadLine();
            Console.Write("Enter property type (Detached, Flat, etc.): ");
            string type = Console.ReadLine();

            Property property = new Property(nextPropertyId++, address, type);
            properties.Add(property);

            Console.WriteLine($"Property added successfully. \nProperty ID is: {property.Id}");
        }

        // Method to filter properties by name
        public static void FilterPropertyByName(List<Property> properties)
        {
            // User enters the address to search for
            Console.Write("Enter property address: ");
            string address = Console.ReadLine();
            List<Property> foundProperties = properties.Where(p => p.Address.Contains(address, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundProperties.Count == 0)
            {
                // If no properties are found, display message
                Console.WriteLine("No properties found with that address.");
                return;
            }
            foreach (var property in foundProperties)
            {
                // Outputs the properties details
                Console.WriteLine($"Property ID: {property.Id}, Address: {property.Address}, Type: {property.Type}");
            }
        }
    }
}
