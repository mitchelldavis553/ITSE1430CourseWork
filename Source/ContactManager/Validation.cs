/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ContactManager
{
    /// <summary>Provides validation support.</summary>
    public static class Validation
    {
        /// <summary>Determines if an object is valid.</summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true"/> if valid or <see langword="false"/> otherwise.</returns>
        public static bool IsValid<T> ( T value )
        {
            if (value == null)
                return false;

            var results = new Collection<ValidationResult>();

            return Validator.TryValidateObject(value, new ValidationContext(value), results, true);
        }

        /// <summary>Validates an object.</summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The errors, if any.</returns>
        public static IEnumerable<ValidationResult> Validate<T> ( T value )
        {
            if (value == null)
                yield return null;

            var results = new Collection<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), results, true);
            foreach (var result in results)
                yield return result;
        }
    }
}
