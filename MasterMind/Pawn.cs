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
        public static string BigPawn = "☻";
        public static string SmallPawn = "●";
        public static ConsoleColor WritePlace = ConsoleColor.Black;
        public static ConsoleColor WriteColor = ConsoleColor.White;
        public static ConsoleColor EmptyPawn = ConsoleColor.Gray;

        public Pawn(ConsoleColor color = ConsoleColor.Black)
        {
            Color = color;
        }

        public ConsoleColor GetColor() {
            return Color;
        }

        public void SetColor(ConsoleColor color) {
            Color = color;
        }

        // Declared as static because it may me be called with "null", not necessarily with an instance
        public static ConsoleColor GetPawnForegroundColor(Pawn pawn)
        {
            return (pawn != null) ? pawn.GetColor() : Pawn.EmptyPawn;
        }

        // voir si param nécessaire
        public static void DisplayAvailColors(List<ConsoleColor> arrToCompare = null) {

            for (int i = 0; i < AvailColors.Count; i++)
            {
                Console.SetCursorPosition(80, 15 + i);
                Console.ForegroundColor = AvailColors[i];
                Console.WriteLine(AvailColors[i] + " ●");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
