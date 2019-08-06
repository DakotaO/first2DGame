using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;
using Project1.Items.Consumable;

namespace Project1.Abilities.Abilities
{
    class DrinkEnergyDrink : Ability 
    {
        public override string Name { get; set; }
        public override int LevelGained { get; set; }
        public override int Cooldown { get; set; }
        public override int CooldownTracker { get; set; }
        public override int Duration { get; set; }
        public override int DurationTracker { get; set; }
        public override bool BIsActive { get; set; }

        public DrinkEnergyDrink()
        {
            Name = "Drink Energy Drink";
            Cooldown = 4;
            CooldownTracker = 4;
            LevelGained = 0;
            Duration = 2;
            DurationTracker = 2;
            BIsActive = false;
        }

        public override string useAbility(Player player, Enemy enemy)
        {
            bool used = false;
            foreach (var item in player.Inventory)
            {
                if (item.ItemType.Equals("energyDrink"))
                {
                    CooldownTracker = 0;
                    DurationTracker = 0;
                    BIsActive = true;
                        player.Defense += item.Stat;
                    player.Speed += item.Stat;
                    player.Inventory.Remove(item);
                        used = true;
                    return String.Format(" The {0} made you faster!\n DEF and SPD increased for {1} turns!", item.Name, Duration);
                }   
            }
            if (!used)
            {
                return "You are out of Energy Drinks!";
            }
            else
            {
                return "";
            }                   
        }

        public override void removeEffect(Player player, Enemy enemy)
        {
            EnergyDrink tempDrink = new EnergyDrink();
            player.Defense -= tempDrink.Stat;
            player.Speed -= tempDrink.Stat;
        }
        public override string toString()
        {
            return String.Format("Chug an Energy Drink to increse DEF and SPD for a short time.");
        }
    }
}
