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

            character.Name = _txtName.Text;

            character.Profession = _professionComboBox.Text;
            if (character.Profession == "")
                MessageBox.Show(this, "Please enter a value for the profession of your character.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            character.Race = _raceComboBox.Text;
            if (character.Race == "")
                MessageBox.Show(this, "Please enter a value for the race of your character.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
