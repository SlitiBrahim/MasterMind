using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Row
    {
        private List<Pawn> Pawns = new List<Pawn>();

        public Row(int cols)
        {
            for (int _ = 0; _ < cols; _++) {
                Pawns.Add(null);
            }
        }

        public void AddPawn(Pawn pawn) {
            Pawns.Add(pawn);
        }

        public List<Pawn> GetPawns() {
            return Pawns;
        }

        public bool SetPawns(List<Pawn> other) {

            if (other.Count == Pawns.Count) {

                Pawns = other;

                return true;
            }

            return false;
        }

        public bool SetPawnAt(Pawn pawn, int index) {

            if (Math.Abs(index) < Pawns.Count) {
                Pawns[index] = pawn;

                return true;                
            }

            return false;
        }

        public static Row RowOfPawnsByColors(List<ConsoleColor> colors) {

            Row tmp = new Row(colors.Count);

            for (int i = 0; i < colors.Count; i++)
            {
                tmp.SetPawnAt(new Pawn(colors[i]), i);
            }

            return tmp;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as Row);
        }

        public bool Equals(Row other) {

            if (this.Pawns == null && other.GetPawns() == null) {
                return true;
            }

            for (int i = 0; i < Pawns.Count; i++)
            {
                if (other.GetPawns()[i] != this.Pawns[i]) {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
