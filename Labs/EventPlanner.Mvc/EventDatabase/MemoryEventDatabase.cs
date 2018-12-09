/*
 * ITSE 1430
 * Mitchell Davis
 * Event Planner
 * 12/08/2018
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlanner.Memory
{
    /// <summary>Provides an implementation of <see cref="IEventDatabase"/> backed by memory.</summary>
    public class MemoryEventDatabase : IEventDatabase
    {
        public MemoryEventDatabase ()
        {
            var privateSeedEvent = new ScheduledEvent()
            {
                Name = "Christmas Party",
                StartDate = DateTime.Parse("12/25/2018"),
                EndDate = DateTime.Parse("12/26/2018"),
                IsPublic = false,
            };
            _items.Add(privateSeedEvent);

            var publicSeedEvent = new ScheduledEvent() //For some reason this Event is broken, couldn't find how to fix it
            {
                Name = "December 27th",
                Description = "The 27th day of December",
                StartDate = DateTime.Parse("12/27/2018"),
                EndDate = DateTime.Parse("12/28/2018"),
                IsPublic = true,
            };
            _items.Add(publicSeedEvent);
        }
        public ScheduledEvent Add ( ScheduledEvent evt )
        {
            Verify.ArgumentIsValidAndNotNull(nameof(evt), evt);

            //An event with the same name cannot exist.
            var existing = FindByName(evt.Name);
            if (existing != null)
                throw new Exception("Event already exists.");

            var newEvt = CloneEvent(evt);
            evt.Id = newEvt.Id = _id++;

            var bug = newEvt.Id;

            _items.Add(newEvt);

            return evt;
        }

        public ScheduledEvent Get ( int id ) => CloneEvent(_items.FirstOrDefault(i => i.Id == id));

        public IEnumerable<ScheduledEvent> GetAll ( EventCriteria criteria )
        {
            if (criteria.IncludePrivate || criteria.IncludePublic)
            {
                IEnumerable<ScheduledEvent> items = _items;
                if (!criteria.IncludePrivate)
                    items = items.Where(i => i.IsPublic);
                if (!criteria.IncludePublic)
                    items = items.Where(i => !i.IsPublic);

                if (criteria.BeginDate.HasValue)
                    items = items.Where(i => i.StartDate >= criteria.BeginDate.Value);
                if (criteria.EndDate.HasValue)
                    items = items.Where(i => i.EndDate <= criteria.EndDate.Value);

                foreach (var item in items)
                    yield return CloneEvent(item);
            };
        }

        public void Remove ( int id )
        {
            Verify.ArgumentIsGreaterThan(nameof(id), id, 0);

            var item = FindById(id, false);
            if (item != null)
                _items.Remove(item);
        }

        public ScheduledEvent Update ( int id, ScheduledEvent evt )
        {
            Verify.ArgumentIsGreaterThan(nameof(id), id, 0);
            var item = FindById(id, true);

            //See if the new event already exists
            var existing = FindByName(evt.Name);
            if (existing != null && existing.Id != id)
                throw new Exception("Event already exists.");

            CopyEvent(item, evt);

            return CloneEvent(item);
        }

        #region Private Members

        private ScheduledEvent CloneEvent ( ScheduledEvent source )
        {
            if (source == null)
                return null;

            var item = new ScheduledEvent();
            CopyEvent(item, source);
            return item;
        }

        private void CopyEvent ( ScheduledEvent target, ScheduledEvent source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.IsPublic = source.IsPublic;
        }

        private ScheduledEvent FindById ( int id, bool throwIfNotExists )
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null && throwIfNotExists)
                throw new Exception("Event not found.");

            return item;
        }

        private ScheduledEvent FindByName ( string name ) => _items.FirstOrDefault(i => String.Compare(i.Name, name, true) == 0);

        private readonly List<ScheduledEvent> _items = new List<ScheduledEvent>();
        private int _id = 1;

        #endregion
    }
}
