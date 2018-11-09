/*
 * Mitchell Davis
 * ITSE 1430
 * Email Lab
 * 11/02/18
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactDatabase
    {
        private List<Contact> _contacts = new List<Contact>();
        private List<Email> _emails = new List<Email>();

        public void Add(Email email)
        {
            if (email == null)
                return;

            EmailAdd(email);
        }

        protected void EmailAdd(Email email) => _emails.Add(email);

        public IEnumerable<Email> GetEmails() => GetAllEmails();

        protected IEnumerable<Email> GetAllEmails()
        {
            return from e in _emails
                   select new Email()
                   {
                       EmailAddress = e.EmailAddress,
                       Subject = e.Subject,
                       Message = e.Message
                   };
        }

        public void Add(Contact contact)
        {
            if (contact == null)
                return;

            ContactAdd(contact);
        }

        public void Delete(string name) => DeleteContact(name);

        protected void DeleteContact (string name)
        {
            var contact = FindByName(name);
            if (contact != null)
                _contacts.Remove(contact);
        }

        public void Edit (string name, Contact contact)
        {
            ObjectValidator.Validate(contact);
            var existingContact = FindByName(name);

            EditContact(existingContact, contact);
        }

        protected void EditContact(Contact oldContact, Contact newContact)
        {
            _contacts.Remove(oldContact);

            _contacts.Add(newContact);
        }

        protected void ContactAdd(Contact contact) => _contacts.Add(contact);

        public bool ExistingContact(Contact contact) => CheckExistingContact(contact);

        protected bool CheckExistingContact(Contact contact)
        {
           foreach (var item in _contacts)
            {
                if ((contact.Name == item.Name) && (contact.ContactEmailAddress == item.ContactEmailAddress))
                    return true;
            }

            return false;
        }

        protected Contact FindByName( string name )
        {
            return (from c in _contacts
                    where String.Compare(name, c.Name, true) == 0
                    select c).FirstOrDefault();
        }

        public IEnumerable<Contact> GetAll() => GetAllContacts();

        protected IEnumerable<Contact> GetAllContacts() 
        {
            return from c in _contacts
                   select new Contact()
                   {
                       Name = c.Name,
                       ContactEmailAddress = c.ContactEmailAddress
                   };
        }
    }
}
