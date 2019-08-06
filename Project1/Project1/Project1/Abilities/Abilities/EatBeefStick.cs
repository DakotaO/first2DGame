using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;
using Project1.Items.Consumable;

namespace Project1.Abilities.Abilities
{
    class EatBeefStick : Ability
    {
        public override string Name { get; set; }
        public override int LevelGained { get; set; }
        public override int Cooldown { get; set; }
        public override int CooldownTracker { get; set; }
        public override int Duration { get; set; }
        public override int DurationTracker { get; set; }
        public override bool BIsActive { get; set; }

        public EatBeefStick()
        {
            Name = "Eat Beef Stick";
            Cooldown = 10;
            CooldownTracker = 10;
            LevelGained = 0;
            Duration = 0;
            DurationTracker = 0;
            BIsActive = false;
        }

        public override string useAbility(Player player, Enemy enemy)
        {
            bool used = false;
            foreach (var item in player.Inventory)
            {
                if (item.ItemType.Equals("beefStick"))
                {
                    CooldownTracker = 0;
                    player.CurrentHealth += item.Stat;
                    player.Inventory.Remove(item);
                    return String.Format(" The {0} curbs your hunger! HP incresed by {1}.", item.Name, item.Stat);
                }
            }
                if (!used)
                {
                    return "You are out of Beef Sticks!";
                }
                else{
                    return "";
                }
        }

        public override void removeEffect(Player player, Enemy enemy)
        {
            
        }

        public override string toString()
        {
            return String.Format("Eat a Beef Stick to gain HP.");
        }
    }
}
