using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Items.Weapons;
using Project1.Tiles;
using Project1.Items;
using Project1.Enemies;


namespace Project1
{
    class Game
    {
        public static Random rand = new Random();
        public static ConsoleKeyInfo playerInput;
        public static List<Item> itemsOnMap = new List<Item>();

        public Map level;
        public List<Enemy> enemiesOnMap;
        public EnemyAI enemyAI;
        public Player player;       
        private string mapString;
        private string outputMessage = "";

        private int EnemyCount { get; set; }
  
        //Initializes Game
        public Game()
        {
            level = new Map();
            player = new Player();
            enemyAI = new EnemyAI();
            enemiesOnMap = new List<Enemy>();
            EnemyCount = 0;         
            spawnPlayer();
            spawnBoss();

            // Initial enemy spawn
            for (int spawnCounter = 0; spawnCounter < 12; spawnCounter++)
            {
                enemiesOnMap.Add(new StarvedZombie());
                enemiesOnMap[EnemyCount].spawnEnemy(level);
                EnemyCount++;
            }
            

        }
        
        // Spawns new enemies.
        public void spawnEnemies()
        {
            if ((player.Level == 1 || player.Level == 2) && EnemyCount < 7)
            {
                //spawn 10 enemies.
                for (int spawnCounter = 0; spawnCounter < 10; spawnCounter++)
                {
                    enemiesOnMap.Add(new StarvedZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }

            }
            else if ((player.Level == 3 || player.Level == 4) && EnemyCount < 5)
            {
                //spawn 10 enemies.
                for (int spawnCounter = 0; spawnCounter < 5; spawnCounter++)
                {
                    enemiesOnMap.Add(new ZombiePitbull());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
                for (int spawnCounter = 0; spawnCounter < 5; spawnCounter++)
                {
                    enemiesOnMap.Add(new Zombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
            }
            else if ((player.Level == 5 || player.Level == 6) && EnemyCount < 5)
            {
                //spawn 10 enemies.
                for (int spawnCounter = 0; spawnCounter < 5; spawnCounter++)
                {
                    enemiesOnMap.Add(new SpeedZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
                for (int spawnCounter = 0; spawnCounter < 5; spawnCounter++)
                {
                    enemiesOnMap.Add(new FatZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
            }
            else if ((player.Level == 7 || player.Level == 8) && EnemyCount < 5)
            {
                //spawn 10 enemies.
                for (int spawnCounter = 0; spawnCounter < 6; spawnCounter++)
                {
                    enemiesOnMap.Add(new HulkingZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
                for (int spawnCounter = 0; spawnCounter < 4; spawnCounter++)
                {
                    enemiesOnMap.Add(new FatZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
            }
            else if ((player.Level == 9 || player.Level == 10) && EnemyCount < 5)
            {
                //spawn 10 enemies
                for (int spawnCounter = 0; spawnCounter < 4; spawnCounter++)
                {
                    enemiesOnMap.Add(new Mutant());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
                for (int spawnCounter = 0; spawnCounter < 4; spawnCounter++)
                {
                    enemiesOnMap.Add(new HulkingZombie());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
                for (int spawnCounter = 0; spawnCounter < 2; spawnCounter++)
                {
                    enemiesOnMap.Add(new ZombiePitbull());
                    enemiesOnMap[EnemyCount].spawnEnemy(level);
                    EnemyCount++;
                }
            }

        }

        // Returns the specific enemy that is at the tile where the player is located
        public Enemy getEnemy(int row, int column)
        {
            Enemy NEnemy = new StarvedZombie();
            foreach(var enemy in enemiesOnMap)
            {
                if ((enemy.EnemyRow == row) && (enemy.EnemyColumn == column))
                {
                    return enemy;
                }                                                
            }
            return NEnemy;
        }

        // Returns the specific item that is at the tile where the player is located
        public Item getItem(int row, int column)
        {
            Item fakeItem = new RustyKitchenKnife();
            foreach (var item in itemsOnMap)
            {
                if ((item.LocationRow == row) && (item.LocationColumn == column))
                {
                    return item;
                }
            }
            return fakeItem;
        }

        // Starting tile for player when the game is started.
        public void spawnPlayer()
        {            
            int startingRow = Game.rand.Next(2, 20);
            int startingColumn = Game.rand.Next(2, 20);
            player.setPlayerLocation(startingRow, startingColumn);
            level.map[startingRow, startingColumn].BPlayerOnTile = true;
        }
        // Tile where the boss spawns
        public void spawnBoss()
        {
            enemiesOnMap.Add(new DonaldTrump());
            enemiesOnMap[0].spawnEnemy(level);
            EnemyCount++;
        }
       
        // Begins the game.
        public void play()
        {
            Console.Write("In the year 2018, when Donald Trump began his rein as Communist, the \nappocolypse has begun. Riot's wouldn't stop, so Donald unleashed the zombie \nvirus throughout the slums of America. In his eyes, he is 'Making America \ngreat again', but not in yours. This is the most important quest in American \nHistory. You need to infiltrate the White House, and take that SOB out.\n You are our last hope, so don't let us down! (Press enter to play)");
            Console.ReadLine();
            Console.SetWindowSize(45,23);
            
            
            loadMap();
            while (player.BIsAlive)
            {
                try
                {
                    Console.Clear();                    
                    Console.WriteLine("{0}", mapString);
                    
                    if (outputMessage != "")
                    {
                        Console.WriteLine("{0}", outputMessage);
                        outputMessage = "";
                    }               
                    Console.WriteLine("Move keys: \"W,A,S,D\"");
                    Console.WriteLine("\"M\" - Open Menu");

                    do
                    {
                        playerInput = Console.ReadKey(true);

                        // calls movePlayer() and moves Player if W,A,S,D is pressed
                        if (playerInput.Key == ConsoleKey.W || playerInput.Key == ConsoleKey.A || playerInput.Key == ConsoleKey.S || playerInput.Key == ConsoleKey.D)
                        {
                            movePlayer(playerInput.Key);
                            loadMap();
                            break;
                        }
                        // if M is pressed a Menu of options for the player is opened ie inventory control, player stats, abilities...etc.
                        else if (playerInput.Key == ConsoleKey.M)
                        {
                            openMenu();
                            break;                            
                        }
                    } while (true);
                    

                }
                catch (FormatException)
                {

                }

                //Displays a Win screen if you successfully defeat the boss.
                if (level.map[46, 97].BHasEnemy == false)
                {
                    youWin();
                    Console.Write("You have successfully accomplished what \nwe though was impossible. You've saved\n America from communist reign!! \nNow you're the new President. \nCongratulations!!!!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            //Displays Game Over screen if player quits or dies.
            gameOver();
            Console.ReadLine();
            
        }

        // Opens a menu for the player to choose from a list of options
        public void openMenu()
        {

            Console.Clear();
            Console.WriteLine("       -Menu-");
            Console.WriteLine("---------------------");
            Console.WriteLine("  P   - Player Stats");
            Console.WriteLine("  I   - Inventory ");
            Console.WriteLine("  A   - Abilities ");
            Console.WriteLine("  Q   - Quit Game");
            Console.WriteLine(" Esc  - Return to Map");

            do
            {
                playerInput = Console.ReadKey(true);
                playerAction(playerInput.Key);

                // Q -- Quits the game
                if (playerInput.Key == ConsoleKey.Q)
                {
                    player.BIsAlive = false;
                    break;
                }

                // Esc  -- returns to map
                else if (playerInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (true);            
        }

        //Player Menu actions
        public void playerAction(ConsoleKey key)
        {                        
            // opens inventory if I is pressed
            if (key == ConsoleKey.I)
            {                                       
                player.displayInventory(ref outputMessage);
                do {
                    playerInput = Console.ReadKey(true);

                    if (player.Inventory.Count != 0)
                    {
                        // Checks if the player actually has the ability selected.
                        if (playerInput.Key == ConsoleKey.D1 || ((playerInput.Key == ConsoleKey.D2) && (player.Inventory.Count > 1)) || ((playerInput.Key == ConsoleKey.D3) && (player.Inventory.Count > 2)) || ((playerInput.Key == ConsoleKey.D4) && (player.Inventory.Count > 3)) || ((playerInput.Key == ConsoleKey.D5) && (player.Inventory.Count > 4)))
                        {
                            player.getItemInfo(playerInput.Key, ref outputMessage);
                            player.displayInventory(ref outputMessage);
                            
                        }
                    }
                    // Esc - returns to map
                    if (playerInput.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    // D - attempts to drop an item
                    else if (playerInput.Key == ConsoleKey.D)
                    {
                        Console.Write("Enter Item to drop: ");
                        outputMessage = dropItem(Convert.ToInt32(Console.ReadLine()));
                        player.displayInventory(ref outputMessage);
                    }

                    // M  - return to context menu
                    else if (playerInput.Key == ConsoleKey.M)
                    {
                        openMenu();
                        break;
                    }
                } while(true);                
            }

            // P = Playerstats
            if (key == ConsoleKey.P)
            {              
                player.displayPlayerStats(ref outputMessage);                
                do
                {
                    playerInput = Console.ReadKey(true);

                    // Esc - returns player to Map
                    if (playerInput.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    // M  - returns to context menu
                    else if (playerInput.Key == ConsoleKey.M)
                    {
                        openMenu();
                        break;
                    }
                } while (true);
                
            }

            // A = Abilities
            if (key == ConsoleKey.A)
            {              
                player.displayPlayerAbilities(ref outputMessage);
                do
                {
                    playerInput = Console.ReadKey(true); //initial print
  
                    // Displays detailed information about the ability that is selected.
                    if (player.Abilities.Count !=0)
                    {
                        // Checks if the player actually has the ability selected.
                        if (playerInput.Key == ConsoleKey.D1 || ((playerInput.Key == ConsoleKey.D2) && (player.Abilities.Count > 1)) || ((playerInput.Key == ConsoleKey.D3) && (player.Abilities.Count > 2)) || ((playerInput.Key == ConsoleKey.D4) && (player.Abilities.Count > 3)) || ((playerInput.Key == ConsoleKey.D5) && (player.Abilities.Count > 4)))
                        {
                            player.getAbilityInfo(playerInput.Key, ref outputMessage);
                            player.displayPlayerAbilities(ref outputMessage);  //refreshes the screen
                        }
                    }

                    // M  - returns to context menu
                    if (playerInput.Key == ConsoleKey.M)
                    {
                        openMenu();
                        break;
                    }
                    // Esc - returns player to Map
                    else if (playerInput.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                } while (true);
            }
        }

        

        // Move the player with W,A,S,D if the tile isPassable.
        public void movePlayer(ConsoleKey e)
        {
            //Player movement distance
            int distance = 1;

            switch (e)
            {
                case ConsoleKey.W:
                    if (level.map[player.PlayerRow - distance, player.PlayerColumn].BIsPassable)
                    {
                        level.map[player.PlayerRow, player.PlayerColumn].BPlayerOnTile = false;
                        level.map[player.PlayerRow - distance, player.PlayerColumn].BPlayerOnTile = true;
                        player.PlayerRow -= distance;
                    }
                    break;
                case ConsoleKey.A:
                    if (level.map[player.PlayerRow, player.PlayerColumn - distance].BIsPassable)
                    {
                        level.map[player.PlayerRow, player.PlayerColumn].BPlayerOnTile = false;
                        level.map[player.PlayerRow, player.PlayerColumn - distance].BPlayerOnTile = true;
                        player.PlayerColumn -= distance;
                    }
                    break;
                case ConsoleKey.S:
                    if (level.map[player.PlayerRow + distance, player.PlayerColumn].BIsPassable)
                    {
                        level.map[player.PlayerRow, player.PlayerColumn].BPlayerOnTile = false;
                        level.map[player.PlayerRow + distance, player.PlayerColumn].BPlayerOnTile = true;
                        player.PlayerRow += distance;
                    }
                    break;
                case ConsoleKey.D:
                    if (level.map[player.PlayerRow, player.PlayerColumn + distance].BIsPassable)
                    {
                        level.map[player.PlayerRow, player.PlayerColumn].BPlayerOnTile = false;
                        level.map[player.PlayerRow, player.PlayerColumn + distance].BPlayerOnTile = true;
                        player.PlayerColumn += distance;                                              
                    }
                    break;
                default:
                    break;
            }
            // If tile has an enemy, begin battle
            if (level.map[player.PlayerRow, player.PlayerColumn].BHasEnemy)
            {
                battle(player, getEnemy(player.PlayerRow, player.PlayerColumn));
            }
            //Attempt to Pick up Item
            if (level.map[player.PlayerRow, player.PlayerColumn].BHasItem)
            {
                outputMessage = pickupItem(getItem(player.PlayerRow, player.PlayerColumn));
            }
            
            // Enemies chase the player if they are too close.
            enemyAI.chasePlayer(level, enemiesOnMap, player);
            
            // Move all Normal enemies on the map
            enemyAI.update(level, enemiesOnMap, player);
            
            // If the enemy moves onto the player, begin combat.
            if (enemyAI.playerCheck(level, enemiesOnMap, player))
            {
                battle(player, getEnemy(player.PlayerRow, player.PlayerColumn));
            }
            // Spawn more enemies if enemy count is less than 5
            spawnEnemies();
        }

        // Called if a player steps on a tile with an enemy on it. vice versa.
        public void battle(Player player, Enemy enemy)
        {  
                      
            string battleString;
            do  //While both the enemy and player are alive
            {
                try
                {   
                    foreach(var ability in player.Abilities)
                    {
                        if (ability.CooldownTracker != ability.Cooldown)
                        {
                            ability.CooldownTracker++;
                        }
                        if (ability.DurationTracker != ability.Duration)
                        {
                            ability.DurationTracker++;
                            if (ability.BIsActive && ability.DurationTracker == ability.Duration)
                            {
                                ability.BIsActive = false;
                                ability.removeEffect(player, enemy);
                            }
                        }
                    }                                                  
                    Console.Clear();
                    
                    // Resets battleString to elimenate duplicates on screen                                      
                    battleString = "";

                    // Get BattleImage based on type of enemy we are fighting.
                    battleString += enemy.battleImage(player);                   
                    Console.WriteLine("{0}", battleString);
                    if (outputMessage != "")
                    {
                        Console.WriteLine("{0}", outputMessage);
                        outputMessage = "";

                        // if enemy's health drops to 0, we win, kill enemy.
                        if (enemy.Health <= 0 && player.CurrentHealth > 0)
                        {
                            Console.WriteLine("***    You Won!   ***");                            
                            enemy.BIsAlive = false;
                            EnemyCount--;
                            
                            player.Experience = enemy.ExperienceValue;

                            // If we have gained enough XP we level up.
                            if (player.Experience >= player.NextLevelXp)
                            {
                                player.levelUp();
                                Console.WriteLine("*** You Leveled Up! ***");
                            }
                            if (player.Level == player.NextAbility)
                            {
                                player.recieveAbility();
                                Console.WriteLine("*** You Recieved A New Ability! ***");                             
                            }
                            Console.WriteLine("\n");
                            if (enemy.Loot != null)
                            {
                                //itemsOnMap.Add(enemy.Loot);
                                enemy.dropLoot(level);
                            }
                            level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                            enemiesOnMap.Remove(enemy);
                        }

                        // If our health drops to 0 we die.
                        if (player.CurrentHealth <= 0)
                        {
                            player.BIsAlive = false;                            
                        }
                    }
                    else
                    {
                        Console.WriteLine();                        
                    }

                    // If player and enemy are still alive - FIGHT!
                    if (enemy.Health > 0 && player.CurrentHealth > 0)
                    {
                        Console.WriteLine("  1   - Basic Attack");
                        Console.WriteLine("  A   - Abilities ");
                        bool bAbilityUsed = false;
                        do
                        {
                        //Console.WriteLine("{0}", battleString);
                            
                            playerInput = Console.ReadKey(true);
                            if ((playerInput.Key == ConsoleKey.A && player.Abilities.Count != 0) || playerInput.Key == ConsoleKey.D1)
                            {
                                // If player's speed is more or equal to the enemy, the player gets the first attack each turn.
                                if (player.Speed >= enemy.Speed)
                                {
                                    // Player attack
                                    outputMessage = player.battleAction(playerInput.Key, enemy, level, player, ref bAbilityUsed);
                                    // If enemy does not die from our attack, they get to attack us.
                                    if (enemy.Health > 0 && bAbilityUsed)
                                    {
                                        outputMessage += "\n";
                                        outputMessage += enemy.battleAction(player);
                                    }
                                    break;
                                }

                                // If the enemy's speed is more than ours, the enemy gets the first attack each turn.
                                else if (player.Speed < enemy.Speed && playerInput.Key == ConsoleKey.A)
                                {
                                    outputMessage = player.battleAction(playerInput.Key, enemy, level, player, ref bAbilityUsed);
                                    // If enemy does not die from our attack, they get to attack us.
                                    if (enemy.Health > 0 && bAbilityUsed)
                                    {
                                        outputMessage += "\n";
                                        outputMessage += enemy.battleAction(player);
                                    }
                                    break;
                                }
                                else
                                { 
                                    // Enemy attack
                                    outputMessage = enemy.battleAction(player);
                                    // If we do not die from the enemy attack, we get to attck the enemy.
                                    if (player.CurrentHealth > 0)
                                    {
                                        outputMessage += "\n";
                                        outputMessage += player.battleAction(playerInput.Key, enemy, level, player, ref bAbilityUsed);
                                    }
                                }
                            }
                        } while (!bAbilityUsed);
                    }                    
                }
                catch (FormatException)
                {

                }
            } while (enemy.BIsAlive && player.BIsAlive);

            foreach(var ability in player.Abilities)
            {
                if (ability.CooldownTracker != ability.Cooldown)
                {
                    ability.CooldownTracker = ability.Cooldown;
                }
            }
            // If we are still alive after the battle, we will attempt to pick up anything the enemy dropped.
            if (player.BIsAlive)
            {
                if (enemy.Loot != null)
                {
                    Console.WriteLine("{0}",pickupItem(getItem(player.PlayerRow, player.PlayerColumn)));
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        // When we drop an item we set the tile BHasItem to true and Location of the item to player position.
        public string dropItem(int itemToDrop)
        {
            // Check if players inventory has any items.
            if (player.Inventory.Count == 0)
            {
                return "Your inventory is empty.";
            }
            if (itemToDrop == 1 || ((itemToDrop == 2) && (player.Inventory.Count > 1)) || ((itemToDrop == 3) && (player.Inventory.Count > 2)) || ((itemToDrop == 4) && (player.Inventory.Count > 3)) || ((itemToDrop == 5) && (player.Inventory.Count > 4)))
            {
                // Check if the tile already contains an item, if not place item there.
                // If the tile already contains an item then tell the player they cannot drop here.   
                if (!(level.map[player.PlayerRow, player.PlayerColumn].BHasItem))
                {
                    level.map[player.PlayerRow, player.PlayerColumn].BHasItem = true;
                    player.Inventory[itemToDrop - 1].LocationRow = player.PlayerRow;
                    player.Inventory[itemToDrop - 1].LocationColumn = player.PlayerColumn;

                    // When we drop an item from our inventory, we lose the stat bonus from that item.
                    if (player.Inventory[itemToDrop - 1].ItemType.Equals("Weapon") && player.Inventory[itemToDrop - 1].BInPlayerInventory == true)
                    {
                        player.Damage -= player.Inventory[itemToDrop - 1].Stat;
                    }
                    if (player.Inventory[itemToDrop - 1].ItemType.Equals("Armor") && player.Inventory[itemToDrop - 1].BInPlayerInventory == true)
                    {
                        player.Defense -= player.Inventory[itemToDrop - 1].Stat;
                    }
                    //Add the item back to global map item list.
                    itemsOnMap.Add(player.Inventory[itemToDrop - 1]);
                    player.Inventory[itemToDrop - 1].BInPlayerInventory = false;
                    player.Inventory.Remove(player.Inventory[itemToDrop - 1]);

                    return "Item dropped.";
                }
                else // If the tile already has an item.
                {
                    return "Cannot drop item here.";
                }
            }
            else
            {
                return "";
            }     
        }

        // Attemps to add an item to player Inventory.
        public string pickupItem(Item newItem)
        {
            // Check if the player has room in their inventory
            if (player.Inventory.Count < player.InventorySize)
            {
                //Remove the Item from the Global Inventory          
                itemsOnMap.Remove(newItem);
                level.map[newItem.LocationRow, newItem.LocationColumn].BHasItem = false;
                player.Inventory.Add(newItem);
                newItem.BInPlayerInventory = true;

                // When we aquire an item, we gain a stat based on what item we picked up.
                if (newItem.ItemType.Equals("Weapon") && newItem.BInPlayerInventory == true)
                {
                    player.Damage += newItem.Stat;
                }
                if (newItem.ItemType.Equals("Armor") && newItem.BInPlayerInventory == true)
                {
                    player.Defense += newItem.Stat;
                }

                newItem.LocationRow = 0;
                newItem.LocationColumn = 0;
                return "You've aquired a new item!\nSee your inventory for details.";
            }
            else
            {
                return "Your inventory is full.";
            }
        }
 
        // Displays gameOver message
        public void gameOver()
        {
            Console.Clear();
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|        *************         |");
            Console.WriteLine("|        * GAME OVER *         |");
            Console.WriteLine("|        *************         |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|______________________________|");            
        }

        public void youWin()
        {
            Console.Clear();
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|        *************         |");
            Console.WriteLine("|        * YOU WIN!! *         |");
            Console.WriteLine("|        *************         |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|______________________________|");


        }

        // loads the map to mapString
        public void loadMap()
        {
            mapString = "";

            // Top Left
            if (player.PlayerRow < 9 && player.PlayerColumn < 16)
            {
                for (int row = 0; row < 16; row++)
                {
                    for (int column = 0; column < 30; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }

            }
            // Top Right
            else if (player.PlayerRow < 9 && player.PlayerColumn > 86)
            {
                for (int row = 0; row < 16; row++)
                {
                    for (int column = 71; column < 101; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Bottom right
            else if (player.PlayerRow > 41 && player.PlayerColumn > 86)
            {
                for (int row = 34; row < 50; row++)
                {
                    for (int column = 71; column < 101; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Bottom Left
            else if (player.PlayerRow > 41 && player.PlayerColumn < 16)
            {
                for (int row = 34; row < 50; row++)
                {
                    for (int column = 0; column < 30; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Top Middle
            else if (player.PlayerRow < 9 && player.PlayerColumn >= 16)
            {
                for (int row = 0; row < 16; row++)
                {
                    for (int column = player.PlayerColumn - 15; column < player.PlayerColumn + 15; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Bottom Middle
            else if (player.PlayerRow > 41 && player.PlayerColumn >= 16)
            {
                for (int row = 34; row < 50; row++)
                {
                    for (int column = player.PlayerColumn - 15; column < player.PlayerColumn + 15; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Left Middle
            else if (player.PlayerRow >= 9 && player.PlayerColumn < 16)
            {
                for (int row = player.PlayerRow - 8; row < player.PlayerRow + 8; row++)
                {
                    for (int column = 0; column < 30; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Right Middle
            else if (player.PlayerRow >= 9 && player.PlayerColumn >= 86)
            {
                for (int row = player.PlayerRow - 8; row < player.PlayerRow + 8; row++)
                {
                    for (int column = 71; column < 101; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
            // Center
            else
            {
                for (int row = player.PlayerRow - 8; row < player.PlayerRow + 8; row++)
                {
                    for (int column = player.PlayerColumn - 15; column < player.PlayerColumn + 15; column++)
                    {
                        mapString += level.map[row, column].toString();
                    }
                    mapString += "\n";
                }
            }
        }
    }
}
