using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class MovieDatabase
    {
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
                    temp[index++] = movie;
            };
            return temp;
        }
    }
}
