using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Board
    {
        private readonly List<Row> Rows = new List<Row>();

        public Board(int nbRows, int nbCols)
        {
            for (int i = 0; i < nbRows; i++)
            {
                Rows.Add(new Row(nbCols));
            }
        }

        public Row GetRow(int index) {
            return (index < Rows.Count) ? Rows[index] : null;
        }

        public bool SetRow (Row row, int boardIndex) {

            if (Math.Abs(boardIndex) < Rows.Count) {

                Rows[boardIndex] = row;
                return true;
            }
            return false;
        }

        public bool SetPawnInRow (Pawn pawn, int pawnIndex, int rowIndex) {

            if (Math.Abs(rowIndex) < Rows.Count)
                return Rows[rowIndex].SetPawnAt(pawn, pawnIndex);

            return false;
        }

        public void DrawRow(Row row, int xOffset = 0)
        {

            List<Pawn> tmpPawns = row.GetPawns();   // return List of pawns

            for (int i = 0; i < tmpPawns.Count; i++)
            {
                Console.SetCursorPosition(5 + (5 * xOffset), 2 + 4 * i);
                Console.ForegroundColor = Pawn.GetPawnForegroundColor(tmpPawns[i]);
                Console.WriteLine("☻");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawAttemptsRows()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // draw last row first -> have first row at complete right
            for (int i = Rows.Count - 1; i >= 0; i--)
            {
                DrawRow(Rows[i], (Rows.Count - 1) - i); // 2nd param: offset set to right, then shifting leftward
            }

            Console.SetCursorPosition(0, 20);
        }
    }
}
