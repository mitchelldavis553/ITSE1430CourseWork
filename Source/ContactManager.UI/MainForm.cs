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
using ContactManager.UI.Messaging;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _messagingService.Target = _lstMessages;
        }

        #region Event Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnContactAddPerson ( object sender, EventArgs e )
        {
            var form = new PersonContactEditForm();

            do
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(form.Contact))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, "Error adding contact", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnContactDelete ( object sender, EventArgs e ) => DeleteContact();

        private void OnContactEdit ( object sender, EventArgs e ) => EditContact();        

        private void OnContactDoubleClick ( object sender, MouseEventArgs e ) => EditContact();
        
        private void OnContactSend ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            var form = new SendMessageForm();
            form.Contact = contact;

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            contact.Send(_messagingService, form.Message);
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutForm();
            form.ShowDialog(this);
        }
        #endregion

        #region Private Members

        private void DeleteContact ()
        {
            var contact = GetSelectedContact() as IContact;
            if (contact == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete '{contact.Name}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _contacts.Remove(contact);
            UpdateUI();
        }

        private IContact GetSelectedContact () => _lstContacts.SelectedItem as IContact;

        private void EditContact ()
        {
            var contact = GetSelectedContact() as PersonContact;
            if (contact == null)
                return;

            var form = new PersonContactEditForm() { Contact = contact };
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            UpdateUI();
        }

        private void UpdateUI ()
        {
            _lstContacts.Items.Clear();
            _lstContacts.Items.AddRange(_contacts.GetAll().ToArray());
        }

        private readonly ContactList _contacts = new ContactList();
        private readonly ListViewMessagingService _messagingService = new ListViewMessagingService();
        #endregion        
    }
}
