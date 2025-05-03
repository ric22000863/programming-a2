using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyHomesProgram;

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
    }
}

