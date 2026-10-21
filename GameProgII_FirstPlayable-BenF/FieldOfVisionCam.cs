using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameProgII_FirstPlayable_BenF.Player;
using static GameProgII_FirstPlayable_BenF.GameManager;
using static GameProgII_FirstPlayable_BenF.Map;

#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Legacy Project - Camera, Shops, or Quests. Add New Function.
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion

namespace GameProgII_FirstPlayable_BenF
{

    internal class FieldOfVisionCam
    {
        public Map map;
        public int VisionRadius = 6;
        public int mapRows = Map.rows;
        public int mapCols = Map.cols;

        public void FOVcamMask()
        {
            int playerX = GameManager.player._posX;
            int playerY = GameManager.player._posY; 
        
            Console.SetCursorPosition(0, 0);

           
            for (int i = 0; i < mapData.Length; i++)
            {
              
                int tileX = i / mapCols;
                int tileY = i % mapCols;

         
                int distance = Math.Abs(tileX - playerX) + Math.Abs(tileY - playerY);

                if (distance <= VisionRadius)
                {
                  
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                   
                    if (mapData[i] == '^' || mapData[i] == '`' || mapData[i] == '~' || mapData[i] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                       
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                }

                Console.Write(mapData[i]);

                
                if (tileY == mapCols - 1)
                {
                    Console.WriteLine();
                }
            }

        
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}



#region first attempt
//internal class FieldOfVisionCam
//    {
//        //public GameManager gameManager;// initalize game amanager
//       // public Player player;// initalize player
//        public Map map;// initalize map
//        public int VisionRadius = 6;// define raidus around player
//        public int mapX = Map.rows; // creates reference variable based on map row values
//        public int mapY = Map.cols;// creates referench variable based on map columbs


//        public (int, int) camCenter = (GameManager.player._posX, GameManager.player._posX);// sets the virw cam to center on player
//                                                                                           // location



//        public void FOVcamMask()// sets up field of  view that  is displayed as normal , any terraine on the map outside of this
//                                // raidus should display as black masking out  terraine obsticles but leaving goals  enemies and
//                                // borders visible for now 
//        {
//            if ((mapX > (GameManager.player._posX + VisionRadius)) && (mapY > (GameManager.player._posX + VisionRadius)) || (mapX < (GameManager.player._posX - VisionRadius)) && (mapY < (GameManager.player._posX - VisionRadius)))
//            {
//                for (int i = 0; i < mapData.Length; i++)
//                {
//                    if (mapData[i] == '^')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }

//                    if (mapData[i] == '`')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }

//                    if (mapData[i] == '~')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }

//                    if (mapData[i] == '*')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }
//                    Console.Write(mapData[i]);
//                    Console.ForegroundColor = ConsoleColor.White;
//                }
//            }

//            else
//            {
//                map.DisplayMap();
//            }

//        }






//    }
//}
#endregion
