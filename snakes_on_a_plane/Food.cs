namespace snakes_on_a_plane
{
    public class Food : Position
    {
        public int Value;
        
        public Food()
        {
            Value = 0;
        }
        
        public void SetPositionAndValue(Position Position)
        {
            (Column, Row) = (Position.Column, Position.Row);

            Value++;
        }
    }
}
