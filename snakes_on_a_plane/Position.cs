namespace snakes_on_a_plane
{
    public class Position 
    {
        public int Column;
        public int Row;

        public Position()
        {
        }

        public Position(int SendColumn, int SendRow) => (Column, Row) = (SendColumn, SendRow);

        public string ToString() => $"{Column}, {Row}";
    }
}
