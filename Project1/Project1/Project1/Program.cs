/*************************************************
* Benjamin Goldsmith - Dakota Oquest - Project 1 *
*************************************************/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Abilities.Abilities;
using Project1.Items.Consumable;
using Project1.Items.Weapons;
using Project1.Items.Armor;


namespace Project1
{   
    class Program
    {
        
        static void Main(string[] args)
        {
            populateAbilities();
            populateItems();
            Game game = new Game();
            game.play();
        }

        public static void populateAbilities()
        {
            
            PlayerAbilities.AllAbilities.Add(new Kick());
            PlayerAbilities.AllAbilities.Add(new ThrowNet());
        }

        public static void populateItems()
        {
            GameItems.gameItems.Add(new garbageCanLid());
            GameItems.gameItems.Add(new steelToeBoots());
            GameItems.gameItems.Add(new thickVest());
            GameItems.gameItems.Add(new _2x4());
            GameItems.gameItems.Add(new bloodyHatchet());
            GameItems.gameItems.Add(new Chainsaw());
            GameItems.gameItems.Add(new Colt());
            GameItems.gameItems.Add(new Rock());
            GameItems.gameItems.Add(new sawOffShotgun());
            GameItems.gameItems.Add(new RustyKitchenKnife());
            GameItems.gameItems.Add(new BeefStick());
            GameItems.gameItems.Add(new EnergyDrink());           
        }
    }
}
