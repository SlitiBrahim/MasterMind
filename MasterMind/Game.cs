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
        private int MinNbRows = 12; //12
        private int MaxNbRows = 20;
        private int NbRows = 12; // 12
        private int Trial = 0;
        private Row Combination;
        private bool IsGameOver = false;
        private List<Player> Players = new List<Player>();
        private Player Winner;
        private string Mode = "1vs1";
        private Board Board;
        private ConsoleColor BackgroundColor = ConsoleColor.DarkGray;

        private void InitPlayers() {
            Players.Add((Mode == "1vs1") ? new Player() : new IA());
            Players.Add(new Player());
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
            Combination = Players[0].CreateCombination(NbCols);
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


        public Row AskPlayerToEnterRow(int rowIndex) {

            Row currentRow = new Row(NbCols);
            Pawn providedPawn;
            // player[0] -> player who created the combination | [1] player who has to guess
            int playerIndex = 1;

            for (int i = 0; i < NbCols; i++)
            {

                Console.SetCursorPosition(70, 10);

                Console.WriteLine("Please issue color you want to set to pawn " + (i + 1).ToString());
                Pawn.DisplayAvailColors();

                providedPawn = Players[playerIndex].PlayPawn();
                Board.SetPawnInRow(providedPawn, i, rowIndex);
                currentRow.SetPawnAt(providedPawn, i);

                Board.DrawAttemptsRows(true);
            }

            Board.SetIndex(Combination, currentRow, Trial);

            return currentRow;
        }

        private bool CombinationFound() {
            return this.Combination.Equals(Board.GetRow(Trial));
        }

        private void ProcessVictory() {
            IsGameOver = true;
            Winner = Players[1]; // [0] player who made combination, [1] user who have to guess combination
            Console.WriteLine("Cool you have found the combination in " + (Trial + 1).ToString() + " trial" + ((Trial + 1 > 1) ? "s." : "."));
        }

        public int Play()
        {
            FillBackgroundColor(BackgroundColor);

            AskGameParams(); //Comment this out later

            Board = new Board(NbRows, NbCols);

            InitPlayers();

            GenerateCombination();

            Row playerRowAnswer = null;

            // loop game
            while (!IsGameOver)
            {
                // Draw indexes only if player already provided a row -> not first loop because default = null
                Board.DrawAttemptsRows(playerRowAnswer != null);

                playerRowAnswer = AskPlayerToEnterRow(Trial);

                Board.DrawAttemptsRows(true);

                // not first loop
                if (playerRowAnswer != null && CombinationFound())
                {
                    ProcessVictory();
                }
                                
                // Number of trials achieved
                IsGameOver |= Trial == NbRows - 1;  // -1 -> Trial begins by 0

                Trial++; // incrementing trial -> number of user trials
            }

            //Console.Clear();
            Console.WriteLine("\nThis is the end");

            return 1;
        }
    }
}