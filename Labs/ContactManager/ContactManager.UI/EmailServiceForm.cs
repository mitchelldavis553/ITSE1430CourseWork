/*
 * Mitchell Davis
 * ITSE 1430
 * Email Lab
 * 11/03/18
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public Contact Contact { get; set; }

        private void EmailServiceForm_Load(object sender, EventArgs e)
        {
            if (Contact != null )
            {
                _txtContactName.Text = Contact.Name;
                _txtEmailAddress.Text = Contact.ContactEmailAddress;
            }
        }

        private void OnValidatingSubject(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Subject is required to send an email.");
                e.Cancel = true;
            }
        }

        private void OnSend (object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var email = new Email()
            {
                Subject = _txtSubject.Text,
                Message = _txtMessage.Text,
                EmailAddress = _txtEmailAddress.Text
            };

            if (MessageBox.Show(this, "Are you sure you want to send this email?","Email Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var results = ObjectValidator.Validate(email);
                foreach (var result in results)
                {
                    MessageBox.Show(this, result.ErrorMessage, "Validation Failed", MessageBoxButtons.OK);
                    return;
                };
                Email = email;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        private void OnValidateEmail (object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "You must send a Valid Email.");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnValidateSubject (object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "There must be a subject for the email.");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnCancel (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
