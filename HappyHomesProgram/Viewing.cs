using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Class that would show appointments for viewings
    public class Viewing
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Property Property { get; set; }
        public Staff Staff { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; } // booked, attended, missed, cancelled

        public Viewing(int id, Customer customer, Property property, Staff staff, DateTime dateTime)
        {
            Id = id;
            Customer = customer;
            Property = property;
            Staff = staff;
            DateTime = dateTime;
            Status = "booked"; // sets the default status to booked
        }

        // Method to update viewing status
        public static void UpdateViewingStatus(List<Viewing> viewings)
        {
            // User enters the viewing ID to update
            Console.Write("Enter viewing ID: ");
            int viewingId = Convert.ToInt32(Console.ReadLine());
            Viewing viewing = viewings.FirstOrDefault(v => v.Id == viewingId);
            if (viewing == null)
            {
                // If the viewing isn't found, display message
                Console.WriteLine("Viewing not found.");
                return;
            }

            // User enters the new status for the viewing
            Console.Write("Enter new status: ");
            string status = Console.ReadLine();
            viewing.Status = status;

            // If the status is 'Missed', increment the customer's MissedViewings count
            if (status.Equals("Missed", StringComparison.OrdinalIgnoreCase))
            {
                viewing.Customer.MissedViewings += 1;
                Console.WriteLine("Customer's missed viewings count has been updated.");
            }

            Console.WriteLine($"Viewing status updated successfully. \nNew status is: {viewing.Status}");
        }
    }
}
