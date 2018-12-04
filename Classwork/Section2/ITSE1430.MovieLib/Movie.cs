using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    [Description("A movie.")]
    public class Movie :IValidatableObject
    {
        //Property to back the name field
        [Required(AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 1)]
        public string Name
        {
            //get { return _name ?? ""; } // string get ()
            get => _name ?? ""; // converted to lambda expression

            //set { _name = value; } // void set ( string value )
            set => _name = value;
        }
        private string _name;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;

        [Range(1900, 2100, ErrorMessage = "Release Year must be >= 1900.")]
        public int ReleaseYear { get; set; } = 1900; // initializes the backing field to store the data

        //[RangeAttribute(0,Int32.MaxValue), RequiredAttribute] // Multiplie Attributes
        [RangeAttribute(0,Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        public int RunLength { get; set; }

        public bool IsOwned { get; set; }
        
        public int Id { get; set; }

        public bool IsColor => ReleaseYear > 1940;
        //{
        //    //get { return ReleaseYear > 1940;
        //     get => ReleaseYear > 1940;
        //}

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //var results = new List<ValidationResult>();

            //if (String.IsNullOrEmpty(Name))
            //   yield return new ValidationResult("Name is required.", new[] { nameof(Name) });

            //if (ReleaseYear < 1900)
            //    yield return new ValidationResult("Release Year must be >= 1900.", new[] { nameof(ReleaseYear) });

            //if (RunLength < 0)
            //    yield return new ValidationResult("Run Length must be >= 0.", new[] { nameof(RunLength) } );

            yield return null;
        }
    }
}
