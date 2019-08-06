using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Tiles;
using Project1;

namespace Project1.Items.Armor
{
    class garbageCanLid : Item, IArmor
    {
        public override string Name { get; set; }
        public override string ItemType { get; set; }
        public override int LocationRow { get; set; }
        public override int LocationColumn { get; set; }
        public override int Stat { get; set; }
        public override bool BSpawned { get; set; }
        public override bool BInPlayerInventory { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public int Damage { get; private set; }

        public garbageCanLid()
        {
            Name = "Garbage Can Lid";
            ItemType = "Armor";
            Defense = 2;
            Speed = 0;
            Stat = Defense;
            BSpawned = false;
            BInPlayerInventory = true;
        }

        // World spawn method.
        public override void spawnItem(Map level)
        {
            do
            {
                LocationRow = Game.rand.Next(1, 48);
                LocationColumn = Game.rand.Next(2, 99);
                if (level.map[LocationRow, LocationColumn].BIsPassable == true)
                {
                    level.map[LocationRow, LocationColumn].BHasItem = true;
                    BSpawned = true;
                }
            } while (!BSpawned);
        }

        public override string toString()
        {
            return String.Format("Steel Garbage Can lid.");
        }
    }
}
