using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Pawn
    {
        private ConsoleColor Color;
        public static List<ConsoleColor> AvailColors = new List<ConsoleColor> {
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Black
        };

        public Pawn(ConsoleColor color)
        {
            Color = color;
        }

        public ConsoleColor GetColor() {
            return Color;
        }

        // Declared as static because it may me be called with "null", not necessarily with an instance
        public static ConsoleColor GetPawnForegroundColor(Pawn pawn)
        {
            return (pawn != null) ? pawn.GetColor() : ConsoleColor.Gray;
        }

        public static void DisplayAvailColors(List<ConsoleColor> arrToCompare = null) {
            for (int i = 0; i < AvailColors.Count; i++)
            {
                Console.ForegroundColor = AvailColors[i];
                Console.WriteLine(AvailColors[i] + " ●");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
