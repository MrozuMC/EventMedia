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
                .ThenInclude(t => t.Tag)
                .Where(predicate);
        }

        public IEnumerable<Event> GetAllForHomeViewModel()
        {
            return _context.Events
                .Include(x => x.EventAddress)
                .Include(x => x.OrganiserRating)
                    .ThenInclude(x => x.User);
        }

        public IEnumerable<Event> GetAllWithAdress()
        {
            return _context.Events.Include(a => a.EventAddress).Include(e => e.OrganiserRating).ThenInclude(x => x.User);
        }

        public Event GetByIdWithAddress(int? id) {

            return _context.Events
                .Include(x => x.EventAddress)
                .Include(x => x.OrganiserRating)
                    .ThenInclude(x => x.User)
                .Where(e => e.EventID == id)
                .FirstOrDefault();
                                  

        }

        public Event GetByIdWithEverything(int? id)
        {
            return _context.Events
                .Include(x => x.EventAddress)
                .Include(o => o.OrganiserRating)
                .Include(t => t.TagEvents)
                    .ThenInclude(e => e.Tag)
                .AsNoTracking()                
                .SingleOrDefault(m => m.EventID == id);
        }
    }
}
