using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace snakes_on_a_plane
{
    public class Snake
    {
        int GrowFactor = 0;

        public SnakeElement Head = new SnakeElement();

        private Direction Direction = new Direction();

        public Snake(Position SendPosition)
        {
            Head = new SnakeElement(SendPosition);
            Direction = Direction.Up;
        }

        public void GrowNewHead(Position position)
        {
            var element = new SnakeElement(position);
            element.Next = Head;
            Head = element;
        }

        public class SnakeElement
        {
            public Position Position = new Position();
            public SnakeElement Next;

            public SnakeElement()
            {
            }

            public SnakeElement(Position SendPosition)
            {
                Position = SendPosition;
            }
        }

        public ReadOnlyCollection<Position> GetAllSnakeElements()
        {
            var result = new List<Position>();

            var currentSnakeElement = Head;

            while (currentSnakeElement != null)
            {
                result.Add(currentSnakeElement.Position);
                currentSnakeElement = currentSnakeElement.Next;
            }

            return result.AsReadOnly();
        }

        public void MoveAndGrow()
        {
            GrowNewHead(GetNextPosition());

            if (GrowFactor == 0)
            {
                var TempElement = Head;

                while (TempElement.Next.Next != null)
                {
                    TempElement = TempElement.Next;
                }
                
                TempElement.Next = null;
            }

            if (GrowFactor > 0)
            {
                GrowFactor--;
            }
        }

        public void Eat(int FoodValue)
        {
            GrowFactor += FoodValue;
        }

        public bool TryChangeDirection(Direction NewDirection)
        {
            if ((NewDirection == Direction.Up && Direction == Direction.Down)
             || (NewDirection == Direction.Right && Direction == Direction.Left)
             || (NewDirection == Direction.Down && Direction == Direction.Up)
             || (NewDirection == Direction.Left && Direction == Direction.Right))
            {
                return false;
            }

            Direction = NewDirection;

            return true;
        }

        public Position GetNextPosition()
        {
            Position NextSnakePosition = Head.Position;

            _ = (Direction switch
            {
                Direction.Up => NextSnakePosition.Column--,
                Direction.Down => NextSnakePosition.Column++,
                Direction.Left => NextSnakePosition.Row--,
                Direction.Right => NextSnakePosition.Row++,
                _ => throw new System.NotImplementedException(),
            });

            return NextSnakePosition;
        }
    }
}
