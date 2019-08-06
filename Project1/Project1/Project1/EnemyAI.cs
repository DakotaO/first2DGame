using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Tiles;
using Project1.Enemies;

namespace Project1
{
    class EnemyAI
    {
        // Moves Normal enemies if they are not chasing the player
        public void update(Map level, List<Enemy> enemiesOnMap, Player player)
        {
            int direction;
            int chanceToMove;
            foreach (var enemy in enemiesOnMap)
            {
                if (!enemy.BIsChasing && (enemy.Type.Equals("Normal")))
                {
                    chanceToMove = Game.rand.Next(0, 2); // 50% chance to move - 0 move, 1 don't move.
                    if (chanceToMove == 0)
                    {
                        direction = Game.rand.Next(1, 5);  // 1 = north, 2 = south, 3 = east, 4 = west
                        switch (direction)
                        {
                            case 1:
                                if (level.map[enemy.EnemyRow - 1, enemy.EnemyColumn].BIsPassable)
                                {
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                                    level.map[enemy.EnemyRow - 1, enemy.EnemyColumn].BHasEnemy = true;
                                    enemy.EnemyRow -= 1;
                                }
                                break;
                            case 2:
                                if (level.map[enemy.EnemyRow + 1, enemy.EnemyColumn].BIsPassable)
                                {
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                                    level.map[enemy.EnemyRow + 1, enemy.EnemyColumn].BHasEnemy = true;
                                    enemy.EnemyRow += 1;
                                }
                                break;
                            case 3:
                                if (level.map[enemy.EnemyRow, enemy.EnemyColumn + 1].BIsPassable)
                                {
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn + 1].BHasEnemy = true;
                                    enemy.EnemyColumn += 1;
                                }
                                break;
                            case 4:
                                if (level.map[enemy.EnemyRow, enemy.EnemyColumn - 1].BIsPassable)
                                {
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                                    level.map[enemy.EnemyRow, enemy.EnemyColumn - 1].BHasEnemy = true;
                                    enemy.EnemyColumn -= 1;
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        // Checks if the enemy has landed on the player.
        public bool playerCheck(Map level, List<Enemy> enemiesOnMap, Player player)
        {
            if (enemiesOnMap.Count != 0)
            {
                foreach (var enemy in enemiesOnMap)
                {
                    if (player.PlayerRow == enemy.EnemyRow && player.PlayerColumn == enemy.EnemyColumn)
                    {
                        return true;
                    }                    
                    
                }
            }            
            return false;
        }

        // All enemies will chase the player if they are within % 5 % tiles of the player.        
        public void chasePlayer(Map level, List<Enemy> enemiesOnMap, Player player)
        {
            foreach (var enemy in enemiesOnMap)  
            {
                if ((Math.Sqrt((Math.Pow(Math.Abs(player.PlayerRow - enemy.EnemyRow), 2)) + (Math.Pow(Math.Abs(player.PlayerColumn - enemy.EnemyColumn), 2))) < enemy.AggroRange))
                {
                    enemy.BIsChasing = true;
                    // Player is south of enemy
                    if (player.PlayerRow > enemy.EnemyRow)
                    {
                        if (level.map[enemy.EnemyRow + 1, enemy.EnemyColumn].BIsPassable)
                        {
                            level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                            level.map[enemy.EnemyRow + 1, enemy.EnemyColumn].BHasEnemy = true;
                            enemy.EnemyRow += 1;
                        }
                    }
                    // Player is north of enemy
                    else if(player.PlayerRow < enemy.EnemyRow)
                    {
                        if (level.map[enemy.EnemyRow - 1, enemy.EnemyColumn].BIsPassable)
                        {
                            level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                            level.map[enemy.EnemyRow - 1, enemy.EnemyColumn].BHasEnemy = true;
                            enemy.EnemyRow -= 1;
                        }
                    }
                    // Player is West of enemy
                    else if(player.PlayerColumn < enemy.EnemyColumn)
                    {
                        if (level.map[enemy.EnemyRow, enemy.EnemyColumn - 1].BIsPassable)
                        {
                            level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                            level.map[enemy.EnemyRow, enemy.EnemyColumn - 1].BHasEnemy = true;
                            enemy.EnemyColumn -= 1;
                        }
                    }
                    // Player is east of enemy
                    else if (player.PlayerColumn > enemy.EnemyColumn)
                    {
                        if (level.map[enemy.EnemyRow, enemy.EnemyColumn + 1].BIsPassable)
                        {
                            level.map[enemy.EnemyRow, enemy.EnemyColumn].BHasEnemy = false;
                            level.map[enemy.EnemyRow, enemy.EnemyColumn + 1].BHasEnemy = true;
                            enemy.EnemyColumn += 1;
                        }
                    }
                }
                else
                {
                    enemy.BIsChasing = false;
                }
            }
        }
    }

}
