using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate ( IValidatableObject value)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            Validator.TryValidateObject(value, context, results, true);

            return results;
        }

        public static void Validate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
