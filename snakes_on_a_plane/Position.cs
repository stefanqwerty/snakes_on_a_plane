namespace snakes_on_a_plane
{
    public class Position 
    {
        public int column;
        public int row;
        public Position()
        {

        }

        public bool IsOutOfGame(int columns, int rows)
        {
            if (columns >= 40)
            {
                return true;
            }

            if (rows >= 80)
            {
                return true;
            }

            if (columns < 0 )
            {
                return true;
            }

            if (rows < 0)
            {
                return true;
            }

            return false;
        }

    }
}
