using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactDatabase
    {
        private List<Contact> _items = new List<Contact>();
        public void Add(Contact contact)
        {
            if (contact == null)
                return;

            ContactAdd(contact);
        }

        protected void ContactAdd(Contact contact) => _items.Add(contact);

        public bool ExistingContact(Contact contact) => CheckExistingContact(contact);

        protected bool CheckExistingContact(Contact contact)
        {
           foreach (var item in _items)
            {
                if ((contact.Name == item.Name) && (contact.EmailAddress == item.EmailAddress))
                    return true;
            }

            return false;
        }

        protected Contact FindByName( string name )
        {
            return (from c in _items
                    where String.Compare(name, c.Name, true) == 0
                    select c).FirstOrDefault();
        }

        public IEnumerable<Contact> GetAll() => GetAllContacts();

        protected IEnumerable<Contact> GetAllContacts() 
        {
            return from c in _items
                   select new Contact()
                   {
                       Name = c.Name,
                       EmailAddress = c.EmailAddress
                   };
        }
    }
}
