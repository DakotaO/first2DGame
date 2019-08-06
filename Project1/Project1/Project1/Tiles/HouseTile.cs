using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class HouseTile : Tile
    {
        public HouseTile() : base()
        {
            TileType = "House";
            BIsPassable = false;
        }

        public override char toString()
        {
            return '#';
        }
    }
}
