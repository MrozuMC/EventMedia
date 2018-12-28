﻿using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
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
    }
}
