using EventPlanner.Memory;
using EventPlanner.Mvc.App_Start;
using EventPlanner.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
            _database = new MemoryEventDatabase();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult My()
        {
            var criteria = new EventCriteria()
            {
                IncludePrivate = true
            };

            var results = _database.GetAll(criteria);
            return View(results.Select(i => new EventModel(i)));
        }
        private readonly IEventDatabase _database;
    }
}