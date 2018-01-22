using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class Index : Row
    {
        private Row AddedColors = new Row();

        public Index(int nbCols) : base(nbCols)
        {
            for (int i = 0; i < nbCols; i++)
            {
                // set default pawn as gray instead of null pawn which causes errors
                this.SetPawnAt(new Pawn(ConsoleColor.Gray), i);
            }
        }

        public static ConsoleColor MatchPawns(Pawn usrPawn, Pawn combPawn, Row combination, Index index) {

            // surcharger la methode Contains pour la class Row
            // Prendre en compte les doublons


            ConsoleColor color;

            // Right color and right place
            if (usrPawn.GetColor() == combPawn.GetColor()) {
                color = ConsoleColor.Black;
            }
            // Right color
            else if (!index.AddedColors.Contains(usrPawn) && combination.Contains(usrPawn)) {
                color = ConsoleColor.White;
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
