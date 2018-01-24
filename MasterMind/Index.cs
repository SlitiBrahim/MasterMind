using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Index : Row
    {
        private readonly Row AddedColors = new Row();

        public Index(int nbCols) : base(nbCols)
        {
            for (int i = 0; i < nbCols; i++)
            {
                // set default pawn as gray instead of null pawn which causes errors
                this.SetPawnAt(new Pawn(Pawn.EmptyPawn), i);
            }
        }

        public static ConsoleColor MatchPawns(Pawn usrPawn, Pawn combPawn, Row combination, Index index) {
            
            ConsoleColor color;

            // Right color and right place
            if (usrPawn.GetColor() == combPawn.GetColor()) {
                color = Pawn.WritePlace;
            }
            // Right color
            else if (!index.AddedColors.Contains(usrPawn) && combination.Contains(usrPawn)) {
                color = Pawn.WriteColor;
                index.AddedColors.AddPawn(usrPawn);
            }
            // Invalid color
            else {
                color = ConsoleColor.Gray;
            }

            return color;
        }
    }
}
