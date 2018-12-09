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

            Database = db;
        }
        private DatabaseFactory()
        { }

        public static IEventDatabase Database { get; }
    }
}