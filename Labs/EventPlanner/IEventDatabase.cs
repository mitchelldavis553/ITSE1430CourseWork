/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;

namespace EventPlanner
{
    /// <summary>Manages the available events.</summary>
    public interface IEventDatabase
    {
        /// <summary>Adds an event to the system.</summary>
        /// <param name="evt">The event to add.</param>
        /// <returns>The added event.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="evt"/> is <see langword="null"/>.</exception>
        /// <exception cref="ValidationException"><paramref name="evt"/> is invalid.</exception>
        /// <exception cref="Exception">An event with the same name already exists.</exception>
        ScheduledEvent Add ( ScheduledEvent evt );

        /// <summary>Gets an event by its ID.</summary>
        /// <param name="id">The event ID.</param>
        /// <returns>The event, if found.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        ScheduledEvent Get ( int id );

        /// <summary>Gets all events that match the given criteria.</summary>
        /// <param name="criteria">The criteria to use.</param>
        /// <returns>The matching events.</returns>
        IEnumerable<ScheduledEvent> GetAll ( EventCriteria criteria );

        /// <summary>Updates an event in the system.</summary>
        /// <param name="id">The event ID.</param>
        /// <param name="evt">The new event information.</param>
        /// <returns>The updated event.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="evt"/> is <see langword="null"/>.</exception>
        /// <exception cref="ValidationException"><paramref name="evt"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        /// <exception cref="Exception">An event with the same name already exists.
        /// <para>-or-</para>
        /// The event cannot be found.
        /// </exception>
        ScheduledEvent Update ( int id, ScheduledEvent evt );

        /// <summary>Removes an event.</summary>
        /// <param name="id">The event to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        void Remove ( int id );
    }
}
