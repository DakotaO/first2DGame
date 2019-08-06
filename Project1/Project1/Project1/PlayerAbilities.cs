using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Abilities;

namespace Project1
{
    class PlayerAbilities
    {
        static List<Ability> _playerAbilities;
        public static List<Ability> AllAbilities
        {
            get
            {
                if (_playerAbilities == null) _playerAbilities = new List<Ability>();
                return _playerAbilities;
            }
        }
    }
}
