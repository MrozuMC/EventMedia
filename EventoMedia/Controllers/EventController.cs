using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EventoMedia.Data.Interfaces;
using EventoMedia.Data.Models;
using EventoMedia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoMedia.Controllers
{
    
    
    public class EventController : Controller
    {
        private readonly IUserEventRepository _userEventRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITagEventRepository _tagEventRepository;
        public EventController(IUserEventRepository userEventRepository, IEventRepository eventRepository, ITagEventRepository tagEventRepository)
        {
            _userEventRepository = userEventRepository;
            _eventRepository = eventRepository;
            _tagEventRepository = tagEventRepository;
        }



        [HttpGet]
        //[Route("Details")]
        public IActionResult Details(int? id)
        {
            //W przyszłości trzba dodać wyświetlanie Photo i Postów oraz dodawanie zdjęć i postów z poziomu Eventu
            var EventDetails = _eventRepository.GetByIdWithAddress(id);
            var MultipleTags = _tagEventRepository.GetTags(id);
            var MultipleUsers = _userEventRepository.GetAllUsers(id);

            if (EventDetails == null)
           {

                return View("Empty");


            }
            else
            {
                var EventDetailVM = new HomeViewModel
                {
                    EventID = EventDetails.EventID,
                    HeadImageURL = EventDetails.HeadImageURL,
                    EventName = EventDetails.EventName,
                    EventDescription = EventDetails.EventDescription,
                    StartDate = EventDetails.StartDate,
                    EndDate = EventDetails.EndDate,
                    NumberofTickets = EventDetails.NumberofTickets,
                    Active = EventDetails.Active,
                    Address = EventDetails.EventAddress.Address,
                    City = EventDetails.EventAddress.City,
                    Tags = MultipleTags.Select(x => new Tagi()
                    {
                        TagID = x.Tag.TagID,
                        TagName = x.Tag.TagName,
                        TagDescription = x.Tag.TagDescription
                    }).ToList(),
                    Users = MultipleUsers.Select(x => new UsersinEvents()
                    {
                        UserID = x.User.Id,
                        Imie = x.User.Imie,
                        Nazwisko = x.User.Nazwisko,
                        Nick = x.User.Nick
                    }).ToList(),
                    OrganiserID = EventDetails.OrganiserRating.User.Id,
                    Imie = EventDetails.OrganiserRating.User.Imie,
                    Nazwisko = EventDetails.OrganiserRating.User.Nazwisko,
                    nick = EventDetails.OrganiserRating.User.Nick,
                    NumberOfVotes = EventDetails.OrganiserRating.NumberOfVotes,
                    Rating = EventDetails.OrganiserRating.AverageRating
                };


                return View(EventDetailVM);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(int id, HomeViewModel HVM, UserEvent UsEv)
        {
            
            string CurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var checkforUsersInEvent = _userEventRepository.FindUserInEvent(CurrentUser, id);
            if (checkforUsersInEvent != null)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {

                UsEv.EventID = id;
                UsEv.UserID = CurrentUser;
                _userEventRepository.Create(UsEv);
                return RedirectToAction("Details", new { id });

            }
        }









    }
}