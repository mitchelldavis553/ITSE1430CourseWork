using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Mvc.Models
{
    public class MovieModel
    {
        public MovieModel()
        {
        }
     
        public MovieModel ( ITSE1430.MovieLib.Movie item)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                ReleaseYear = item.ReleaseYear;
                RunLength = item.RunLength;
                IsOwned = item.IsOwned;
            };
        }

        public ITSE1430.MovieLib.Movie ToDomain()
        {
            return new ITSE1430.MovieLib.Movie()
            {
                Name = Name,
                Description = Description,
                ReleaseYear = ReleaseYear,
                RunLength = RunLength,
                IsOwned = IsOwned
            };
        }
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get => _name ?? "";
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
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; } = 1900;

        [RangeAttribute(0, Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        [Display(Name = "Run Length")]
        public int RunLength { get; set; }
        [Display(Name = "Owned")]

        public bool IsOwned { get; set; }

        public int Id { get; private set; }

        public bool IsColor => ReleaseYear > 1940;
    }
}