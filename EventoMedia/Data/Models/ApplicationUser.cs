using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Nick { get; set; }
        public virtual IEnumerable<UserEvent> UserEvents { get; set; }
    }
}
