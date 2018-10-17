using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase
    {
        public void Add( Character character )
        {
            var index = FindNextFreeIndex();
            if (index > 0)
                _character[index] = character;
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
    }
}
