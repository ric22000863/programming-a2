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
    }
}
