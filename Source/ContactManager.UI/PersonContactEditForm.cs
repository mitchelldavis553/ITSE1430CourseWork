/*
 * ITSE 1430
 * Sample implementation
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
    public partial class PersonContactEditForm : Form
    {
        #region Construction

        public PersonContactEditForm ()
        {
            InitializeComponent();
        }
        #endregion

        public PersonContact Contact { get; set; }

        #region Protected Members

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Contact != null)
            {
                _txtName.Text = Contact.Name;
                _txtEmail.Text = Contact.EmailAddress;
            };
        }
        #endregion

        #region Event Handlers

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            if (Contact == null)
                Contact = new PersonContact();

            var contact = Contact;
            contact.Name = _txtName.Text;
            contact.EmailAddress = _txtEmail.Text;            
                        
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var ctrl = sender as TextBox;
            if (String.IsNullOrEmpty(ctrl.Text))
            {
                _errors.SetError(ctrl, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(ctrl, "");
        }

        private void OnValidatingEmail ( object sender, CancelEventArgs e )
        {
            var ctrl = sender as TextBox;
            if (!ctrl.Text.IsValidEmail())
            {
                _errors.SetError(ctrl, "Email is not in a valid format");
                e.Cancel = true;
            } else
                _errors.SetError(ctrl, "");
        }
        #endregion        
    }
}
