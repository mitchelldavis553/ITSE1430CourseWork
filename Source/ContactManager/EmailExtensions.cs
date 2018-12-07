/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Net.Mail;

namespace ContactManager
{
    /// <summary>Provides support for working with emails.</summary>
    public static class EmailExtensions
    {
        /// <summary>Determines if the given string is in a valid email format.</summary>
        /// <param name="source">The source.</param>
        /// <returns><see langword="true"/> if valid or <see langword="false"/> otherwise.</returns>
        public static bool IsValidEmail ( this string source )
        {
            try
            {                
                new MailAddress(source);
                return true;
            } catch
            { };

            return false;
        }
    }
}
