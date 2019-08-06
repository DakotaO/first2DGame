using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;

namespace Project1.Abilities.Abilities
{
    class Kick : Ability, IOffenseAbility
    {
        public override string Name { get; set; }
        public override int LevelGained { get; set; }
        public override int Cooldown { get; set; }
        public override int CooldownTracker { get; set; }
        public override int Duration { get; set; }
        public override int DurationTracker { get; set; }
        public override bool BIsActive { get; set; }
        public int Damage { get; private set; }
        

        public Kick()
        {
            Name = "Drop Kick";
            Damage = 5;
            Cooldown = 6;
            CooldownTracker = 6;
            LevelGained = 5;
            Duration = 0;
            DurationTracker = 0;
            BIsActive = false;
        }

        public override string useAbility(Player player, Enemy enemy)
        {
            CooldownTracker = 0;
            enemy.StatusCounter = 2;
            enemy.Health -= Damage;
            if (enemy.Health < 0)
            {
                enemy.Health = 0;
            }
            return String.Format("You drop kicked {0} for {1} damage!", enemy.Name, Damage);
        }

        public override void removeEffect(Player player, Enemy enemy)
        {
            
        }

        public override string toString()
        {
            return String.Format("Fly feet first at the enemy\n dealing damage. Damage: {0} Cooldown: {1}", Damage, Cooldown);
        }
    }
}
