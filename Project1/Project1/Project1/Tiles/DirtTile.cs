using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1
{
    class DirtTile : Tile
    {       
        public DirtTile() : base()
        {
            TileType = "Dirt";         
        }

        public override char toString()
        {           
            if (BHasEnemy)
            {
                return Convert.ToChar(165);
            }
            else if (BPlayerOnTile)
            {
                return Convert.ToChar(214);
            }
            else if (BHasItem)
            {
                return '$';
            }
            else
            {   
                return '=';    
            }           
        }
        
    }
}
