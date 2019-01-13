using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class OrganiserRatingRepository : Repository<OrganiserRating>, IOrganiserRatingRepository
    {
        public OrganiserRatingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public OrganiserRating FindCurrentUserInTable(string id)
        {
           return _context.OrganiserRatings.Where(x => x.UserID == id).FirstOrDefault();
        }
    }
}
