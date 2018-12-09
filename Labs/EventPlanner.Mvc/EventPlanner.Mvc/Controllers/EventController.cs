﻿using EventDatabase;
using EventPlanner.Memory;
using EventPlanner.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
            _database = new MemoryEventDatabase();
            _database.Seed();
        }

        [HttpGet]
        public ActionResult My()
        {
            var criteria = new EventCriteria()
            {
                IncludePrivate = true,
                IncludePublic = false,
                BeginDate = DateTime.MinValue,
            };

            var results = _database.GetAll(criteria);
            var filteredEvents = filterResults(results);

            return View(filteredEvents.Select(i => new EventModel(i)));
        }

        [HttpGet]
        public ActionResult Public()
        {
            var criteria = new EventCriteria()
            {
                IncludePrivate = false,
                IncludePublic = true,
                BeginDate = DateTime.MinValue,
            };

            var results = _database.GetAll(criteria);
            var filteredEvents = filterResults(results);

            return View(filteredEvents.Select(i => new EventModel(i)));
        }

       [HttpGet]
        public ActionResult Details(int id)
        {
            var item = _database.Get(id);
            if (item == null)
                return HttpNotFound();

            return View(new EventModel(item));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new EventModel()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create (EventModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();

                    _database.Add(item);

                    if (item.IsPublic == true)
                        return RedirectToAction("Public");
                    if (item.IsPublic == false)
                        return RedirectToAction("My");

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            }

            return View(model);
        }

        private IEnumerable<ScheduledEvent> filterResults(IEnumerable<ScheduledEvent> results)
        {
            return from r in results
                where (DateTime.Compare(r.EndDate, DateTime.Now) > 0) //Making sure past Events can't be seen
                orderby r.StartDate
                select r;
        }

        private readonly IEventDatabase _database;
    }
}