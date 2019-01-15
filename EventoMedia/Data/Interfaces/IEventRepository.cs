﻿using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllWithAdress();
        IEnumerable<Event> GetAllForHomeViewModel();
        Event GetByIdWithAddress(int? id);
        IEnumerable<Event> FindWithTag(Func<Event, bool> predicate);
        IEnumerable<Event> FindWithMultiTags(Func<Event, bool> predicate);
        Event GetByIdWithEverything(int? id);

        

        bool CheckForActiveEvent(int? id);
    }
}
