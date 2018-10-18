using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
   public class Character
    {
/**************************************************************/
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;
/**************************************************************/
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }
         private string _profession;
/**************************************************************/
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }
        private string _race;
/**************************************************************/
        public int Strength { get; set; } = 50;
        private int _strength;
/**************************************************************/
        public int Intelligence { get; set; } = 50;
        private int _intelligence;
/**************************************************************/
        public int Agility { get; set; } = 50;
        private int _agility;
/**************************************************************/
        public int Constitution { get; set; } = 50;
        private int _constitution;
/**************************************************************/
        public int Charisma { get; set; } = 50;
        private int _charisma;
/**************************************************************/
    }
}
