/*
 * ITSE 1430
 * Sample implementation
 */
using System;

using ContactManager.Messaging;

namespace ContactManager
{
    /// <summary>Represents a contact.</summary>
    public interface IContact
    {
        /// <summary>Gets or sets the contact name.</summary>
        string Name { get; set; }

        /// <summary>Sends a message to the contact.</summary>
        /// <param name="service">The messaging service to use.</param>
        /// <param name="message">The message to be sent.</param>
        void Send ( IMessagingService service, MessageDefinition message );
    }
}
