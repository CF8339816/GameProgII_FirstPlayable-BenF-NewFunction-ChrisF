using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region coder & project
/// <summary>
/// Original code Ben Franken NSCC Game programming Student
/// 
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Legacy Project - Camera, Shops, or Quests. Add New Function.
/// Coder current script addotions annotated in comments: Chris French Second Year NSCC Game Programming 

/// </summary>
#endregion


namespace GameProgII_FirstPlayable_BenF
{
    internal class Map
    {
        static public string path = @"Files/MapFile.txt";

        static public string mapData = File.ReadAllText(path);
 
        //scale of map
        static public int rows = 89;
        static public int cols = 36;

        public bool[,] isOccupiedMap = new bool[rows, cols];

        public char[,] refMap = new char[rows, cols];

        public Map()
        {

        }

        public void MakeOccupiedMap()
        {
            if (File.Exists(path))
            {
                int lineNum = -1;
                int charNum = -1;

                foreach (string line in File.ReadLines(path))
                {
                    charNum = -1;
                    lineNum++;

                    //Debug.WriteLine(lineNum + " " + line);

                    foreach (char character in line)
                    {
                        charNum++;

                        //Debug.Write(character + " ");

                        if (character == '^')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(^) ");
                        }

                        else if (character == '`')
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False(') ");
                        }

                        else if (character == '~')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(~) ");
                        }

                        else if (character == '*')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(*) ");
                        }

                        else if (character == ' ')
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False() ");
                        }

                        else if (character == '|')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(|) ");
                        }

                        else if (character == '-')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(-) ");
                        }

                        else if (character == '+')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(+) ");
                        }

                        else
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False(else) ");
                        }
                    }
                }
            }

        }


        public void MakeReferenceMap()
        {
            if (File.Exists(path))
            {
                int lineNum = -1;
                int charNum = -1;

                foreach (string line in File.ReadLines(path))
                {
                    charNum = -1;
                    lineNum++;



                    foreach (char character in line)
                    {
                        charNum++;

                        //Debug.Write(character + " ");

                        if (character == '^')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '`')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '~')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '*')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == ' ')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '|')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '-')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '+')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else
                        {
                            refMap[charNum, lineNum] = character;

                        }
                    }
                }
            }

        }


        public void DisplayMap()
        {
            //Debug.WriteLine(mapData.Length);

            if (File.Exists(path))
            {
                for (int i = 0; i < mapData.Length; i++)
                {
                    if (mapData[i] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    if (mapData[i] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    if (mapData[i] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    if (mapData[i] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(mapData[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(" ");
               
            }
        }

        public void DisplayMapWithFOV(int playerX, int playerY, int visionRadius = 2)// adding the field of vision to the map display - CF
        {
            if (Console.WindowHeight < cols || Console.WindowWidth < rows) return;// prevents render glitching -cf

            Console.SetCursorPosition(0, 0);

          // int radiusSquared = visionRadius * visionRadius;// calculate raidius squared for circular fov masking - CF
            for (int y = 0; y < cols; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    char currentTile = refMap[x, y];

                    int dx = (x - playerX)/ 2; //Adjusts foir the 2:1 aspect raioo of  font skew for the map tiles had
                                               //a time woththe maths all the turtorials wewre saying times two but after
                                               //trying different numbers and  positions found that divide by two worked.. -Cf
                    int dy = y - playerY;
                    int distanceSquared = (dx * dx) + (dy * dy);// calculates range to from player for fov - CF

                    int correctedRadius = visionRadius * 2;
                    int radiusSquared = correctedRadius * correctedRadius;

                    //int distance = Math.Abs(x - playerX) + Math.Abs(y - playerY);// calculates range to from player for fov - CF

                    if (distanceSquared <= radiusSquared)// applieds normal map settings inside fov  - CF
                    {
                        
                        if (currentTile == '^') Console.ForegroundColor = ConsoleColor.DarkGray;
                        else if (currentTile == '`') Console.ForegroundColor = ConsoleColor.DarkGreen;
                        else if (currentTile == '~') Console.ForegroundColor = ConsoleColor.Blue;
                        else if (currentTile == '*') Console.ForegroundColor = ConsoleColor.Green;
                        else Console.ForegroundColor = ConsoleColor.White;
                    }
                    else  // Masks map black outside of fov  - CF
                    {
                      
                        if (currentTile == '^' || currentTile == '`' || currentTile == '~' || currentTile == '*')//if outside the raidius makes these tiles black
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else// leaves borders but greys them out  - CF
                        {                            
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                    }
                    Console.Write(currentTile);
                }              
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
     
    }
}

            #region old code
            //#region border top
            //            Console.Write("+");
            //            for (int k = 0; k < map.GetLength(0) * _scale; k++)
            //            {
            //                Console.Write('-');
            //            }
            //            Console.Write('+');
            //            Console.WriteLine(" ");

            //            #endregion

            //#region print map
            //            for (int i = 0; i < map.GetLength(0); i++)
            //            {

            //                int row = 0;
            //                while (row < _scale)
            //                {
            //                    Console.Write('|');
            //                    for (int j = 0; j < map.GetLength(0); j++)
            //                    {
            //                        int timer = 0;
            //                        while (timer < _scale)
            //                        {
            //                            if (map[i, j] == '^')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.DarkGray;

            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);

            //                            }

            //                            if (map[i, j] == '~')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.Blue;
            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);
            //                            }

            //                            if (map[i, j] == '*')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.Green;
            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);
            //                            }

            //                            if (map[i,j] == '`')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.DarkGreen;
            //                                _isOccupied.Add(false);
            //                                _isOccupied.Add(false);
            //                            }

            //                            Console.Write(map[i, j]);

            //                            timer++;
            //                        }
            //                    }
            //                    Console.ForegroundColor = ConsoleColor.White;

            //                    Console.Write('|');
            //                    Console.WriteLine(" ");
            //                    row++;
            //                }
            //            }

            //            #endregion

            //            #region bottom border
            //            Console.Write("+");
            //            for (int f = 0; f < map.GetLength(0) * _scale; f++)
            //            {
            //                Console.Write('-');
            //            }
            //            Console.Write('+');
            //            Console.WriteLine(" ");

            //            #endregion

            //Debug.WriteLine(_isOccupied[0]);

            //Displays
            //Console.WriteLine("Map legend: ");
            //Console.WriteLine("^ = mountain");
            //Console.WriteLine("` = grass");
            //Console.WriteLine("~ = water");
            //Console.WriteLine("* = trees");
//        }
//    }
//}

//string path = @"Data\data101.txt";

//string data = File.ReadAllText(path);

//string[] data = File.ReadAllLines(path);

//if (File.Exists(path))
//{
//    //safely reads the file
//}

//for (int i = 0; i < data.Length; i++)
//{
//    Console.WriteLine($"Line {i}: {data[i]}");
//}

/*
{'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
{'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
{'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
{'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
{'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
{'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
*/

#endregion