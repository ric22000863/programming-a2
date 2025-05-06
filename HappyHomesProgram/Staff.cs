using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Class to represent a staff member
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DateTime> UnavailableTimes { get; set; } = new List<DateTime>();

        public Staff(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Check if staff is available at a specific time
        public bool IsAvailable(DateTime dateTime)
        {
            return !UnavailableTimes.Contains(dateTime);
        }

        // Mark staff as unavailable at a specific time
        public void MarkUnavailable(DateTime dateTime)
        {
            UnavailableTimes.Add(dateTime);
        }

        // Method to add staff member
        public static void AddStaff(List<Staff> staffMembers, ref int nextStaffId)
        {
            // User enters the staff member details
            Console.Write("Enter staff name: ");
            string name = Console.ReadLine();
            Staff staff = new Staff(nextStaffId++, name);
            staffMembers.Add(staff);
            Console.WriteLine($"Staff member added successfully. \nStaff ID is: {staff.Id}");
        }
    }
}
