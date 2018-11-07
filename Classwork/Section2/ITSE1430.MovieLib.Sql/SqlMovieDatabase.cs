using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        protected override void AddCore( Movie movie )
        {
            throw new NotImplementedException();
        }

        protected override void EditCore( Movie oldMovie, Movie movie )
        {
            throw new NotImplementedException();
        }

        protected override Movie FindByName( string name )
        {
            throw new NotImplementedException();
        }

        //protected override IEnumerable<Movie> GetAllCore()
        {
            //throw new NotImplementedException();
        }

        protected override void RemoveCore( string name )
        {
            throw new NotImplementedException();
        }
    }
}
