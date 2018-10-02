using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
   public class Character
    {
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name;
    }
}
