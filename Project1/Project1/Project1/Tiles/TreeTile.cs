using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class TreeTile : Tile
    {
        public TreeTile() : base()
        {
            TileType = "Tree";
            BIsPassable = false;
        }

        public override char toString()
        {
            return 'T';
        }
    }
}
