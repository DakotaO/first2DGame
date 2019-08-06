using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1.Tiles
{
    public class Map
    {
        public Tile[,] map;
        Random rand = new Random();
        int randX;
        int randY;

        public Map()
        {
            map = new Tile[50, 101];

            //Outer edges
            //North South
            for (int row = 0; row < 50; row++)
            {
                map[row, 0] = new RockTile();
                map[row, 100] = new RockTile();
                map[row, 1] = new RockTile();
                map[row, 99] = new RockTile();
            }
            //East West
            for (int column = 1; column < 101; column++)
            {
                map[0, column] = new RockTile();
                map[49, column] = new RockTile();

            }

            // Initializes all other tiles
            for (int row = 1; row < 49; row++)
            {
                for (int column = 2; column < 99; column++)
                {
                    if (column % 2 == 0)
                    {
                        map[row, column] = new PlainTile();
                    }
                    else
                    {
                        map[row, column] = new GrassTile();
                    }
                }
            }

            //Random Trees
            for (int i = 0; i < 75; i++)
            {
                randX = rand.Next(6, 45);
                randY = rand.Next(6, 95);
                if (map[randX, randY].TileType == "Grass")
                {
                    map[randX, randY] = new TreeTile();
                }
            }

            //Random Rocks
            for (int i = 0; i < 30; i++)
            {
                randX = rand.Next(6, 45);
                randY = rand.Next(6, 87);
                if (map[randX, randY].TileType == "Grass")
                {
                    map[randX, randY] = new RockTile();            
                }
            }

            //Castle
            map[39, 98] = new RockTile();
            map[39, 97] = new RockTile();
            map[39, 96] = new RockTile();
            map[39, 95] = new RockTile();
            map[39, 94] = new RockTile();
            map[39, 90] = new RockTile();
            map[39, 89] = new RockTile();
            map[39, 88] = new RockTile();
            map[39, 87] = new RockTile();
            map[40, 87] = new RockTile();          
            map[41, 87] = new RockTile();
            map[42, 87] = new RockTile();
            map[43, 87] = new RockTile();
            map[44, 87] = new RockTile();
            map[45, 87] = new RockTile();
            map[46, 87] = new RockTile();
            map[47, 87] = new RockTile();
            map[48, 87] = new RockTile();
            

            //Lake
            map[3, 86] = new WaterTile();
            map[3, 87] = new WaterTile();
            map[3, 88] = new WaterTile();
            map[3, 89] = new WaterTile();
            map[3, 90] = new WaterTile();
            map[3, 91] = new WaterTile();
            map[8, 86] = new WaterTile();
            map[8, 87] = new WaterTile();
            map[8, 88] = new WaterTile();
            map[8, 89] = new WaterTile();
            map[8, 90] = new WaterTile();
            map[8, 91] = new WaterTile();
            map[9, 88] = new WaterTile();
            map[9, 89] = new WaterTile();
            map[10, 88] = new WaterTile();
            map[10, 89] = new WaterTile();
            map[11, 88] = new WaterTile();
            map[11, 89] = new WaterTile();
            map[12, 88] = new WaterTile();
            map[12, 89] = new WaterTile();
            map[13, 87] = new WaterTile();
            map[13, 88] = new WaterTile();
            map[14, 87] = new WaterTile();
            map[14, 88] = new WaterTile();
            map[15, 87] = new WaterTile();
            map[15, 88] = new WaterTile();
            map[16, 87] = new WaterTile();
            map[16, 88] = new WaterTile();
            map[17, 88] = new WaterTile();
            map[17, 89] = new WaterTile();
            map[18, 88] = new WaterTile();
            map[18, 89] = new WaterTile();
            map[19, 88] = new WaterTile();
            map[19, 89] = new WaterTile();
            map[20, 89] = new WaterTile();
            map[20, 90] = new WaterTile();
            map[21, 89] = new WaterTile();
            map[21, 90] = new WaterTile();
            map[22, 89] = new WaterTile();
            map[22, 90] = new WaterTile();

            map[23, 88] = new WaterTile();
            map[23, 89] = new WaterTile();
            map[24, 87] = new WaterTile();
            map[24, 88] = new WaterTile();
            map[25, 86] = new WaterTile();
            map[25, 87] = new WaterTile();
            map[26, 86] = new WaterTile();
            map[26, 87] = new WaterTile();
            map[27, 86] = new WaterTile();
            map[27, 87] = new WaterTile();
            map[28, 86] = new WaterTile();
            map[28, 87] = new WaterTile();
            map[29, 86] = new WaterTile();
            map[29, 87] = new WaterTile();

            map[30, 87] = new WaterTile();
            map[30, 88] = new WaterTile();
            map[31, 87] = new WaterTile();
            map[31, 88] = new WaterTile();
            map[32, 87] = new WaterTile();
            map[32, 88] = new WaterTile();

            map[33, 88] = new WaterTile();
            map[33, 89] = new WaterTile();
            map[34, 88] = new WaterTile();
            map[34, 89] = new WaterTile();
            map[35, 88] = new WaterTile();
            map[35, 89] = new WaterTile();

            map[34, 83] = new WaterTile();
            map[34, 84] = new WaterTile();
            map[34, 85] = new WaterTile();
            map[34, 86] = new WaterTile();
            map[34, 87] = new WaterTile();
            map[34, 88] = new WaterTile();
            map[34, 89] = new WaterTile();
            map[34, 90] = new WaterTile();
            map[34, 91] = new WaterTile();
            map[34, 92] = new WaterTile();
            map[34, 93] = new WaterTile();
            map[34, 94] = new WaterTile();
            map[34, 95] = new WaterTile();
            map[34, 96] = new WaterTile();
            map[34, 97] = new WaterTile();
            map[34, 98] = new WaterTile();

            map[35, 84] = new WaterTile();
            map[35, 85] = new WaterTile();
            map[35, 86] = new WaterTile();
            map[35, 87] = new WaterTile();
            map[35, 88] = new WaterTile();
            map[35, 89] = new WaterTile();
            map[35, 90] = new WaterTile();
            map[35, 91] = new WaterTile();
            map[35, 92] = new WaterTile();
            map[35, 93] = new WaterTile();
            map[35, 94] = new WaterTile();
            map[35, 95] = new WaterTile();
            map[35, 96] = new WaterTile();
            map[35, 97] = new WaterTile();
            map[35, 98] = new WaterTile();

            map[36, 82] = new WaterTile();
            map[37, 82] = new WaterTile();
            map[38, 82] = new WaterTile();
            map[39, 82] = new WaterTile();
            map[40, 82] = new WaterTile();
            map[41, 82] = new WaterTile();
            map[42, 82] = new WaterTile();
            map[43, 82] = new WaterTile();
            map[44, 82] = new WaterTile();
            map[45, 82] = new WaterTile();
            map[46, 82] = new WaterTile();
            map[47, 82] = new WaterTile();
            map[48, 82] = new WaterTile();

            map[37, 83] = new WaterTile();
            map[38, 83] = new WaterTile();            
            map[39, 83] = new WaterTile();
            map[40, 83] = new WaterTile();
            map[41, 83] = new WaterTile();
            map[42, 83] = new WaterTile();
            map[43, 83] = new WaterTile();
            map[44, 83] = new WaterTile();
            map[45, 83] = new WaterTile();
            map[46, 83] = new WaterTile();
            map[47, 83] = new WaterTile();
            map[48, 83] = new WaterTile();

            for (int row = 4; row < 8; row++)
            {
                for (int column = 84; column < 94; column++)
                {
                    map[row, column] = new WaterTile();
                }
            }




            //Forest
            map[28, 4] = new TreeTile();
            map[30, 4] = new TreeTile();
            map[32, 4] = new TreeTile();
            map[33, 4] = new TreeTile();
            map[34, 4] = new TreeTile();
            map[35, 4] = new TreeTile();
            map[36, 4] = new TreeTile();
            map[37, 4] = new TreeTile();
            map[38, 4] = new TreeTile();
            map[39, 4] = new TreeTile();
            map[41, 4] = new TreeTile();
            map[42, 4] = new TreeTile();
            map[43, 4] = new TreeTile();
            map[44, 4] = new TreeTile();
            map[46, 4] = new TreeTile();
            map[47, 4] = new TreeTile();          
            map[28, 5] = new TreeTile();
            map[30, 5] = new TreeTile();
            map[39, 5] = new TreeTile();
            map[41, 5] = new TreeTile();
            map[47, 5] = new TreeTile();
            map[28, 6] = new TreeTile();
            map[30, 6] = new TreeTile();
            map[32, 6] = new TreeTile();
            map[33, 6] = new TreeTile();
            map[35, 6] = new TreeTile();
            map[36, 6] = new TreeTile();
            map[37, 6] = new TreeTile();
            map[39, 6] = new TreeTile();
            map[41, 6] = new TreeTile();
            map[43, 6] = new TreeTile();
            map[44, 6] = new TreeTile();
            map[46, 6] = new TreeTile();
            map[47, 6] = new TreeTile();
            map[28, 7] = new TreeTile();
            map[30, 7] = new TreeTile();
            map[33, 7] = new TreeTile();
            map[35, 7] = new TreeTile();
            map[36, 7] = new TreeTile();
            map[37, 7] = new TreeTile();
            map[43, 7] = new TreeTile();
            map[44, 7] = new TreeTile();
            map[46, 7] = new TreeTile();
            map[47, 7] = new TreeTile();
            map[28, 8] = new TreeTile();
            map[30, 8] = new TreeTile();
            map[33, 8] = new TreeTile();
            map[35, 8] = new TreeTile();
            map[37, 8] = new TreeTile();
            map[39, 8] = new TreeTile();
            map[40, 8] = new TreeTile();
            map[41, 8] = new TreeTile();
            map[42, 8] = new TreeTile();
            map[43, 8] = new TreeTile();
            map[44, 8] = new TreeTile();
            map[46, 8] = new TreeTile();
            map[47, 8] = new TreeTile();
            map[25, 9] = new TreeTile();
            map[26, 9] = new TreeTile();
            map[27, 9] = new TreeTile();
            map[28, 9] = new TreeTile();
            map[30, 9] = new TreeTile();
            map[31, 9] = new TreeTile();
            map[33, 9] = new TreeTile();
            map[35, 9] = new TreeTile();
            map[47, 9] = new TreeTile();
            map[33, 10] = new TreeTile();
            map[35, 10] = new TreeTile();
            map[36, 10] = new TreeTile();
            map[37, 10] = new TreeTile();
            map[38, 10] = new TreeTile();
            map[39, 10] = new TreeTile();
            map[40, 10] = new TreeTile();
            map[42, 10] = new TreeTile();
            map[43, 10] = new TreeTile();
            map[44, 10] = new TreeTile();
            map[25, 11] = new TreeTile();
            map[26, 11] = new TreeTile();
            map[27, 11] = new TreeTile();
            map[28, 11] = new TreeTile();
            map[31, 11] = new TreeTile();
            map[33, 11] = new TreeTile();
            map[38, 11] = new TreeTile();
            map[39, 11] = new TreeTile();
            map[40, 11] = new TreeTile();
            map[42, 11] = new TreeTile();
            map[43, 11] = new TreeTile();
            map[44, 11] = new TreeTile();
            map[45, 11] = new TreeTile();
            map[46, 11] = new TreeTile();
            map[47, 11] = new TreeTile();
            map[28, 12] = new TreeTile();
            map[31, 12] = new TreeTile();
            map[34, 12] = new TreeTile();
            map[35, 12] = new TreeTile();
            map[39, 12] = new TreeTile();
            map[40, 12] = new TreeTile();
            map[28, 13] = new TreeTile();
            map[31, 13] = new TreeTile();
            map[35, 13] = new TreeTile();
            map[36, 13] = new TreeTile();
            map[40, 13] = new TreeTile();
            map[43, 13] = new TreeTile();
            map[44, 13] = new TreeTile();
            map[46, 13] = new TreeTile();
            map[47, 13] = new TreeTile();
            map[28, 14] = new TreeTile();
            map[31, 14] = new TreeTile();
            map[32, 14] = new TreeTile();
            map[33, 14] = new TreeTile();
            map[36, 14] = new TreeTile();
            map[37, 14] = new TreeTile();
            map[42, 14] = new TreeTile();
            map[43, 14] = new TreeTile();
            map[44, 14] = new TreeTile();
            map[46, 14] = new TreeTile();
            map[47, 14] = new TreeTile();
            map[28, 15] = new TreeTile();
            map[32, 15] = new TreeTile();
            map[33, 15] = new TreeTile();
            map[37, 15] = new TreeTile();
            map[38, 15] = new TreeTile();
            map[39, 15] = new TreeTile();
            map[40, 15] = new TreeTile();
            map[42, 15] = new TreeTile();
            map[43, 15] = new TreeTile();
            map[46, 15] = new TreeTile();
            map[47, 15] = new TreeTile();
            map[28, 16] = new TreeTile();
            map[32, 16] = new TreeTile();
            map[33, 16] = new TreeTile();
            map[34, 16] = new TreeTile();
            map[28, 17] = new TreeTile();
            map[33, 17] = new TreeTile();
            map[34, 17] = new TreeTile();
            map[37, 17] = new TreeTile();
            map[38, 17] = new TreeTile();
            map[39, 17] = new TreeTile();
            map[40, 17] = new TreeTile();
            map[41, 17] = new TreeTile();
            map[42, 17] = new TreeTile();
            map[43, 17] = new TreeTile();
            map[44, 17] = new TreeTile();
            map[45, 17] = new TreeTile();
            map[46, 17] = new TreeTile();
            map[47, 17] = new TreeTile();
            map[28, 18] = new TreeTile();
            map[29, 18] = new TreeTile();
            map[30, 18] = new TreeTile();
            map[30, 19] = new TreeTile();
            map[34, 19] = new TreeTile();
            map[35, 19] = new TreeTile();
            map[36, 19] = new TreeTile();
            map[37, 19] = new TreeTile();
            map[38, 19] = new TreeTile();
            map[41, 19] = new TreeTile();
            map[42, 19] = new TreeTile();
            map[43, 19] = new TreeTile();
            map[45, 19] = new TreeTile();
            map[46, 19] = new TreeTile();
            map[47, 19] = new TreeTile();
            map[30, 20] = new TreeTile();
            map[35, 20] = new TreeTile();
            map[36, 20] = new TreeTile();
            map[37, 20] = new TreeTile();
            map[38, 20] = new TreeTile();
            map[42, 20] = new TreeTile();
            map[43, 20] = new TreeTile();
            map[45, 20] = new TreeTile();
            map[46, 20] = new TreeTile();
            map[47, 20] = new TreeTile();
            map[30, 21] = new TreeTile();
            map[36, 21] = new TreeTile();
            map[37, 21] = new TreeTile();
            map[38, 21] = new TreeTile();
            map[39, 21] = new TreeTile();
            map[42, 21] = new TreeTile();
            map[43, 21] = new TreeTile();
            map[45, 21] = new TreeTile();
            map[46, 21] = new TreeTile();
            map[47, 21] = new TreeTile();
            map[30, 22] = new TreeTile();
            map[31, 22] = new TreeTile();
            map[32, 22] = new TreeTile();
            map[33, 22] = new TreeTile();
            map[33, 23] = new TreeTile();
            map[34, 23] = new TreeTile();
            map[35, 23] = new TreeTile();
            map[36, 23] = new TreeTile();
            map[37, 23] = new TreeTile();
            map[38, 23] = new TreeTile();
            map[41, 23] = new TreeTile();
            map[42, 23] = new TreeTile();
            map[43, 23] = new TreeTile();
            map[44, 23] = new TreeTile();
            map[45, 23] = new TreeTile();
            map[46, 23] = new TreeTile();
            map[47, 23] = new TreeTile();
            map[43, 24] = new TreeTile();
            map[44, 24] = new TreeTile();
            map[45, 24] = new TreeTile();
            map[46, 24] = new TreeTile();
            map[47, 24] = new TreeTile();




            // House     
            map[27, 78] = new HouseTile();
            map[27, 79] = new HouseTile();
            map[27, 80] = new HouseTile();
            map[28, 78] = new HouseTile();
            map[28, 79] = new PlainTile();
            map[28, 80] = new HouseTile();
            map[28, 81] = new TreeTile();

            //Road
            map[16, 33] = new DirtTile();
            map[17, 33] = new DirtTile();
            map[16, 34] = new DirtTile();
            map[17, 34] = new DirtTile();
            map[15, 34] = new DirtTile();
            map[14, 35] = new DirtTile();
            map[15, 35] = new DirtTile();
            map[16, 35] = new DirtTile();
            map[13, 36] = new DirtTile();
            map[14, 36] = new DirtTile();
            map[15, 36] = new DirtTile();
            map[13, 37] = new DirtTile();
            map[14, 37] = new DirtTile();
            map[13, 38] = new DirtTile();
            map[14, 38] = new DirtTile();
            map[13, 39] = new DirtTile();
            map[14, 39] = new DirtTile();
            map[13, 40] = new DirtTile();
            map[14, 40] = new DirtTile();
            map[13, 41] = new DirtTile();
            map[14, 41] = new DirtTile();
            map[13, 42] = new DirtTile();
            map[14, 42] = new DirtTile();
            map[13, 43] = new DirtTile();
            map[14, 43] = new DirtTile();
            map[13, 44] = new DirtTile();
            map[14, 44] = new DirtTile();
            map[13, 45] = new DirtTile();
            map[14, 45] = new DirtTile();
            map[13, 46] = new DirtTile();
            map[14, 46] = new DirtTile();
            map[13, 47] = new DirtTile();
            map[14, 47] = new DirtTile();
            map[15, 47] = new DirtTile();
            map[14, 48] = new DirtTile();
            map[15, 48] = new DirtTile();
            map[16, 48] = new DirtTile();
            map[15, 49] = new DirtTile();
            map[16, 49] = new DirtTile();
            map[17, 49] = new DirtTile();
            map[18, 49] = new DirtTile();
            map[19, 49] = new DirtTile();
            map[16, 50] = new DirtTile();
            map[17, 50] = new DirtTile();
            map[18, 50] = new DirtTile();
            map[19, 50] = new DirtTile();
            map[20, 50] = new DirtTile();
            map[19, 51] = new DirtTile();
            map[20, 51] = new DirtTile();
            map[21, 51] = new DirtTile();
            map[20, 52] = new DirtTile();
            map[21, 52] = new DirtTile();
            map[20, 53] = new DirtTile();
            map[21, 53] = new DirtTile();
            map[20, 54] = new DirtTile();
            map[21, 54] = new DirtTile();
            map[20, 55] = new DirtTile();
            map[21, 55] = new DirtTile();
            map[20, 56] = new DirtTile();
            map[21, 56] = new DirtTile();
            map[20, 57] = new DirtTile();
            map[21, 57] = new DirtTile();
            map[20, 58] = new DirtTile();
            map[21, 58] = new DirtTile();
            map[20, 59] = new DirtTile();
            map[21, 59] = new DirtTile();
            map[20, 60] = new DirtTile();
            map[21, 60] = new DirtTile();
            map[20, 61] = new DirtTile();
            map[21, 61] = new DirtTile();
            map[22, 61] = new DirtTile();
            map[20, 62] = new DirtTile();
            map[21, 62] = new DirtTile();
            map[22, 62] = new DirtTile();
            map[21, 63] = new DirtTile();
            map[22, 63] = new DirtTile();
            map[23, 63] = new DirtTile();
            map[22, 64] = new DirtTile();
            map[23, 64] = new DirtTile();
            map[24, 64] = new DirtTile();
            map[23, 65] = new DirtTile();
            map[24, 65] = new DirtTile();
            map[25, 65] = new DirtTile();
            map[24, 66] = new DirtTile();
            map[25, 66] = new DirtTile();
            map[26, 66] = new DirtTile();
            map[25, 67] = new DirtTile();
            map[26, 67] = new DirtTile();
            map[25, 68] = new DirtTile();
            map[26, 68] = new DirtTile();
            map[25, 69] = new DirtTile();
            map[26, 69] = new DirtTile();
            map[25, 70] = new DirtTile();
            map[26, 70] = new DirtTile();
            map[25, 71] = new DirtTile();
            map[26, 71] = new DirtTile();
            map[25, 72] = new DirtTile();
            map[26, 72] = new DirtTile();
            map[25, 73] = new DirtTile();
            map[26, 73] = new DirtTile();
            map[25, 74] = new DirtTile();
            map[26, 74] = new DirtTile();
            map[25, 75] = new DirtTile();
            map[26, 75] = new DirtTile();
            map[25, 76] = new DirtTile();
            map[26, 76] = new DirtTile();
            map[25, 77] = new DirtTile();
            map[26, 77] = new DirtTile();
            map[25, 78] = new DirtTile();
            map[26, 78] = new DirtTile();
            map[25, 79] = new DirtTile();
            map[26, 79] = new DirtTile();
            map[25, 80] = new DirtTile();
            map[26, 80] = new DirtTile();
            map[25, 81] = new DirtTile();
            map[26, 81] = new DirtTile();
            map[25, 82] = new DirtTile();
            map[26, 82] = new DirtTile();
            map[25, 83] = new DirtTile();
            map[26, 83] = new DirtTile();
            map[25, 84] = new DirtTile();
            map[26, 84] = new DirtTile();
            map[25, 85] = new DirtTile();
            map[26, 85] = new DirtTile();
            map[26, 86] = new DirtTile();
            map[25, 86] = new DirtTile();
            map[25, 87] = new DirtTile();
            map[26, 87] = new DirtTile();
            map[25, 88] = new DirtTile();
            map[26, 88] = new DirtTile();
            map[25, 89] = new DirtTile();
            map[26, 89] = new DirtTile();
            map[25, 90] = new DirtTile();
            map[26, 90] = new DirtTile();
            map[25, 91] = new DirtTile();
            map[26, 91] = new DirtTile();
            map[27, 74] = new DirtTile();
            map[27, 75] = new DirtTile();
            map[27, 76] = new DirtTile();
            map[28, 75] = new DirtTile();
            map[28, 76] = new DirtTile();
            map[28, 77] = new DirtTile();
            map[29, 76] = new DirtTile();
            map[29, 77] = new DirtTile();
            map[29, 78] = new DirtTile();
            map[30, 77] = new DirtTile();
            map[30, 78] = new DirtTile();
            map[30, 79] = new DirtTile();
            map[31, 78] = new DirtTile();
            map[31, 79] = new DirtTile();
            map[31, 80] = new DirtTile();
            map[32, 79] = new DirtTile();
            map[32, 80] = new DirtTile();
            map[32, 81] = new DirtTile();
            map[33, 80] = new DirtTile();
            map[33, 81] = new DirtTile();
            map[33, 82] = new DirtTile();
            map[34, 81] = new DirtTile();
            map[34, 82] = new DirtTile();
            map[34, 83] = new DirtTile();
            map[35, 82] = new DirtTile();
            map[35, 83] = new DirtTile();
            map[35, 84] = new DirtTile();
            map[36, 83] = new DirtTile();
            map[36, 84] = new DirtTile();
            map[36, 85] = new DirtTile();
            map[37, 84] = new DirtTile();
            map[37, 85] = new DirtTile();
            map[37, 86] = new DirtTile();
            map[37, 87] = new DirtTile();
            map[37, 88] = new DirtTile();
            map[37, 89] = new DirtTile();
            map[37, 90] = new DirtTile();
            map[37, 91] = new DirtTile();
            map[37, 92] = new DirtTile();
            map[37, 93] = new DirtTile();
            map[37, 94] = new DirtTile();
            map[37, 95] = new DirtTile();
            map[37, 96] = new DirtTile();
            map[37, 97] = new DirtTile();
            map[37, 98] = new DirtTile();
            map[38, 85] = new DirtTile();
            map[38, 86] = new DirtTile();
            map[38, 87] = new DirtTile();
            map[38, 88] = new DirtTile();
            map[38, 89] = new DirtTile();
            map[38, 90] = new DirtTile();
            map[38, 91] = new DirtTile();
            map[38, 92] = new DirtTile();
            map[38, 93] = new DirtTile();
            map[38, 94] = new DirtTile();
            map[38, 95] = new DirtTile();
            map[38, 96] = new DirtTile();
            map[38, 97] = new DirtTile();
            map[38, 98] = new DirtTile();
            map[38, 85] = new DirtTile();
            map[39, 85] = new DirtTile();
            map[40, 85] = new DirtTile();
            map[41, 85] = new DirtTile();
            map[42, 85] = new DirtTile();
            map[43, 85] = new DirtTile();
            map[44, 85] = new DirtTile();
            map[45, 85] = new DirtTile();
            map[46, 85] = new DirtTile();
            map[47, 85] = new DirtTile();
            map[48, 85] = new DirtTile();
            map[38, 86] = new DirtTile();
            map[39, 86] = new DirtTile();
            map[40, 86] = new DirtTile();
            map[41, 86] = new DirtTile();
            map[42, 86] = new DirtTile();
            map[43, 86] = new DirtTile();
            map[44, 86] = new DirtTile();
            map[45, 86] = new DirtTile();
            map[46, 86] = new DirtTile();
            map[47, 86] = new DirtTile();
            map[48, 86] = new DirtTile();
            map[38, 91] = new DirtTile();
            map[38, 92] = new DirtTile();
            map[38, 93] = new DirtTile();
            map[39, 91] = new DirtTile();
            map[39, 92] = new DirtTile();
            map[39, 93] = new DirtTile();           
        }
    }
}
