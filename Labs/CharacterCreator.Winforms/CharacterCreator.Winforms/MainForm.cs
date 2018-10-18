using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
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

            _listCharacters.DisplayMember = "Name";
            RefreshCharacters();
        }

        private void OnExit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Mitchell Davis\n ITSE 1430\n Character Creator", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void OnCharacterNew (object sender, EventArgs e)
        {
            var form = new CharacterForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Add(form.Character);
            RefreshCharacters();
        }

        private void RefreshCharacters()
        {
            var characters = _database.GetAllElements();
            _listCharacters.Items.Clear();
            _listCharacters.Items.AddRange(characters);
        }

        private CharacterDatabase _database = new CharacterDatabase();

        private Character GetSelectedCharacter()
        {
            return _listCharacters.SelectedItem as Character;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
