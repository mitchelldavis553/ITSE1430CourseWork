/*
 * ITSE 1430
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner
{
    /// <summary>Provides some verification methods for arguments.</summary>
    public static class Verify
    {
        /// <summary>Verifies an argument is not <see langword="null"/>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The argument value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        public static void ArgumentIsNotNull<T> ( string name, T value ) where T: class
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>Verifies an argument is not <see langword="null"/> and is valid.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The argument value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ValidationException"><paramref name="value"/> is invalid.</exception>
        public static void ArgumentIsValidAndNotNull ( string name, IValidatableObject value )
        {
            Verify.ArgumentIsNotNull(name, value);

            var context = new ValidationContext(value);
            Validator.ValidateObject(value, context, true);
        }

        /// <summary>Verifies an argument is greater than a specific value.</summary>
        /// <typeparam name="T">The type of argument.</typeparam>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The argument value.</param>
        /// <param name="minimumValue">The value that the argument needs to be greater than.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to <paramref name="minimumValue"/>.</exception>
        public static void ArgumentIsGreaterThan<T> ( string name, T value, T minimumValue ) where T: IComparable<T>
        {
            if (value.CompareTo(minimumValue) <= 0)
                throw new ArgumentOutOfRangeException($"{name} must be greater than {minimumValue}.", name);
        }
    }
}
