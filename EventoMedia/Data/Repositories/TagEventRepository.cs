using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class TagEventRepository : Repository<TagEvent>, ITagEventRepository
    {
        public TagEventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<TagEvent> GetTags(int? id)
        {
            return _context.TagEvents.Include(x => x.Tag).Where(te => te.EventID == id).ToList();
        }

        public List<TagEvent> GetTagsForEvent()
        {
            return _context.TagEvents.Include(x => x.Tag).Include(x => x.Event).ToList();
        }

        public List<TagEvent> GetTagsToCRUD()
        {
            return _context.TagEvents.Include(x => x.Tag).ToList();
        }

       
    }
}
