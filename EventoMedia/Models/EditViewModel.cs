using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Models
{
    public class EditViewModel
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string HeadImageURL { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberofTickets { get; set; }
        public bool Active { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public List<Tagi> Tags { get; set; }
    }
}
