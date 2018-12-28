using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }

        public virtual IEnumerable<TagEvent> TagEvents { get; set; }
    }
}
