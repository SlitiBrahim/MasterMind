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

        public ConsoleColor getColor() {
            return Color;
        }
    }
}
