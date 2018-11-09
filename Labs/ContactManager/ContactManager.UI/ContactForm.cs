/*
 * Mitchell Davis
 * ITSE 1430
 * Email Lab
 * 10/27/18
 */
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

        private void ContactForm_Load(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                _txtName.Text = Contact.Name;
                _txtEmailAddress.Text = Contact.ContactEmailAddress;
            }
        }

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
                ContactEmailAddress = _txtEmailAddress.Text
            };

            if (MessageBox.Show(this, "Is this contacts' information correct?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var results = ObjectValidator.Validate(contact);
                foreach ( var result in results)
                {
                    MessageBox.Show(this, result.ErrorMessage, "Validation Failed", MessageBoxButtons.OK);
                    return;
                };
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
            var source = sender as String;
             var result = EmailValidation(source);
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text) && result)
            {
                _errors.SetError(control, "An Email Address is required to add a contact");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
            
        }

        private bool EmailValidation(string source)
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            }
            catch { };

            return false;
        }

       
    }
}
