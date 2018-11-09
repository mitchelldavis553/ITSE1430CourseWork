/*
 * Mitchell Davis
 * ITSE 1430
 * Email Lab
 * 10/28/18
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Email : IValidatableObject
    {
        public string Message
        {
           get { return _message ?? ""; }
           set { _message = value; }
        }
        private string _message;

        public string Subject
        {
            get { return _subject ?? ""; }
            set { _subject = value; }
        }
        private string _subject;

        public string EmailAddress
        {
            get { return _emailAddress ?? ""; }
            set { _emailAddress = value; }
        }

        private string _emailAddress;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Subject))
                yield return new ValidationResult(" A Message is required to send an email.", new[] { nameof(Subject) });
        }
    }
}
