using Project1.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project1.Items
{
    public abstract class Item
    {
        public abstract string Name { get; set; }
        public abstract int LocationRow { get; set; }
        public abstract int LocationColumn { get; set; }
        public abstract int Stat { get; set; }
        public abstract string ItemType { get; set; } 
        public abstract bool BSpawned { get; set; }
        public abstract bool BInPlayerInventory { get; set; }
        public abstract void spawnItem(Map map);

        public abstract string toString();  
    }
}