using System;
using System.Drawing;
using System.Windows.Forms;

namespace snakes_on_a_plane
{
    public class Position : IComparable<Position>
    {
        public int Column;
        public int Row;

        public Position()
        {
        }

        public Position(int SendColumn, int SendRow) => (Column, Row) = (SendColumn, SendRow);

        public override string ToString() => $"{Column}, {Row}";

        public static bool operator == (Position Left, Position Right) => (Left.Column, Left.Row) == (Right.Column, Right.Row);

        public static bool operator != (Position Left, Position Right) => (Left.Column, Left.Row) != (Right.Column, Right.Row);
        
        public override bool Equals (Object o)
        {
            if (o is Position)
            {
                var x = (Position)o;
                return this == x;
            }

            return false;
        }

        #region Icomparable

        public int CompareTo(Position Position)
        {
            if ((this.Column, this.Row) == (Position.Column, Position.Row))
            {
                return 0;
            }

            if (this.Column <= Position.Column && this.Row <= Position.Row)
            {
                return -1;
            }

            return 1;
        }

        #endregion
    }
}
