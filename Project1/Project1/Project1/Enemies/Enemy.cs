using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Tiles;
using Project1.Items;


namespace Project1.Enemies
{
    public abstract class Enemy
    {
        
        public abstract int Health { get; set; }                  
        public abstract int Damage { get; set; }
        public abstract int Defense { get; set; } 
        public abstract int Speed { get; set; }   
        public abstract int StatusCounter { get; set; }
        public abstract int ExperienceValue { get; set; }
        public abstract int EnemyRow { get; set; }
        public abstract int EnemyColumn { get; set; }
        public abstract int AggroRange { get; set; }
        public abstract bool BIsAlive { get; set; }
        public abstract bool BIsChasing { get; set; }
        public abstract bool BIsSpawned { get; set; }
        public abstract bool BIsStuned { get; set; }
        public abstract string Type { get; }
        public abstract string Name { get; } 
        public abstract Item Loot { get; set; }     

        public abstract void dropLoot(Map level);
        public abstract void spawnEnemy(Map level);
        public abstract string battleAction(Player player);
        public abstract string battleImage(Player player);    
    }
}
