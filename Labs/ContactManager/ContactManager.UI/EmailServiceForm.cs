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
    public partial class EmailServiceForm : Form
    {
        public EmailServiceForm()
        {
            InitializeComponent();
        }

        public Email Email { get; set; }



        private void OnValidatingSubject(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Subject is required to send an email.");
                e.Cancel = true;

            }
        }
    }
}
