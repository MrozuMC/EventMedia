using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Interfaces
{
    public interface IOrganiserRatingRepository: IRepository<OrganiserRating>
    {
        OrganiserRating FindCurrentUserInTable(string id);
    }
}
