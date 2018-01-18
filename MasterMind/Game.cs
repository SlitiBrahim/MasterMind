using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    public class Game
    {
        private int MinNbCols = 4;
        private int MaxNbCols = Pawn.AvailColors.Count;
        private int NbCols = 4;
        private int MinNbRows = 12;
        private int MaxNbRows = 20;
        private int NbRows = 12;
        private Row Combination;
        private bool IsGameOver = false;
        private List<Player> Players = new List<Player>();
        // private Player Winner;
        private string Mode = "1vs1";
        private Board Board;
        private ConsoleColor BackgroundColor = ConsoleColor.DarkGray;

        private void InitPlayers() {
            Players.Add(new Player());
            Players.Add((Mode == "1vs1") ? new Player() : new IA());
        }

        private void AskGameParams()
        {
            string outputText = "Player vs Player [1] or Player vs Computer [2]: ";

            Console.WriteLine(outputText);

            // not valid input
            if (!((int.TryParse(Console.ReadLine(), out int input)) && ((input == 1) || (input == 2))))
            {
                AskGameParams();
            }
            else
            {

                Mode = (input == 1) ? "1vs1" : "1vsIA";
                input = MinNbCols - 1;  // do that on purpose just to execute next loop verification

                outputText = "Please enter number of columns you want each board's row to have, including secret combination size [between " +
                                MinNbCols.ToString() + " and " + MaxNbCols.ToString() + "] (default = " + NbCols.ToString() + "): ";

                do
                {
                    // Test if player input is of type int, and if it's between set limits
                    Console.WriteLine(outputText);
                } while (!(int.TryParse(Console.ReadLine(), out input)) || (input < MinNbCols || input > MaxNbCols));

                NbCols = input;


                outputText = "Cool, now enter number of attempts you want to have before the game is over [between " +
                    MinNbRows.ToString() + " and " + MaxNbRows.ToString() + "] (default = " + NbRows + "): ";

                do
                {
                    Console.WriteLine(outputText);
                } while (!(int.TryParse(Console.ReadLine(), out input)) || (input < MinNbRows || input > MaxNbRows));

                NbRows = input;
            }
        }

        private void GenerateCombination() {
            Combination = Players[(Mode == "1vs1") ? 0 : 1].CreateCombination(NbCols);
        }

        private void FillBackgroundColor(ConsoleColor color) {

            int width = Console.BufferWidth;
            int height = Console.BufferHeight;

            char toFillChar = Encoding.GetEncoding(850).GetChars(new byte[] { 223 })[0];

            Console.BackgroundColor = color;
            Console.ForegroundColor = color;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(toFillChar);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DrawRow(Row row, int xOffset=0) {

            List<Pawn> tmpPawns = row.GetPawns();   // return List of pawns

            for (int i = 0; i < tmpPawns.Count; i++)
            {
                Console.SetCursorPosition(5 + (5 * xOffset), 8 + 4 * i);
                Console.ForegroundColor = Pawn.GetPawnForegroundColor(tmpPawns[i]);
                Console.WriteLine("●");
            }

        }

        private void DrawAttemptsRows() {
            // draw last row first -> have first row at complete right
            for (int i = NbRows - 1; i >= 0; i--)
            {
                DrawRow(Board.GetRow(i), i);
            }
        }

        public int Play()
        {
            FillBackgroundColor(BackgroundColor);

            // AskGameParams(); //Comment this out later

            Board = new Board(NbRows, NbCols);

            InitPlayers();

            GenerateCombination();

            //DrawRow(Combination);
            DrawAttemptsRows();

            // loop game
            while (!IsGameOver)
            {
                
            }

            return 1;
        }

    }
}
