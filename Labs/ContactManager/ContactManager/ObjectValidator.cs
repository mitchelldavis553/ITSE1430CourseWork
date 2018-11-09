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
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate ( IValidatableObject value)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            Validator.TryValidateObject(value, context, results, true);

            return results;
        }
    }
}
