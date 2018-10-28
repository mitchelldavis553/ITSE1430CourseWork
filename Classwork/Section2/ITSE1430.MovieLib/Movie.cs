using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie :IValidatableObject
    {
        public string Name
        {
            get { return _name ?? ""; } // string get ()
            set { _name = value; } // void set ( string value )
        }
        private string _name;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;

        public int ReleaseYear { get; set; } = 1900; // initializes the backing field to store the data
        //{
        //    get { return _releaseYear; }
        //    set
        //    {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}
        //private int _releaseYear = 1900;

        //Auto Property Syntax
        public int RunLength { get; set; }

        public bool IsOwned { get; set; }
        
        public int Id { get; private set; }
        
        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //var results = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Name))
               yield return new ValidationResult("Name is required.", new[] { nameof(Name) });

            if (ReleaseYear < 1900)
                yield return new ValidationResult("Release Year must be >= 1900.", new[] { nameof(ReleaseYear) });

            if (RunLength < 0)
                yield return new ValidationResult("Run Length must be >= 0.", new[] { nameof(RunLength) } );
        }
    }
}
