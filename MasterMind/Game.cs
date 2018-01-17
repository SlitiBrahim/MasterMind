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
        private List<Row> Board = new List<Row>();
        private ConsoleColor BackgroundColor = ConsoleColor.DarkGray;

        private void InitPlayers() {

            Player tmpPlayer1;
            Player tmpPlayer2;

            if (Mode == "1vs1")
            {
                tmpPlayer1 = new Player();
                tmpPlayer2 = new Player();
            }
            // change this when creating IA inherited class from Player
            else {
                tmpPlayer1 = new Player();
                tmpPlayer2 = new Player();
            }

            Players.Add(tmpPlayer1);
            Players.Add(tmpPlayer2);
        }

        private void AskGameParams()
        {
            string outputText = "Player vs Player [1] or Player vs Computer [2]: ";

            Console.WriteLine(outputText);

            int input;

            // not valid input
            if (!((int.TryParse(Console.ReadLine(), out input)) && ((input == 1) || (input == 2))))
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

        private void CreateGameBoard()
        {

            for (int _ = 0; _ < NbRows; _++)
            {
                Board.Add(new Row(NbCols));
            }

        }

        private void AskUserCombination() {


        }

        private void GenerateCombination() {

            // code ...

            Combination = new Row(NbCols);

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
            for (int i = 0; i < NbRows; i++)
            {
                DrawRow(Board[i], i);
            }
        }

        public int Play()
        {

             // AskGameParams(); //Comment out later

            InitPlayers();

            FillBackgroundColor(BackgroundColor);

            GenerateCombination();

            DrawRow(Combination);
            CreateGameBoard();
            //DrawAttemptsRows();

            // loop game
            while (!IsGameOver)
            {

            }

            return 1;
        }

    }
}
