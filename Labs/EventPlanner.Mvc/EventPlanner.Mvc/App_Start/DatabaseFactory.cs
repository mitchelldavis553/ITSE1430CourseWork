using EventPlanner.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Mvc.App_Start
{
    public class DatabaseFactory
    {
        static DatabaseFactory()
        {
            var db = new MemoryEventDatabase();

            var seedEvent = new ScheduledEvent()
            { 
                Name = "Christmas",
                Description = "Christmas Day",
                StartDate = DateTime.Parse("12/25/2018"),
                EndDate = DateTime.Parse("12/25/2018"),
                IsPublic = true
            };

            db.Add(seedEvent);

            Database = db;
        }
        private DatabaseFactory()
        { }

        public static IEventDatabase Database { get; }
    }
}