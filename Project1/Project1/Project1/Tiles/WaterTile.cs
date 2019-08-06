using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class WaterTile : Tile
    {
        public WaterTile() : base()
        {
            TileType = "Water";
            BIsPassable = false;
        }

        public override char toString()
        {           
            return '~';            
        }
    }
}
