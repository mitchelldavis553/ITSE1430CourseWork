using System;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public Character Character { get; set; }
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
            character.Race = _raceComboBox.Text;

            Character = character;

        }
    }
}
