using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Board
    {
        private readonly List<Row> Rows = new List<Row>();

        public Board(int nbRows, int nbCols)
        {
            this.Init(nbRows, nbCols);
        }

        private void Init(int nbRows, int nbCols) {
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
    }
}
