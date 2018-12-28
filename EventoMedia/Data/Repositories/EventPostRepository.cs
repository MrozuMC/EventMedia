using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class EventPostRepository : Repository<EventPost>, IEventPostRepository
    {
        public EventPostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
