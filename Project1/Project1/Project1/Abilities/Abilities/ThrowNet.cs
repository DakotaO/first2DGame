using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Enemies;

namespace Project1.Abilities.Abilities
{
    class ThrowNet : Ability
    {
        public override string Name { get; set; }
        public override int LevelGained { get; set; }
        public override int Cooldown { get; set; }
        public override int CooldownTracker { get; set; }
        public override int Duration { get; set; }
        public override int DurationTracker { get; set; }
        public override bool BIsActive { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public ThrowNet()
        {
            Name = "Throw Net";
            Cooldown = 6;
            CooldownTracker = 6;
            LevelGained = 7;
            Duration = 3;
            DurationTracker = 3;
            Defense = 3;
            Speed = 3;
            BIsActive = false;
        }

        public override string useAbility(Player player, Enemy enemy)
        {
            CooldownTracker = 0;
            DurationTracker = 0;            
            enemy.Defense -= Defense;
            BIsActive = true;
            if (enemy.Defense < 0)
            {
                enemy.Defense = 0;
            }
            enemy.Speed -= Speed;
            if (enemy.Speed < 0)
            {
                enemy.Speed = 0;
            }
            return String.Format(" You netted {0}!\n Its DEF and SPD is reduced for {1} turns!", enemy.Name, Duration);
        }

        public override void removeEffect(Player player, Enemy enemy)
        {
            enemy.Defense += Defense;
            enemy.Speed += Speed;
        }

        public override string toString()
        {
            return String.Format(" Net the target reducing its DEF and SPD.");
        }
    }
}
