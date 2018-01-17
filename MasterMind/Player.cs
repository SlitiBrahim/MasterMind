using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Player
    {
        
        public Player()
        {
        }

        public Row CreateCombination(int nbCols) {
            
            string input;
            List<ConsoleColor> inputColors = new List<ConsoleColor>();
            ConsoleColor a;

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < nbCols; i++)
            {
                do
                {
                    Console.WriteLine("Please enter pawn color for pawn number "
                                      + (i + 1).ToString() + "/" + nbCols + ": ");

                    Console.Write("\nHere's the list of available colors:\n");
                    Pawn.DisplayAvailColors();

                    input = Console.ReadLine();
                    a = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input, true);    // parse string input to ConsoleColor object

                } while (inputColors.Contains(a));  // check if issued color was not already added to combination

                inputColors.Add(a);

                Console.Clear();
            }

            return Row.CreateRowOfPawnsByColors(inputColors);
        }
    }
}
