using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace snakes_on_a_plane
{
    public class Snake
    {
        int CenterRow = 800;
        int CenterCollumn = 400;
        int GrowFactor = 0;
        int Lenght = 0;
        public Position center = new Position();
        Position HeadPosition = new Position();
        public SnakeElement Head = new SnakeElement();
        public Food Food = new Food();
        
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        public Direction direction = new Direction();

        public void GrowNewHead(Position position)
        {
            var element = new SnakeElement(position);
            element.next = Head;
            Head = element;
        }

        public class SnakeElement
        {
            public Position position = new Position();
            public SnakeElement next;

            public SnakeElement()
            {
            }

            public SnakeElement(Position sendPosition)
            {
                position = sendPosition;
            }
            public SnakeElement(int sendRow, int sendColumn)
            {
                position.row = sendRow;
                position.column = sendColumn;
            }
        }

        public List<Position> GetAllSnakeElements()
        {
            var result = new List<Position>();
            var currentSnakeElement = Head.next;
            while (currentSnakeElement != null)
            {
                result.Add(currentSnakeElement.position);
                currentSnakeElement = currentSnakeElement.next;
            }

            return result;
        }

        #region Move
        public void GoLeft()
        {
            if (TryChangeDirection(Direction.Left))
            {
                direction = Direction.Left;
               
                if (GrowFactor == 0)
                {
                    GrowNewHead(GetNextPosition());
                    var tempElement = Head;
                    while (tempElement.next != null)
                    {
                        tempElement = tempElement.next;
                    }
                    tempElement.next = null;
                    
                }
                if (GrowFactor > 0)
                {
                    GrowFactor--;
                    GrowNewHead(GetNextPosition());
                    
                }
            }
        }

        public void GoRight()
        {
            if (TryChangeDirection(Direction.Right))
            {
                direction = Direction.Right;


                if (GrowFactor == 0)
                {
                    GrowNewHead(GetNextPosition());
                    var tempElement = Head;
                    while (tempElement.next != null)
                    {
                        tempElement = tempElement.next;
                    }
                    tempElement.next = null;

                }
                if (GrowFactor > 0)
                {
                    GrowFactor--;
                    GrowNewHead(GetNextPosition());

                }
            }
        }

        public void GoUp()
        {
            if (TryChangeDirection(Direction.Up))
            {
                direction = Direction.Up;


                if (GrowFactor == 0)
                {
                    GrowNewHead(GetNextPosition());
                    var tempElement = Head;
                    while (tempElement.next != null)
                    {
                        tempElement = tempElement.next;
                    }
                    tempElement.next = null;

                }
                if (GrowFactor > 0)
                {
                    GrowFactor--;
                    GrowNewHead(GetNextPosition());

                }
            }
        }
        public void GoDown()
        {
            if (TryChangeDirection(Direction.Down))
            {
                direction = Direction.Down;

                if (GrowFactor == 0)
                {
                    GrowNewHead(GetNextPosition());
                    var tempElement = Head;
                    while (tempElement.next != null)
                    {
                        tempElement = tempElement.next;
                    }
                    tempElement.next = null;

                }
                if (GrowFactor > 0)
                {
                    GrowFactor--;
                    GrowNewHead(GetNextPosition());

                }
            }
        }
        #endregion    

        public void Move(Direction nextDirection)
        {
            if (TryChangeDirection(nextDirection))
            { 
                direction = nextDirection;
                GrowNewHead(GetNextPosition());
                if (GrowFactor == 0)
                {
                    var tempElement = Head;
                    while (tempElement.next != null)
                    {
                        tempElement = tempElement.next;
                    }
                    tempElement.next = null;
                }
                if(GrowFactor > 0)
                {
                    GrowFactor--;
                }
            }
        }

        public Snake() 
        {
            Head = new SnakeElement(CenterRow, CenterCollumn);
            direction = Direction.Up;
        }

        public void Eat(Position FoodPosition)
        {
            Food.SetPositionAndValue(FoodPosition);
        }
        
        public bool TryChangeDirection(Direction newDirection)
        {
            if ((newDirection == Direction.Up && direction == Direction.Down)
             || (newDirection == Direction.Right && direction == Direction.Left)
             || (newDirection == Direction.Down && direction == Direction.Up)
             || (newDirection == Direction.Left && direction == Direction.Right))
            {
                return false;
            }

            direction = newDirection;

            return true;
        }

        public Position GetNextPosition()
        {
            Position NextSnakePosition = new Position();
            NextSnakePosition.column = Head.position.column;
            NextSnakePosition.row = Head.position.row;

            switch (direction)
            {
                case Direction.Up:
                    NextSnakePosition.column -= 20;
                    break;
                case Direction.Down:
                    NextSnakePosition.column +=  20;
                    break;
                case Direction.Left:
                    NextSnakePosition.row -= 20;
                    break;
                case Direction.Right:
                    NextSnakePosition.row += 20;
                    break;
                default:
                    break;
            };
            return NextSnakePosition;
        }
    }

}
