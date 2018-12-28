using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventoMedia.Models;
using EventoMedia.Data.Interfaces;

namespace EventoMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        


        public HomeController(IEventRepository eventRepository, IEventAddressRepository eventAddressRepository)
        {
            _eventRepository = eventRepository;
            
        }
        public IActionResult Index()
        {
            var EventVM = new List<HomeViewModel>();

            var Events = _eventRepository.GetAllWithAdress();


            if (Events.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var Event in Events)
            {
                EventVM.Add(new HomeViewModel
                {
                    
                    HeadImageURL = Event.HeadImageURL,
                    OrganiserID = Event.OrganiserID,
                    EventName = Event.EventName,
                    StartDate = Event.StartDate,
                    EndDate = Event.EndDate,
                    NumberofTickets = Event.NumberofTickets,
                    Active = Event.Active,
                    Address = Event.EventAddress.Address,
                    City = Event.EventAddress.City
                    

                });
            }
            return View(EventVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
