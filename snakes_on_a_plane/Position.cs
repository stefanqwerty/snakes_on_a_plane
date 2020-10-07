namespace snakes_on_a_plane
{
    public class Position 
    {
        public int column;
        public int row;
        public Position()
        {

        }

        public bool IsOutOfGame(int columns, int rows) => row < 0
                                                        || row >= rows
                                                        || column < 0
                                                        || column >= columns;

    }
}
