using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string HeadImageURL { get; set; }
        public string OrganiserID { get; set; } //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string EventName { get; set; }

        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int NumberofTickets { get; set; }
        public bool Active { get; set; }

        public virtual EventAddress EventAddress { get; set; }

        public virtual IEnumerable<EventPost> EventPosts { get; set; }

        public virtual IEnumerable<Photo> Photos { get; set; } // Photos table not nullable 

        public virtual IEnumerable<TagEvent> TagEvents { get; set; }

        public virtual IEnumerable<UserEvent> UserEvents { get; set; }
    }
}
