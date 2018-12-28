using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class TagEvent
    {
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public int EventID { get; set; }
        public virtual Event Event { get; set; }
    }
}
