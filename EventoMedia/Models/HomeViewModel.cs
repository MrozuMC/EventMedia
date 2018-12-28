using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Models
{
    public class HomeViewModel
    {
       
        public string HeadImageURL { get; set; }
        public string OrganiserID { get; set; } //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int NumberofTickets { get; set; }
        public bool Active { get; set; }

        
        public string Address { get; set; }
        public string City { get; set; }
    }
}
