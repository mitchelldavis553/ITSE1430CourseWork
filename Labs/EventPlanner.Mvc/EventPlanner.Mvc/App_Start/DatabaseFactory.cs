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

            var events = new[]
            {
                new ScheduledEvent()
                {
                    Name = "Christmas Time",
                    Description = "Cold Weather, and conventional family outings.",
                    StartDate = DateTime.Parse("12/01/2018"),
                    EndDate = DateTime.Parse("12/31/2018"),
                    IsPublic = true,
                },
                new ScheduledEvent()
                {
                    Name = "Birthday",
                    Description = "My Birthday",
                    StartDate = DateTime.Parse("04/07/2019"),
                    EndDate = DateTime.Parse("04/07/2019"),
                    IsPublic = false,
                },
            };

            foreach (var value in events)
                db.Add(value);

            Database = db;
        }
        private DatabaseFactory()
        { }

        public static IEventDatabase Database { get; }
    }
}