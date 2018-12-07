/*
 * ITSE 1430
 * Sample implementation
 */
using System;

namespace ContactManager.Messaging
{
    /// <summary>Provides a service for sending messages.</summary>
    public interface IMessagingService
    {
        /// <summary>Sends a message.</summary>
        /// <param name="email">The email to send to.</param>
        /// <param name="message">The message to send.</param>
        void Send ( string email, MessageDefinition message );
    }
}
