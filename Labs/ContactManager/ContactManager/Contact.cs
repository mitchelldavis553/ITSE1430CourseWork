using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
   public class Contact
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;

        public string EmailAddress
        {
            get { return _emailAddress ?? ""; }
            set { _emailAddress = value; }
        }
        private string _emailAddress;
        //Form for sending an email, implements IMessageService, Object for what an email is, set that object to display on right side of split container on main form
    }
}
