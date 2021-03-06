﻿using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Repositories
{
    public class UserEventRepository : Repository<UserEvent>, IUserEventRepository
    {
        public UserEventRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserEvent FindUserInEvent(string id, int eventid)
        {
            return _context.UserEvents.Where(ue => ue.UserID == id).Where( ue => ue.EventID == eventid).FirstOrDefault();
            
        }

        public List<UserEvent> GetAllUsers(int? id)
        {
            return _context.UserEvents.Include(x => x.User).Where(ue => ue.EventID == id).ToList();
        }

        public List<UserEvent> GetAllUsersToCRUD()
        {
            return _context.UserEvents.Include(x => x.User).ToList();
        }

    }
}
