using System;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();
        }

        private void OnCancel (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave (object sender, EventArgs e)
        {
            var character = new Character();
        }
    }
}
