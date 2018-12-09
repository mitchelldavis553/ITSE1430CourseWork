using EventPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDatabase
{
    public static class SeedDatabase
    {
        public static void Seed (this IEventDatabase source) //Couldn't figure out the Singleton so I used our Seed Class from Section 3
        {
            var events = new[]
            {
                new ScheduledEvent()
                {
                    Name = "Christmas Party",
                    StartDate = DateTime.Parse("12/25/2018"),
                    EndDate = DateTime.Parse("12/26/2018"),
                    IsPublic = false,
                },

                new ScheduledEvent()
                {
                    Name = "New Year's Eve Party",
                    StartDate = DateTime.Parse("12/31/2018"),
                    EndDate = DateTime.Parse("01/01/2019"),
                    IsPublic = false,
                },

                new ScheduledEvent()
                {
                    Name = "December 1st",
                    StartDate = DateTime.Parse("12/01/2018"),
                    EndDate = DateTime.Parse("12/02/2018"),
                    IsPublic = true,
                },

                new ScheduledEvent()
                {
                    Name = "December 27th",
                    StartDate = DateTime.Parse("12/27/2018"),
                    EndDate = DateTime.Parse("12/28/2018"),
                    IsPublic = true,
                },
            };

            Seed(source, events);
        }

        public static void Seed (this IEventDatabase source, ScheduledEvent[] events )
        {
            foreach (var seedEvent in events)
                source.Add(seedEvent);
        }
    }
}
