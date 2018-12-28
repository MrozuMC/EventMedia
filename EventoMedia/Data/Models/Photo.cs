using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoUrl { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }
    }
}
