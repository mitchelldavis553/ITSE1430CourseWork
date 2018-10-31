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
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        public Contact Contact { get; set; }

        private void OnCancel (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave (object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var contact = new Contact()
            {
                Name = _txtName.Text,
                EmailAddress = _txtEmailAddress.Text
            };

            if (MessageBox.Show(this, "Is this contacts' information correct?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Contact = contact;
                DialogResult = DialogResult.OK;
                Close();
            };

        }

        private void OnValidateName (object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required to add Contact");
                e.Cancel = true;
            }
            else
            _errors.SetError(control, "");
        }

        private void OnValidateEmail(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "An Email Address is required to add a contact");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
            
        }
        
    }
}
