using System;
using System.Globalization;

using Microsoft.VisualBasic.CompilerServices;

namespace MapBuilder
{
    class Program
    {

        static void Main(string[] args)
        {

            //Object instance

            var grid = new Grid();
            var rng = new RandomGenerator();

            //Program

            while (true)
            {
                Console.Clear();
                grid.GridBuild();
                Console.ReadKey();
            }

        }
    }
}
