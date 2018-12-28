using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class UserEvent
    {
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public int EventID { get; set; }

        public Event Event { get; set; }
    }
}
