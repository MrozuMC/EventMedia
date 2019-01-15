using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventoMedia.Models;
using EventoMedia.Data.Interfaces;
using EventoMedia.Data;
using EventoMedia.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EventoMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;

        private readonly ITagEventRepository _tagEventRepository;

        private readonly IUserEventRepository _userEventRepository;

        private readonly IOrganiserRatingRepository _organiserRatingRepository;

        private readonly IEventAddressRepository _eventAddressRepository;

        private readonly ApplicationDbContext _context;

        public HomeController(IEventRepository eventRepository, ITagEventRepository tagEventRepository, IUserEventRepository userEventRepository, IOrganiserRatingRepository organiserRatingRepository, IEventAddressRepository eventAddressRepository, ApplicationDbContext context)
        {
            _eventRepository = eventRepository;

            _tagEventRepository = tagEventRepository;

            _userEventRepository = userEventRepository;

            _organiserRatingRepository = organiserRatingRepository;

            _eventAddressRepository = eventAddressRepository;

            _context = context;
        }
        public IActionResult Index(string searchString)
        {
            var EventVM = new List<HomeViewModel>();
            var GetTagsForEvent = _tagEventRepository.GetTagsForEvent();
            var Events = _eventRepository.GetAllWithAdress();

            if(!String.IsNullOrEmpty(searchString)) {

                Events = Events.Where(e => e.TagEvents.Any(t => t.Tag.TagName.Contains(searchString)));
                  
                
            }

            if (Events.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var Event in Events)
            {
                EventVM.Add(new HomeViewModel
                {
                    EventID = Event.EventID,
                    HeadImageURL = Event.HeadImageURL,
                    OrganiserID = Event.OrganiserRating.User.Imie,
                    EventName = Event.EventName,
                    StartDate = Event.StartDate,
                    EndDate = Event.EndDate,
                    NumberofTickets = Event.NumberofTickets,
                    Active = _eventRepository.CheckForActiveEvent(Event.EventID),
                    Address = Event.EventAddress.Address,
                    City = Event.EventAddress.City,


                });
            }
            return View(EventVM);
        }
       
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var TagsItem = _tagEventRepository.GetTagsToCRUD();
            var test = _context.Tags.Include(x => x.TagEvents).ToList();
            HomeViewModel CreateHomeViewModel = new HomeViewModel
            {
                Tags = test.Select(x => new Tagi()
                {

                    TagID = x.TagID,
                    TagName = x.TagName,
                    TagDescription = x.TagDescription,
                    IsChosen = false
                }).ToList()
            };


            return View(CreateHomeViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(HomeViewModel HVM, Event Ev, EventAddress EvAdd, OrganiserRating OrgRat, TagEvent TagEv)
        {

            string GetUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var FindOrganiserwithID = _organiserRatingRepository.FindCurrentUserInTable(GetUser);
            List<TagEvent> tagsevent = new List<TagEvent>();
            Ev.EventName = HVM.EventName;
            Ev.HeadImageURL = HVM.HeadImageURL;
            Ev.EventDescription = HVM.EventDescription;
            Ev.StartDate = HVM.StartDate;
            Ev.EndDate = HVM.EndDate;
            Ev.NumberofTickets = HVM.NumberofTickets;

            if (HVM.EndDate <= DateTime.Now)
            {
                Ev.Active = false;
            }
            else
            {
                Ev.Active = true;
            }
            if (FindOrganiserwithID != null)
            {

                Ev.OrganiserRating = FindOrganiserwithID;
                
            }
            else 
            {
                OrgRat.UserID = GetUser;
                _organiserRatingRepository.Create(OrgRat);
                Ev.OrganiserRating = OrgRat;
            }
            Ev.EventAddress = EvAdd;
            EvAdd.Address = HVM.Address;
            EvAdd.City = HVM.City;
            _eventAddressRepository.Create(EvAdd);
            _eventRepository.Create(Ev);
            int eventID = Ev.EventID;
            foreach (var item in HVM.Tags)
            {
                if (item.IsChosen == true)
                {
                    tagsevent.Add(new TagEvent() { EventID = eventID, TagID = item.TagID });
                }
            }
            foreach (var item in tagsevent)
            {
                _tagEventRepository.CreateWithoutSave(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {


            string GetUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var EditGetEvent = _eventRepository.GetByIdWithEverything(id);
            if (EditGetEvent.OrganiserRating.UserID != GetUser)
            {
                return View("Empty");
            }

            HomeViewModel EditView = new HomeViewModel();

            var EditGetTags = _context.Tags.Select(vm => new Tagi()
            {
                TagID = vm.TagID,
                TagName = vm.TagName,
                IsChosen = vm.TagEvents.Any(x => x.EventID == EditGetEvent.EventID) ? true : false

            }).ToList();
            EditView.EventID = EditGetEvent.EventID;
            EditView.HeadImageURL = EditGetEvent.HeadImageURL;
            EditView.EventName = EditGetEvent.EventName;
            EditView.EventDescription = EditGetEvent.EventDescription;
            EditView.StartDate = EditGetEvent.StartDate;
            EditView.EndDate = EditGetEvent.EndDate;
            EditView.NumberofTickets = EditGetEvent.NumberofTickets;
            EditView.Address = EditGetEvent.EventAddress.Address;
            EditView.City = EditGetEvent.EventAddress.City;
            EditView.Tags = EditGetTags;
            EditView.OrganiserID = EditGetEvent.OrganiserRating.UserID;
            return View(EditView);
        }
        
        [HttpPost]
        public IActionResult Edit(HomeViewModel HVM, Event Eve, EventAddress EvAdd, TagEvent TagEv)
        {

            
            List<TagEvent> newtags = new List<TagEvent>();
            Eve.EventID = HVM.EventID;
            Eve.EventName = HVM.EventName;
            Eve.HeadImageURL = HVM.HeadImageURL;
            Eve.EventDescription = HVM.EventDescription;
            Eve.StartDate = HVM.StartDate;
            Eve.EndDate = HVM.EndDate;
            Eve.NumberofTickets = HVM.NumberofTickets;
            Eve.OrganiserRating = _organiserRatingRepository.GetAll().FirstOrDefault(x => x.UserID == HVM.OrganiserID);
            EvAdd.Address = HVM.Address;
            EvAdd.City = HVM.City;
            
            if (HVM.EndDate <= DateTime.Now)
            {
                Eve.Active = false;
            }
            else
            {
                Eve.Active = true;
            }
            
             _context.Events.Update(Eve);
             _context.EventAddresses.Update(EvAdd);
             _context.SaveChanges();

            int eventid = Eve.EventID;
            foreach (var item in HVM.Tags)
            {
                if (item.IsChosen == true)
                {
                    newtags.Add(new TagEvent() { EventID = eventid, TagID = item.TagID });
                }

            }
            var databasetable = _tagEventRepository.GetAll().Where(a => a.EventID == eventid).ToList();
            var resultList = databasetable.Except(newtags).ToList();
            foreach (var item in resultList)
            {
                _tagEventRepository.Delete(item);
            }
            var checkforTagsintagsEvent = _tagEventRepository.GetAll().Where(a => a.EventID == eventid).ToList();
            foreach (var item in newtags)
            {
                if (!checkforTagsintagsEvent.Contains(item))
                {
                    _tagEventRepository.Create(item);

                }
            }

            return RedirectToAction("index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {

            string GetUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var EditGetEvent = _eventRepository.GetByIdWithEverything(id);
            if (EditGetEvent.OrganiserRating.UserID != GetUser)
            {
                return View("Empty");
            }

            var EventDetails = _eventRepository.GetByIdWithAddress(id);
            
            var DeleteDetail = new HomeViewModel
            {
                EventName = EventDetails.EventName,
                EventDescription = EventDetails.EventDescription,
                StartDate = EventDetails.StartDate,
                EndDate = EventDetails.EndDate
            };
            return View(DeleteDetail);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(int id)
        {
            var Event = _eventRepository.GetById(id);
            // var Users = _userEventRepository.GetAllUsers(id);
            // var tags = _tagEventRepository.GetTags(id);
            var EventAddress = _eventRepository.GetByIdWithAddress(id).EventAddress;
            if (Event == null)  
            {
                return RedirectToAction("index");
            }

            try
            {
                _context.Events.Remove(Event);
                _context.EventAddresses.Remove(EventAddress);
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {

                return RedirectToAction("Delete", new { id });
            }

          return RedirectToAction("index");

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
