using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class EventAddress
    {
        public int EventAddressID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Aditionalinfo { get; set; } //eg. How to get to that place
    }
}
