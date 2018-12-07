/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Windows.Forms;

using ContactManager.Messaging;

namespace ContactManager.UI.Messaging
{
    /// <summary>Provides an implementation of <see cref="IMessagingService"/> that writes to a list view.</summary>
    class ListViewMessagingService : IMessagingService
    {
        public ListView Target { get; set; }

        public void Send ( string email, MessageDefinition message )
        {
            var item = new ListViewItem(new[] { email, message.Subject, message.Message });

            Target.Items.Add(item);
        }
    }
}
