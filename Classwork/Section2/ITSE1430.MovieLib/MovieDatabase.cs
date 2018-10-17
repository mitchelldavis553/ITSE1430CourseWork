using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class MovieDatabase
    {
        public MovieDatabase() : this(true)
        { }
        private static Movie[] GetSeedMovies( bool seed )
        {
            if (!seed)
                return new Movie[0];

            //Collection Initializer Syntax
            return new[] { // Inferring Array Type and Size, since it is an expression we can return it
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
        }
        public MovieDatabase( bool seed ) : this(GetSeedMovies(seed))
        { }
        public MovieDatabase( Movie[] movies )
        {
            _items.AddRange(movies);
        }
        public void Add( Movie movie )
        {
            _items.Add(movie);
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _items = new List<Movie>();

        public Movie[] GetAll()
        {
            var count = _items.Count;

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _items) // copies the non-null elements into new temp array
            {
                temp[index++] = movie;
            };

            return temp;
        }

        public void Remove( string name )
        {
            var movie = FindMovie(name);
            if (movie != null)
                _items.Remove(movie);
        }

        private Movie FindMovie( string name )
        {
            //var pairs = new Dictionary<string, Movie>();

            foreach (var movie in _items)
            {
                if (String.Compare(name, movie.Name, true) == 0)
                    return movie;
            };

            return null;
        }

        public void Edit( string name, Movie movie )
        {
            //Find movie by name
            Remove(name);

            //Replace it
            Add(movie);
        }
    }

}
