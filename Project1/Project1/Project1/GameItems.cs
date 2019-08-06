using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Items;

namespace Project1
{
    class GameItems
    {
        static List<Item> _ItemsInGame;
            public static List<Item> gameItems 
        {
            get
            {
                if (_ItemsInGame == null) _ItemsInGame = new List<Item>();
                return _ItemsInGame;
            }
        }
    }
}
