﻿using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using ITSE1430.MovieLib.Memory;
using ITSE1430.MovieLib.Sql;

namespace ITSE1430.MovieLib.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?",
                    "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            //aboutToolStripMenuItem.
            MessageBox.Show(this, "Sorry", "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Basic Message Box syntax
        }

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var form = new MovieForm(); // Calls the MovieForm

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //MessageBox.Show("Adding  Movie");
            try
            {
                _database.Add(form.Movie); // Call the database to add the Movie data
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log Failure
                //Crash App
                //throw ex;

                //Rethrow
                //throw;
            };
            //Movie.Name = "";
            RefreshMovies(); // The MainForm Load is only loaded once when it is called. Have to make the data it will update/display available
        }

        private IMovieDatabase _database; //= new SqlMovieDatabase();

        //This method can be overridden in a derived type
        protected virtual void SomeFunction()
        { }

        //This method MUST be overridden in a derived type
        //protected abstract void SomeAbstractFunction();


        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var connString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            _database = new SqlMovieDatabase(connString);

            //Seed database
            //SeedDatabase.Seed(_database);
            //_database.Seed();

            _listMovies.DisplayMember = "Name"; // Setting the Display Member Property to Name property. (When it displays it looks for the name property to display)
            RefreshMovies();
        }



        private void RefreshMovies()
        {
            //OrderBy
            //var movies = _database.GetAll();
            var movies = from m in _database.GetAll()
                         orderby m.Name
                         select m;

            _listMovies.Items.Clear();

            //TODO: Hard Way
            //foreach (var movie in movies)
            //_listMovies.Items.Add(movie);
            _listMovies.Items.AddRange(movies.ToArray());
        }

        private void OnMovieDelete( object sender, EventArgs e )
        {

            DeleteMovie();

        }

        private void DeleteMovie()
        {
            var item = GetSelectedMovie(); // Changing it to type Movie so we can have access to the name functionality
            if (item == null)
                return;
            try
            {
                _database.Remove(item.Name); // Access to name down here through member access
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
            RefreshMovies();
        }

        private void OnMovieEdit( object sender, EventArgs e )
        {

            EditMovie();

        }

        private Movie GetSelectedMovie()
        {
            return _listMovies.SelectedItem as Movie; // Changing it to type Movie so we can have access to the name functionality   
        }

        private void OnMovieDoubleClick( object sender, EventArgs e )
        {
            EditMovie();
        }

        private void EditMovie()
        {
            //get selected movie, if any
            var item = GetSelectedMovie();
            if (item == null)
                return;

            // Show form with selected movie
            var form = new MovieForm();
            form.Movie = item;

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;
            try
            {
                _database.Edit(item.Name, form.Movie); // Call the database to add the Movie data
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };

            RefreshMovies(); // The MainForm Load is only loaded once when it is called. Have to make the data it will update/display available
        }

        private void OnListKeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteMovie();
            };
        }
    }
}
