using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class EventPost
    {
        public int EventPostID { get; set; }

        public virtual Event Event { get; set; }
        public int EventID { get; set; }

        public string UserID { get; set; } //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); in create method for post

        public DateTime AddedDate { get; set; }
        public string Post { get; set; }
    }
}
