using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase
    {
        public CharacterDatabase () : this(true) 
        { } //Constructor Chaining to initialize listbox with example data

        public CharacterDatabase ( bool seed ) : this(GetSeedCharacter(seed))
        { }
        
        public CharacterDatabase ( Character[] characters)
        {
            for (var index = 0; index < characters.Length; ++index)
                _character[index] = characters[index];
        }

        public void Add( Character character )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _character[index] = character;
        }

        public void Remove (string name)
        {
            for (var index = 0; index < _character.Length; ++index)
            {
                if (String.Compare(name, _character[index]?.Name, true) == 0) 
                {
                    _character[index] = null;
                    return;
                };
            };
        }

        public void Edit (string name, Character character)
        {
            // Find Character by Name
            Remove(name);
            //Replaces the Character
            Add(character);
        }

        public Character[] GetAllElements()
        {
            var count = 0;
            foreach (var character in _character)
            {
                if (character != null)
                    ++count;
            };

            var temp = new Character[count];
            var index = 0;
            foreach (var character in _character)
            {
                if (character != null)
                    temp[index++] = character;
            };

            return temp;
        }

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _character.Length; ++index)
            {
                if (_character[index] == null)
                    return index;
            };

            return -1;
        }

        private Character[] _character = new Character[100];

        private static Character[] GetSeedCharacter (bool seed)
        {
            if (!seed)
                return new Character[0];

            var character = new Character[1];

            character[0] = new Character();
            character[0].Name = "Exampleron";
            character[0].Profession = "Hunter";
            character[0].Description = "An example of what a character should look like.";
            character[0].Race = "Human";
            character[0].Strength = 50;
            character[0].Intelligence = 50;
            character[0].Agility = 50;
            character[0].Constitution = 50;
            character[0].Charisma = 50;

            return character;
        }
    }
}
