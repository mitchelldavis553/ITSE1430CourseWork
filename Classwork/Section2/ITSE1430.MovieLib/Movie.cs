using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie
    {
        public string Name
        {
            get { return _name ?? ""; } // string get ()
            set { _name = value; } // void set ( string value )
        }
        private string _name;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;

        public int ReleaseYear { get; set; } = 1900; // initialize the backing field
        //{
        //    get { return _releaseYear; }
        //    set
        //    {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}
        //private int _releaseYear = 1900;

        //Auto Property Syntax
        public int RunLength { get; set; }
        //private int _runLength;

        //Both of these are private: Only accessible by this type
        //int someValue;
        //private int someValue2;

        //void Foo()
        //{
            //var x = RunLength;

            //var isLong = x > 100;

            //var y = someValue;
        //}

        public int Id { get; private set; }
        //RESTRICTIONS on Mixed Access
        //************************************
        // Only get one
        //Always be more restrictive
        //************************************

        //Calculated Property
        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }
    }
}
