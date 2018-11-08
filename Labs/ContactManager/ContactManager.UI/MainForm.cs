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

        private ContactDatabase _database = new ContactDatabase();

        private void RefreshContacts()
        {
            var contacts = from m in _database.GetAll()
                           orderby m.Name
                           select m;

            _listContacts.Items.Clear();

            _listContacts.Items.AddRange(contacts.ToArray());
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

        private Contact GetSelectedContact() => _listContacts.SelectedItem as Contact;

        private void OnContactAdd (object sender, EventArgs e)
        {
            var form = new ContactForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (_database.ExistingContact(form.Contact))
            {
                MessageBox.Show(this, "Contact already exists", "Duplicate Contact", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                _database.Add(form.Contact);
                RefreshContacts();
            };

        }

        private void OnContactEdit(object sender, EventArgs e) => EditContact();

        private void EditContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new ContactForm();
            form.Text = "Edit Contact";
            form.Contact = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Edit(item.Name, form.Contact);
        }

        private void OnContactDelete(object sender, EventArgs e) => DeleteContact();

        private void DeleteContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to Delete this Contact?\n \t({item.Name})", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _database.Delete(item.Name);
            RefreshContacts();
        }

        private void OnEmailSend(object sender, EventArgs e) => SendEmail();

        private void SendEmail()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new EmailServiceForm();
            form.Contact = item;
            
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;
        }
    }
}
