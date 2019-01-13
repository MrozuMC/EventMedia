using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class EventAddressRepository : Repository<EventAddress>, IEventAddressRepository
    {
        public EventAddressRepository(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}
