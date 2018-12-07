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
using ContactManager.Messaging;

namespace ContactManager.UI
{
    public partial class SendMessageForm : Form
    {
        #region Construction

        public SendMessageForm ()
        {
            InitializeComponent();
        }
        #endregion
        
        public IContact Contact { get; set; }

        public MessageDefinition Message { get; set; }

        #region Protected Members

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _lblContactName.Text = Contact.Name;

            if (Message != null)
            {
                _txtSubject.Text = Message.Subject;
                _txtMessage.Text = Message.Message;
            };

            ValidateChildren();
        }
        #endregion

        #region Event Handlers

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            Message = new MessageDefinition()
            {
                Subject = _txtSubject.Text,
                Message = _txtMessage.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnValidatingSubject ( object sender, CancelEventArgs e )
        {
            var ctrl = sender as TextBox;

            if (String.IsNullOrEmpty(ctrl.Text))
            {
                _errors.SetError(ctrl, "Subject is required");
                e.Cancel = true;
            } else
                _errors.SetError(ctrl, "");
        }
        #endregion

        #region Private Members
        #endregion
    }
}
