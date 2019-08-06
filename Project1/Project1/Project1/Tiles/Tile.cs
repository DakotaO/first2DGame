using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Tile
    {
        public string TileType { get; set; }
        public bool BEmpty { get; set; }
        public bool BHasEnemy { get; set; }  
        public bool BPlayerOnTile { get; set; }  
        public bool BHasItem { get; set; }  
        public bool BIsPassable { get; set; }   

        public Tile()
        {
            BEmpty = false;
            BHasEnemy = false;
            BPlayerOnTile = false;
            BHasItem = false;
            BIsPassable = true;
        }
      
        public virtual char toString()
        {
            return ' ';
        }
    }
}
