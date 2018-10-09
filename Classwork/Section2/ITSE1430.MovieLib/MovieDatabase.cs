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
        private static Movie[] GetSeedMovies( bool seed)
        {
            if (!seed)
                return new Movie[0];

            var movies = new Movie[2];
            movies[0].Name = "Dark Knight";
            movies[0].RunLength = 170;
            movies[0].ReleaseYear = 2015;

            movies[1] = new Movie();
            movies[1].Name = "Harry Potter";
            movies[1].RunLength = 170;
            movies[1].ReleaseYear = 2011;

            return movies;
        }
        public MovieDatabase ( bool seed ) : this (GetSeedMovies(seed)) 
        { }
        public MovieDatabase( Movie[] movies)
        {
            for (var index = 0; index < movies.Length; ++index)
                _movies[index] = movies[index];
        }
        public void Add (Movie movie)
        {
            var index = FindNextFreeIndex();  // returning the index from counter so it could be -1
            if (index >= 0)
                _movies[index] = movie; // putting the data copied into movie into the array element
        }

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _movies.Length; ++index) // Find the closest null element in array
            {
                if (_movies[index] == null)
                    return index;
            };

            return -1;
        }

        private Movie[] _movies = new Movie[100];

        public Movie[] GetAll()
        {
            var count = 0;
            foreach (var movie in _movies) // counts elements that are not null
            {
                if (movie != null)
                    ++count;
            };

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _movies) // copies the non-null elements into new temp array
            {
                if (movie != null)
                    temp[index++] = movie; // sets the temp and post increments it up
            };
            return temp;
        }

        public void Remove (string name)
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (String.Compare(name, _movies[index]?.Name, true) == 0) // third parameter ignores case, comparing names and making it null
                {
                    _movies[index] = null;
                    return;
                };
            };
        }

        public void Edit (string name, Movie movie)
        {
            //Find movie by name
            Remove(name);

            //Replace it
            Add(movie);
        }
    }
}
