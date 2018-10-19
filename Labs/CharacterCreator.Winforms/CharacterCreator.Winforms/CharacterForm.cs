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

        private void CharacterForm_Load(object sender, EventArgs e)
        {
            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _txtDescription.Text = Character.Description;
                _professionComboBox.Text = Character.Profession;
                _raceComboBox.Text = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntelligence.Text = Character.Intelligence.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
            }

            ValidateChildren();
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

            var character = new Character();

            character.Name = _txtName.Text;
            character.Description = _txtDescription.Text;
            character.Profession = _professionComboBox.Text;
            character.Race = _raceComboBox.Text;
            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32(TextBox textbox)
        {
            if (String.IsNullOrEmpty(textbox.Text))
                return -1;
            if (Int32.TryParse(textbox.Text, out var value))
                return value;

            return -1;
        }

        private void OnValidateName(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnValidateProfession(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnValidateRace(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnValidateAttributes(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as TextBox;

            var result = GetInt32(control);

            if (result < 0 || result > 100)
            {
                _errors.SetError(control, "Attribute must be <0 and <= 100");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }
    }
}
