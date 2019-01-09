using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Interfaces
{
    public interface ITagEventRepository : IRepository<TagEvent>
    {
        List<TagEvent> GetTagsToCRUD();
        List<TagEvent> GetTags(int? id);

        
    }
}
