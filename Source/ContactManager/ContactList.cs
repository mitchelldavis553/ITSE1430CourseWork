/*
 * ITSE 1430
 * Manages a list of contacts.
 */
using System;
using System.Collections.Generic;
using System.Linq;

using ContactManager.Messaging;

namespace ContactManager
{
    /// <summary>Manages a list of contacts.</summary>
    public class ContactList
    {
        /// <summary>Adds a new contact.</summary>
        /// <param name="contact">The contact to add.</param>        
        /// <returns><see langword="true"/> if successful or <see langword="false"/> if the contact is invalid.</returns>
        public bool Add ( IContact contact )
        {
            if (!Validation.IsValid(contact))
                return false;

            _items.Add(contact);
            return true;
        }

        /// <summary>Determines if a contact already exists.</summary>
        /// <param name="name">The name of the contact.</param>
        /// <returns><see langword="true"/> if they exist or <see langword="false"/> otherwise.</returns>
        public bool Exists ( string name ) => Get(name) != null;

        /// <summary>Gets the contact with the given name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The contact, if any.</returns>
        public IContact Get ( string name )
        {
            if (String.IsNullOrEmpty(name))
                return null;

            return _items.FirstOrDefault(i => String.Compare(i.Name, name, true) == 0);
        }

        /// <summary>Gets all the contacts.</summary>
        /// <returns>The contacts.</returns>
        public IEnumerable<IContact> GetAll () => _items;

        /// <summary>Removes a contact.</summary>
        /// <param name="contact">The contact.</param>
        /// <returns><see langword="true"/> if the contact was removed.</returns>
        public bool Remove ( IContact contact)
        {
            if (_items.Remove(contact))
                return true;

            //Try by name
            var existing = Get(contact.Name);
            if (existing == null)
                return false;

            _items.Remove(existing);
            return true;
        }

        /// <summary>Sends a message to all contacts in the list.</summary>
        /// <param name="service">The service to use.</param>
        /// <param name="message">The message to show.</param>
        public void SendAll ( IMessagingService service, MessageDefinition message )
        {
            foreach (var item in _items)
                item.Send(service, message);
        }
        #region Private Members

        private readonly List<IContact> _items = new List<IContact>();
        #endregion
    }
}
