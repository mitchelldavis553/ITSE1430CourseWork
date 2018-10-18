using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override void AddCore( Movie movie )
        {
            _items.Add(movie);
        }

        private List<Movie> _items = new List<Movie>();

        protected override Movie[] GetAllCore()
        {
            var count = _items.Count;

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _items) // copies the elements into new temp array
            {
                temp[index++] = movie;
            };

            return temp;
        }

        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie != null)
                _items.Remove(movie);
        }

        protected override Movie FindByName( string name )
        {
            foreach (var movie in _items)
            {
                if (String.Compare(name, movie.Name, true) == 0)
                    return movie;
            };

            return null;
        }

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            //Finding movie by name
            _items.Remove(oldMovie);

            //Replacing it
            _items.Add(newMovie);
        }
    }

}
