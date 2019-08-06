using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Items;
using Project1.Enemies;
using Project1.Abilities;
using Project1.Abilities.Abilities;
using Project1.Tiles;
using Project1.Items.Weapons;

namespace Project1
{
    public class Player
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public int NextLevelXp { get; set; }
        public int NextAbility { get; set; }
        public int InventorySize { get; set; }
        public bool BIsAlive { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Ability> Abilities;
        private int experience;
        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience += value;
            }
        }
        public int PlayerRow { get; set; }
        public int PlayerColumn { get; set; }
        
        public Player()
        {
            Inventory = new List<Item>();
            Abilities = new List<Ability>();
            Abilities.Add(new DrinkEnergyDrink());
            Abilities.Add(new EatBeefStick());
            Inventory.Add(new RustyKitchenKnife());
            InventorySize = 5;
            Damage = 1;
            Damage += Inventory[0].Stat;
            Experience = 0;
            MaxHealth = 20;
            CurrentHealth = MaxHealth;
            Defense = 2;
            Speed = 1;
            Level = 1;
            NextLevelXp = 75;
            NextAbility = 5;
            BIsAlive = true;
           
        }

        // Displays players current stats
        public void displayPlayerStats(ref string outputMessage)
        {
            Console.Clear();
            if (outputMessage != "")
            {
                Console.WriteLine("{0}", outputMessage);
                outputMessage = "";
            }
            Console.WriteLine("   Player Stats");
            Console.WriteLine(" ----------------");
            Console.WriteLine("  Health: {0,3}/{1}", CurrentHealth, MaxHealth);
            Console.WriteLine("  Level:   {0,3}", Level);
            Console.WriteLine("  XP:      {0,3}", Experience);
            Console.WriteLine("  Damage:  {0,3}", Damage);
            Console.WriteLine("  Defense: {0,3}", Defense);
            Console.WriteLine("  Speed:   {0,3}", Speed);
            Console.WriteLine();
            Console.WriteLine("  M   - Return to Menu");
            Console.WriteLine(" Esc  - Return to Map");
        }

        // Displays players current abilities
        public void displayPlayerAbilities(ref string outputMessage)
        {
            Console.Clear();
            
            int count = 1;
            Console.WriteLine("   Abilities");
            Console.WriteLine(" --------------");
            foreach (var ability in Abilities)
            {
                Console.WriteLine(" [ {0}: {1} ]", count, ability.Name);                
                count++;
            }
            if (outputMessage != "")
            {
                Console.WriteLine();
                Console.WriteLine("{0}", outputMessage);
                outputMessage = "";
            }
            Console.WriteLine();
            Console.WriteLine(" Select an ability to see more information.");
            Console.WriteLine("  M   - Return to Menu");
            Console.WriteLine(" Esc  - Return to Map");
        }

        // Displays detailed information on the ability selected
        public void getAbilityInfo(ConsoleKey key, ref string outputMessage)
        {
            outputMessage = Abilities[(char)key - 49].toString();
        }

        // Displays detailed information on the item selected
        public void getItemInfo(ConsoleKey key, ref string outputMessage)
        {
            outputMessage = Inventory[(char)key - 49].toString();
        }

        // Displays inventory
        public void displayInventory(ref string outputMessage)
        {
            Console.Clear();
            int count = 1;
            Console.WriteLine(" Inventory - {0} / {1}", Inventory.Count, InventorySize);
            Console.WriteLine(" ----------------");
            foreach (var Item in Inventory)
            {
                Console.WriteLine("   [ {0}: {1} ]", count, Item.Name);
                count++;
            }
            Console.WriteLine();
            if (outputMessage != "")
            {
                Console.WriteLine(" {0} ", outputMessage);
                outputMessage = "";
                Console.WriteLine();
            }
            Console.WriteLine(" Select an item to see more information.");
            Console.WriteLine("  D  - Drop Item");
            Console.WriteLine("  M  - Return to Menu");
            Console.WriteLine(" Esc - Return to Map");
        }

        public void levelUp()
        {
            Level++;
            MaxHealth += 10;
            CurrentHealth += 10;
            NextLevelXp = NextLevelXp + 50 * Level;
        }

        public void recieveAbility()
        {
            if (PlayerAbilities.AllAbilities.Count == 0)
            {
                return;
            }
            foreach(var ability in PlayerAbilities.AllAbilities)
            {
                if (ability.LevelGained == Level)
                {
                    Abilities.Add(ability);
                    PlayerAbilities.AllAbilities.Remove(ability);
                    NextAbility += 2;
                    if (PlayerAbilities.AllAbilities.Count == 0)
                    {
                        break;
                    }
                    break;
                }
                
            }
        }
        
        public void setPlayerLocation(int row, int column)
        {
            PlayerRow = row;
            PlayerColumn = column;
        }

        public string useAbility(Player player, Enemy enemy, ref bool bAbilityUsed)
        {
            int count = 1;
            foreach (var ability in Abilities)
            {
                if (ability.CooldownTracker != ability.Cooldown)
                {
                    Console.WriteLine(" [ {0}: {1} (available in {2} turns)]", count, ability.Name, (ability.Cooldown - ability.CooldownTracker));
                }
                else
                {
                    Console.WriteLine(" [ {0}: {1} (available)]", count, ability.Name);
                }
                count++;
            }
            Console.Write("Select an ability to use: ");
            Console.WriteLine(" Esc - Cancel Ability");
            do
            {
                Game.playerInput = Console.ReadKey(true);
                if ((Game.playerInput.Key == ConsoleKey.D1) && (Abilities[0].CooldownTracker == Abilities[0].Cooldown))
                {
                    bAbilityUsed = true;
                    return Abilities[0].useAbility(player, enemy);
                }
                else if (Game.playerInput.Key == ConsoleKey.D2 && (player.Abilities.Count > 1) && (Abilities[1].CooldownTracker == Abilities[1].Cooldown))
                {
                    bAbilityUsed = true;
                    return Abilities[1].useAbility(player, enemy);
                }
                else if (Game.playerInput.Key == ConsoleKey.D3 && (player.Abilities.Count > 2) && (Abilities[2].CooldownTracker == Abilities[2].Cooldown))
                {
                    bAbilityUsed = true;
                    return Abilities[2].useAbility(player, enemy);
                }
                else if (Game.playerInput.Key == ConsoleKey.D4 && (player.Abilities.Count > 3) && (Abilities[3].CooldownTracker == Abilities[3].Cooldown))
                {
                    bAbilityUsed = true;
                    return Abilities[3].useAbility(player, enemy);
                }
                else if (Game.playerInput.Key == ConsoleKey.Escape)
                {
                    return "";                    
                }

            } while (true);
        }

        public string battleAction(ConsoleKey key, Enemy enemy, Map level, Player player, ref bool bAbilityUsed)
        {
            int chanceToHit = Game.rand.Next(0, 10);
            string result = ""; 
            
            if (key == ConsoleKey.A)
            {
                if (Abilities.Count != 0)
                {
                    return useAbility(player, enemy, ref bAbilityUsed);
                }
                else
                {
                    result = "You have no abilities yet!";
                }
            }
            
            
            // Press 1 for a Basic Attack
            if (key == ConsoleKey.D1)
            {
                bAbilityUsed = true;
                if (chanceToHit == 0)
                {
                    result = String.Format("Your attack missed!");
                    
                }
                else
                {
                    if (enemy.Defense >= Damage)
                    {
                        enemy.Health -= 1;
                        result = String.Format("You hit {0} for 1 damage!", enemy.Name);
                        
                    }
                    else
                    {
                        enemy.Health -= Damage - enemy.Defense;
                        if (enemy.Health < 0)
                        {
                            enemy.Health = 0;
                        }
                        result = String.Format("You hit {0} for {1} damage!", enemy.Name, Damage);                        
                    }                    
                }
            }
            return result;
        }
    }
}
