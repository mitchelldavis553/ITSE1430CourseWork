using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public static class MovieDatabaseExtensions
    {
        public static void Seed( this IMovieDatabase source )
        {
           var movies = new[] { // Inferring Array Type and Size, since it is an expression we can return it
           new Movie()
            {
                Name = "Dark Knight",
                RunLength = 170,
                ReleaseYear = 2015,
            },
            new Movie()
            {
                Name = "Harry Potter",
                RunLength = 170,
                ReleaseYear = 2011,
            },
          };
            Seed(source, movies);
        }

        public static void Seed (this IMovieDatabase source, Movie[] movies)
        {
            foreach (var movie in movies)
            {
                source.Add(movie);
            };
        }
    }
}
