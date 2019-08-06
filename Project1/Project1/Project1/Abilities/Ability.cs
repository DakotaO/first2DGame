using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;

namespace Project1.Abilities
{
    public abstract class Ability
    {
        public abstract string Name { get; set; }
        public abstract int LevelGained { get; set; }
        public abstract int Cooldown { get; set; }
        public abstract int CooldownTracker { get; set; }
        public abstract int Duration { get; set; }
        public abstract int DurationTracker { get; set; }
        public abstract bool BIsActive { get; set; }


        public abstract void removeEffect(Player player, Enemy enemy);
        public abstract string useAbility(Player player, Enemy enemy);
        public abstract string toString();
    }
}
