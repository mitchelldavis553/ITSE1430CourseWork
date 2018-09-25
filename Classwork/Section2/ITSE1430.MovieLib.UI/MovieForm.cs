using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSE1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            var movie = new Movie();

            //Name is required
            movie.Name = _txtName.Text;
            if (String.IsNullOrEmpty(_txtName.Text))
                return;


            movie.Description = _txtDescription.Text;

            //Release year is numeric, if set
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            if (movie.ReleaseYear < 0)
                return;

            //Run Length
            movie.RunLength = GetInt32(_txtRunLength);
            if (movie.RunLength < 0)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }
    }
}
