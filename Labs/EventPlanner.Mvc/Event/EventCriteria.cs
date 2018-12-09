/*
 * ITSE 1430
 * Mitchell Davis
 * Event Planner
 * 12/09/2018
 */
using System;

namespace EventPlanner
{
    /// <summary>Defines criteria for finding events.</summary>
    public struct EventCriteria
    {
        /// <summary>Determines if public events are included.</summary>
        public bool IncludePublic { get; set; }

        /// <summary>Determines if private events are included.</summary>
        public bool IncludePrivate { get; set; }

        /// <summary>Gets or sets the begin date for events, if any.</summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>Gets or sets the end date for events, if any.</summary>
        public DateTime? EndDate { get; set; }
    }
}
