using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
   public class Contact :IValidatableObject
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;

        public string ContactEmailAddress
        {
            get { return _contactEmailAddress ?? ""; }
            set { _contactEmailAddress = value; }
        }
        private string _contactEmailAddress;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });

            if (String.IsNullOrEmpty(ContactEmailAddress))
                yield return new ValidationResult("Email Address is required.", new[] { nameof(Name) });
        }
        //Form for sending an email, implements IMessageService, Object for what an email is, set that object to display on right side of split container on main form
    }
}
