using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomesProgram
{
    // Represents a property that is for sale
    class Property
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
    }
}
