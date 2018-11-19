﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using ITSE1430.MovieLib;

namespace PlayWithReflection
{
    class Program
    {
        static void Main( string[] args ) //REFLECTION!!! Deals with metadata around everything
        {
            object instance = new Movie()
            {
                Name = "Jaws",
                ReleaseYear = 1977,
                RunLength = 214
            };

            DisplayMembers(instance);
        }

        static void DisplayMembers(object value)
        {
            var type = value.GetType();
            foreach (var prop in type.GetProperties())
            {
                var propValue = prop.GetValue(value);
                Console.WriteLine($"{prop.PropertyType} {prop.Name} = {propValue}");

                var attrs = prop.GetCustomAttributes(typeof(RequiredAttribute), false);
                var attr = attrs.OfType<RequiredAttribute>().FirstOrDefault();
                if (attr != null)
                    Console.WriteLine(" [Required]");
            };
        }
    }
}
