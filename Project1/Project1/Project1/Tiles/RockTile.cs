using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class RockTile : Tile
    {
        public RockTile() : base()
        {
            TileType = "Rock";
            BIsPassable = false;
        }

        public override char toString()
        {
            return '^';            
        }
    }
}
