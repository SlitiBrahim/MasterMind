using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Player
    {
        
        public Player()
        {
        }

        public virtual Row CreateCombination(int nbCols) {

            Row tmp = new Row(nbCols);
            for (int i = 0; i < nbCols; i++)
            {
                tmp.SetPawnAt(new Pawn(Pawn.AvailColors[i]), i);
            }

            return tmp;

            // comment this out later

            //string input;
            //List<ConsoleColor> inputColors = new List<ConsoleColor>();
            //ConsoleColor a;

            //Console.ForegroundColor = ConsoleColor.White;

            //for (int i = 0; i < nbCols; i++)
            //{
            //    do
            //    {
            //        Console.Write("Please enter pawn color for pawn number ");

            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.Write((i + 1).ToString());
            //        Console.ForegroundColor = ConsoleColor.White;
            //        Console.Write("/" + nbCols.ToString() + ": ");

            //        Console.Write("\nHere's the list of available colors:\n");
            //        Pawn.DisplayAvailColors();

            //        input = Console.ReadLine();
            //        a = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input, true);    // parse string input to ConsoleColor object

            //    } while (inputColors.Contains(a));  // check if issued color was not already added to combination

            //    inputColors.Add(a);

            //    Console.Clear();
            //}

            //return Row.RowOfPawnsByColors(inputColors);
        }
    }
}
