using EventoMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Models
{
    [NotMapped]
    public class HomeViewModel
    {
        public HomeViewModel(){

            StartDate = DateTime.Today;
            EndDate = StartDate.AddDays(1);
        }
        public int Id { get; set; }
        public int EventID { get; set; }
        public string HeadImageURL { get; set; }
        

        public string EventName { get; set; }
        public string EventDescription { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    
        public int NumberofTickets { get; set; }
        public bool Active { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public List<Tagi> Tags { get; set; }

        public List<UsersinEvents> Users { get; set; }



        //-------------------Organiser Info-------------------------------//
        
        public string OrganiserID { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string nick { get; set; }

        public int NumberOfVotes { get; set; }
        public double Rating { get; set; }
    }
}
