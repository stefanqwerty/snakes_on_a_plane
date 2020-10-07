namespace snakes_on_a_plane
{
    public class Food : Position
    {
        public int Value;
        public Position Position = new Position();
        public Food()
        {
            Value = 0;
        }
        public void SetPositionAndValue(Position position)
        {
            Position = position;
            SetNextFoodValue();
        }

        private void SetNextFoodValue()
        {
            Value++;
        }
    }
}
