using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EventoMedia.Data.Models
{
    public class OrganiserRating
    {
        public int OrganiserRatingID { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public int NumberOfVotes { get; set; }
        public double AverageRating { get; set; }
    }
}
