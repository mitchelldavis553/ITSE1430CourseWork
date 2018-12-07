/*
 * ITSE 1430
 * Sample implementation
 */
using System;

namespace ContactManager.Messaging
{
    /// <summary>Defines a message.</summary>
    public class MessageDefinition
    {
        /// <summary>Gets or sets the subject line.</summary>
        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }

        /// <summary>Gets or sets the message to send.</summary>
        public string Message
        {
            get => _message ?? "";
            set => _message = value;
        }

        #region Private Members

        private string _subject, _message;
        #endregion
    }
}
