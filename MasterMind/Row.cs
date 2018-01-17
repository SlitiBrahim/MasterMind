using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Row
    {
        private List<Pawn> Cells = new List<Pawn>();

        public Row(int cols)
        {
            for (int _ = 0; _ < cols; _++) {
                Cells.Add(null);
            }
        }

        public void AddPawn(Pawn pawn) {
            //Cells.Add(pawn);
        }

        public List<Pawn> GetCells() {
            return Cells;
        }

        public bool SetCells(List<Pawn> other) {

            if (other.Count == Cells.Count) {

                Cells = other;

                return true;
            }

            return false;
        }
    }
}
