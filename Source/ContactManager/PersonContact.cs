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
    /// <summary>Represents a person contact.</summary>
    public class PersonContact : Contact
    {
        /// <summary>Gets or sets the email address of the contact.</summary>
        public string EmailAddress
        {
            get => _email ?? "";
            set => _email = value;
        }

        #region Protected Members

        /// <summary>Sends a message to the contact.</summary>
        /// <param name="service">The messaging service to use.</param>
        /// <param name="message">The message to send.</param>
        protected override void SendCore ( IMessagingService service, MessageDefinition message ) => service.Send(EmailAddress, message);

        /// <summary>Validates the object.</summary>
        /// <returns>The validation errors, if any.</returns>
        protected override IEnumerable<ValidationResult> ValidateCore ()
        {
            var results = base.ValidateCore();
            if (results != null)
                foreach (var result in results)
                    yield return result;

            if (!EmailAddress.IsValidEmail())
                yield return new ValidationResult("Email address is not valid.", new[] { nameof(EmailAddress) });
        }
        #endregion

        #region Private Members

        private string _email;
        #endregion
    }
}
