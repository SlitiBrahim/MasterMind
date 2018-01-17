using System;
using System.Collections.Generic;
using System.Linq; // just to use Enumerable.Except() method

namespace MasterMind
{
    public class IA : Player
    {
        public IA()
        {
        }

        public override Row CreateCombination(int nbCols)
        {
            List<ConsoleColor> usedColors = new List<ConsoleColor>();
            List<ConsoleColor> unusedColors = new List<ConsoleColor>();
            ConsoleColor randomColor;
            Random randomNb = new Random();

            for (int i = 0; i < nbCols; i++)
            {
                // get all unused colors by differencing available colors and already used colors
                unusedColors = Pawn.AvailColors.Except(usedColors).ToList();
                randomColor = unusedColors[randomNb.Next(0, unusedColors.Count())]; // not included
                
                usedColors.Add(randomColor);
            }

            return Row.RowOfPawnsByColors(usedColors);
        }
    }
}
