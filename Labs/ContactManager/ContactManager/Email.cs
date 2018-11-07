using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Email : IMessageService,IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Subject))
                yield return new ValidationResult(" A Message is required to send an email.", new[] { nameof(Subject) });
        }
    }
}
