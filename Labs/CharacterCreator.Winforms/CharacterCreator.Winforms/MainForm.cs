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
            //Looks at what is highlighted in the listbox and returns that item as a Character
            return _listCharacters.SelectedItem as Character;
        }

        private void OnCharacterEdit(object sender, EventArgs e)
        {
            //Event Handler for when user clicks or hotkeys CTRL + O  to call the implementation in another method
            EditCharacter();
        }

        private void EditCharacter()
        {
            //Gets currently selected character, if any
            var item = GetSelectedCharacter();
            if (item == null)
                return;

            var form = new CharacterForm();
            form.Character = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Edit(item.Name, form.Character);
            RefreshCharacters();
        }

        private void OnCharacterDelete(object sender, EventArgs e)
        {
            //Event Handler for when the user click or hotkeys Del to call the implementation in another method
            DeleteCharacter();
        }

        private void DeleteCharacter()
        {
            var item = GetSelectedCharacter();
            if (item == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to Delete this Character? {item.Name}", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;



            _database.Remove(item.Name);
            RefreshCharacters();
        }

        private void OnCharacterDoubleClick(object sender, EventArgs e)
        {
            EditCharacter();
        }

        private void OnListKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteCharacter();
            };
        }
    }
}
