using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Models
{
    [NotMapped]
    public class UsersinEvents
    {
        public int id { get; set; }
        public string UserID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nick { get; set; }
    }
}
