﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Tiles;
using Project1.Items;
using Project1.Items.Weapons;


namespace Project1.Enemies
{
    class HulkingZombie : Enemy
    {
        private const string name = "Hulking Zombie";
        private const string type = "Normal";
        private int randomItem;

        public override int Health { get; set; }
        public override int Damage { get; set; }
        public override int Defense { get; set; }
        public override int Speed { get; set; }
        public override int StatusCounter { get; set; }
        public override int ExperienceValue { get; set; }
        public override int EnemyRow { get; set; }
        public override int EnemyColumn { get; set; }
        public override int AggroRange { get; set; }
        public override bool BIsAlive { get; set; }
        public override bool BIsChasing { get; set; }
        public override bool BIsSpawned { get; set; }
        public override bool BIsStuned { get; set; }
        public override Item Loot { get; set; }
        public override string Type
        {
            get
            {
                return type;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }
        }

        public HulkingZombie()
        {
            Health = 35;
            Damage = 6;
            Defense = 0;
            Speed = 5;
            StatusCounter = 0;
            ExperienceValue = 55;
            AggroRange = 5;
            BIsAlive = true;
            BIsSpawned = false;
            BIsChasing = false;
            BIsStuned = false;


            randomItem = Game.rand.Next(0, 10);
            Item thatItem = GameItems.gameItems[randomItem];
            randomItem = Game.rand.Next(10, 12);
            Item thatConsumeable = GameItems.gameItems[randomItem];
            switch (Game.rand.Next(1, 4))
            {
                case 1:
                    Loot = null;
                    break;
                case 2:
                    Loot = null;
                    break;
                case 3:
                    Loot = thatConsumeable;
                    break;
                case 4:
                    Loot = thatItem;
                    break;
            }
        }


        // Spawns the enemy randomly in the world.
        public override void spawnEnemy(Map level)
        {
            do
            {
                EnemyRow = Game.rand.Next(2, 47);
                EnemyColumn = Game.rand.Next(3, 98);
                if (level.map[EnemyRow, EnemyColumn].BIsPassable == true && (level.map[EnemyRow, EnemyColumn].BHasEnemy == false))
                {
                    level.map[EnemyRow, EnemyColumn].BHasEnemy = true;
                    BIsSpawned = true;
                }
            } while (!BIsSpawned);
        }

        public override string battleAction(Player player)
        {
            int chanceToHit = Game.rand.Next(1, 3);
            string result;
            if (BIsStuned)
            {
                StatusCounter--;
                if (StatusCounter == 0)
                {
                    BIsStuned = false;
                }
                return String.Format("{0} is stuned!", Name);
            }
            if (chanceToHit == 1)
            {
                if (player.Defense >= Damage)
                {
                    player.CurrentHealth -= 1;
                    result = String.Format("{0} hit you for 1 damage!", Name);
                    return result;
                }
                else
                {
                    player.CurrentHealth -= Damage - player.Defense;
                    result = String.Format("{0} hit you for {1} damage!", Name, Damage);
                    return result;
                }
            }
            else
            {
                result = String.Format("{0}'s attack missed!", Name);
                return result;
            }
        }

        // Drops the loot at location where enemy dies.
        public override void dropLoot(Map level)
        {
            Game.itemsOnMap.Add(Loot);
            Loot.LocationRow = EnemyRow;
            Loot.LocationColumn = EnemyColumn;
            level.map[EnemyRow, EnemyColumn].BHasItem = true;
        }

        public override string battleImage(Player player)
        {
            string result = "";
            result += String.Format("__________________________________\n");
            result += String.Format("|Player                           |\n");
            result += String.Format("|------                    -0-    |\n");
            result += String.Format("|HP:  {0,3}                 =[]=    |\n", player.CurrentHealth);
            result += String.Format("|DMG: {0,3}                 // \\    |\n", player.Damage);
            result += String.Format("|DEF: {0,3}                         |\n", player.Defense);
            result += String.Format("|                                 |\n");
            result += String.Format("|                         HP:  {0,3}|\n", Health);
            result += String.Format("|    O                    DMG: {0,3}|\n", Damage);
            result += String.Format("|   / \\                   DEF: {0,3}|\n", Defense);
            result += String.Format("|   / \\                  ---------|\n");
            result += String.Format("|                   {0, 10}|\n", Name);
            result += String.Format("|_________________________________|\n");
            return result;
        }
    }
}
