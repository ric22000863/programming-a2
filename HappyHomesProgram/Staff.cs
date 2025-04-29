using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Class to represent a staff member
    class Staff
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
    }
}
