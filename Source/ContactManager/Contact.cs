/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ContactManager.Messaging;

namespace ContactManager
{
    /// <summary>Provides a base class for <see cref="IContact"/> implementations.</summary>
    public abstract class Contact : IContact, IValidatableObject
    {
        /// <summary>Gets or sets the name of the contact.</summary>
        public string Name
        {
            get => _name ?? "";
            set => _name = value;
        }

        /// <summary>Sends a message to the contact.</summary>
        /// <param name="service">The messaging service to use.</param>
        /// <param name="message">The message to send.</param>
        public void Send ( IMessagingService service, MessageDefinition message ) => SendCore(service, message);

        /// <summary>Validates the object.</summary>
        /// <param name="validationContext">The context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext ) => ValidateCore();

        #region Protected Members

        /// <summary>Sends a message to the contact.</summary>
        /// <param name="service">The messaging service to use.</param>
        /// <param name="message">The message to send.</param>
        protected abstract void SendCore ( IMessagingService service, MessageDefinition message );

        /// <summary>Validates the object.</summary>
        /// <returns>The validation errors, if any.</returns>
        protected virtual IEnumerable<ValidationResult> ValidateCore ()
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });
        }
        
        #endregion

        #region Private Members

        private string _name;
        #endregion
    }
}
