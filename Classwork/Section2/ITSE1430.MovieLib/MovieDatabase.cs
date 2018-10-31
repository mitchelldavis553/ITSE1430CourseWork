using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public void Add( Movie movie )
        {
            //Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);
            //TODO: Validate
            //if (movie == null)
                

            AddCore(movie); //implementation I.E. what you'res supposed to add or improve: Re-use functionality with
        }

        protected abstract void AddCore( Movie movie );

        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore();

        public void Remove( string name )
        {
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;

            RemoveCore(name);
        }

        protected abstract void RemoveCore( string name );

        public void Edit( string name, Movie movie )
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            else if (name == "")
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            var existing = FindByName(name);
            if (existing == null)
                throw new Exception("Movie not found.");

            EditCore(existing, movie);
        }

        protected abstract Movie FindByName( string name );
        protected abstract void EditCore( Movie oldMovie, Movie movie );
    }

}
