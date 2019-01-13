﻿using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Interfaces
{
    public interface IUserEventRepository : IRepository<UserEvent>
    {
        List<UserEvent> GetAllUsers(int? id);
        List<UserEvent> GetAllUsersToCRUD();
        UserEvent FindUserInEvent(string id, int eventid);
    }
}
