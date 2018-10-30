using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _listContacts.DisplayMember = "Name";
            RefreshContacts();
        }

        private void RefreshContacts()
        {
            
        }

        private void OnFileExit (object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to exit the program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void OnHelpAbout (object sender, EventArgs e)
        {
            MessageBox.Show(this, "Mitchell Davis\n ITSE 1430\n Contact Manager", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnContactAdd (object sender, EventArgs e)
        {
            var form = new ContactForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

        }
    }
}
