/*
 * ITSE 1430
 * Mitchell Davis
 * Event Planner
 * 12/09/2018
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner
{
    /// <summary>Represents a scheduled event.</summary>
    public class ScheduledEvent : IValidatableObject
    {
        /// <summary>Gets or sets the unique ID.</summary>
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>Gets or sets the unique name.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get => _name ?? "";
            set => _name = value;
        }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get => _description ?? "";
            set => _description = value;
        }

        /// <summary>Gets or sets the start date.</summary>
        public DateTime StartDate { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        public DateTime EndDate { get; set; }

        /// <summary>Determines if this is private or public event.</summary>
        public bool IsPublic { get; set; }

        /// <summary>Validates the instance.</summary>
        /// <param name="validationContext">The context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (EndDate < StartDate)
                yield return new ValidationResult("End date must be greater than or equal to start date.", new[] { nameof(EndDate) });
        }

        #region Private Members

        private string _name, _description;
           
        #endregion
    }
}
