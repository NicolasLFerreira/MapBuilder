using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MapBuilder
{
    class Grid
    {

        //Variable declaration

        private static int height = 125;
        private static int width = 150;

        string[,] grid = new string[height, width];

        public void GridBuild()
        {

            //Class instance

            var rng = new RandomGenerator();

            //Textures

            var textureMap = "0";

            var textureRiver = "$";

            var texturePlayer = "@";

            //River

            var riverSize = 20000;

            var pos1 = 0;
            var pos2 = rng.RandomNumber(5, width / 2);

            //if (rng.Random01())
            //{
            //    pos1 = 0;
            //    pos2 = rng.RandomNumber(0, width);
            //}
            //else
            //{
            //    pos2 = 0;
            //    pos1 = rng.RandomNumber(0, height);
            //}

            var river1 = new List<int>(riverSize);
            var river2 = new List<int>(riverSize);

            var sw = Stopwatch.StartNew();
            Trace.TraceInformation($"Started memory map");

            for (var r = 0; r < riverSize; r++)
            {

                if (rng.RandomNumber(0, 50) % 2 == 0)
                    pos1++;
                if (rng.RandomNumber(0, 50) % 2 == 0)
                    pos2++;

                if ((rng.RandomNumber(0, 50) % 3 == 0 || rng.RandomNumber(0, 50) % 5 == 0 || rng.RandomNumber(0, 50) % 7 == 0 || rng.RandomNumber(0, 50) / 2 % 2 == 0) && rng.RandomNumber(0, 50) % 2 != 0)
                    pos1--;
                if ((rng.RandomNumber(0, 50) % 3 == 0 || rng.RandomNumber(0, 50) % 5 == 0 || rng.RandomNumber(0, 50) % 7 == 0 || rng.RandomNumber(0, 50) / 2 % 2 == 0) && rng.RandomNumber(0, 50) % 2 != 0)
                    pos2--;

                //if (r % 5 == 0 || r > riverSize / 2)
                //{



                //    if (rng.Random01())
                //    {
                //        pos1--;
                //    }
                //    else
                //    {
                //        pos2--;
                //    }

                //}

                river1.Add(pos1);
                river2.Add(pos2);
            }
            Trace.TraceInformation($"End memory map: {sw.ElapsedMilliseconds}");
            sw.Stop();

            //Grid
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {

                    //Map

                    if (rng.Random01())
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    grid[i, j] = textureMap;

                    //River

                    for (var a = 0; a < riverSize; a++)
                    {
                        if (i == river1[a] && j == river2[a])
                        {
                            if (rng.Random01())
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            }
                            grid[i, j] = textureRiver;
                        }
                    }

                    //Player

                    if (i == 3 && j == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        grid[i, j] = texturePlayer;
                    }

                    //Map writing

                    Console.Write(grid[i, j]);

                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.Write("\n");
            }
        }
    }
}
