using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Board
    {
        private readonly List<Row> Rows = new List<Row>();
        private List<Index> Indexes = new List<Index>();

        public Board(int nbRows, int nbCols)
        {
            for (int i = 0; i < nbRows; i++)
            {
                Rows.Add(new Row(nbCols));
                Indexes.Add(new Index(nbCols));
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
                Console.WriteLine(Pawn.BigPawn);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SetIndex(Row combination, Row currentRow, int rowIndex) {

            int nbCols = Indexes[rowIndex].GetPawns().Count;
            Pawn tmpPawnIndex;

            for (int i = 0; i < nbCols; i++)
            {
                tmpPawnIndex = new Pawn();

                tmpPawnIndex.SetColor(Index.MatchPawns(
                    currentRow.GetPawns()[i],
                    combination.GetPawns()[i],
                    combination,
                    Indexes[rowIndex]
                ));

                Indexes[rowIndex].SetPawnAt(tmpPawnIndex, i);
            }
        }

        private void DrawIndex(int rowIndex, int xOffset = 0) {

            Row currentIndex = Indexes[rowIndex];
            int nbCols = currentIndex.GetPawns().Count;

            for (int i = 0; i < nbCols; i++)
            {
                Console.SetCursorPosition(40 + (5 * xOffset), 7 + i);
                Console.ForegroundColor = currentIndex.GetPawns()[i].GetColor();
                Console.WriteLine(Pawn.SmallPawn);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawAttemptsRows(bool showIndexes = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // draw last row first -> have first row at complete right
            for (int i = Rows.Count - 1; i >= 0; i--)
            {
                DrawRow(Rows[i], (Rows.Count - 1) - i); // 2nd param: offset set to right, then shifting leftward

                if (showIndexes) {
                   
                    DrawIndex(i, (Rows.Count - 1) - i); //changer avec i
                }
            }

            Console.SetCursorPosition(0, 20);
        }
    }
}
