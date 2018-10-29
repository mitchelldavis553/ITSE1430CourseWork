using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override void AddCore( Movie movie ) => _items.Add(movie);
        //{
        //    _items.Add(movie);
        //}

        private List<Movie> _items = new List<Movie>();

        protected override IEnumerable<Movie> GetAllCore() => _items.Select(Clone);
        //{
        //    return _items.Select(Clone);
            
        //    //var i = _items.ToArray();
        //    //return _items;
        //}

        private Movie Clone ( Movie item)
        {
            return new Movie()
            {
                Name = item.Name,
                Description = item.Description,
                ReleaseYear = item.ReleaseYear,
                RunLength = item.RunLength
            };
        }

        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie != null)
                _items.Remove(movie);
        }

        protected override Movie FindByName( string name )
        {

            //foreach (var movie in _items)
            //{
            //    if (String.Compare(name, movie.Name, true) == 0)
            //        return movie;
            //};

            return _items.FirstOrDefault(m => String.Compare(name, m.Name, true) == 0 ); // Lambda Closure Concept. Compiler creates a helper but needs data in this
        }

        //private bool IsName (Movie movie )
        //{
        //    if (String.Compare(name, movie.Name, true) == 0)
        //        return true;

        //    return false;
        //}

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            //Finding movie by name
            _items.Remove(oldMovie);

            //Replacing it
            _items.Add(newMovie);
        }
    }

}
