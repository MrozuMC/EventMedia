using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Event> FindWithMultiTags(Func<Event, bool> predicate)
        {
            return _context.Events
                .Include(t => t.TagEvents)
                .Where(predicate);
        }

        public IEnumerable<Event> FindWithTag(Func<Event, bool> predicate)
        {
            return _context.Events
                .Include(t => t.TagEvents)
                .Where(predicate);
        }

        public IEnumerable<Event> GetAllWithAdress()
        {
            return _context.Events.Include(a => a.EventAddress);
        }
    }
}
