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
        public int Strength
        {
            get { return _strength; }
            set {
                if (value <= 100 && value > 0)
                    _strength = value;
                }
        }
        private int _strength;
/**************************************************************/
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value <= 100 && value > 0)
                    _intelligence = value;
            }
        }
        private int _intelligence;
/**************************************************************/
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (value <= 100 && value > 0)
                    _agility = value;
            }
        }
        private int _agility;
/**************************************************************/
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value <= 100 && value > 0)
                    _constitution = value;
            }
        }
        private int _constitution;
/**************************************************************/
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (value <= 100 && value > 0)
                    _charisma = value;
            }
        }
        private int _charisma;
/**************************************************************/
    }
}
