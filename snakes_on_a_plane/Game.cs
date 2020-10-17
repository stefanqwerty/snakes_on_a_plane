using System;
using System.Collections.Generic;
using System.Linq;

namespace snakes_on_a_plane
{
    public class Game
    {
        public int Rows = 40;
        public int Columns = 80;
        Position CenterPosition;

        public Snake Snake;
        public Food Food;
        public List<Position> AllPossiblePositions;
        public List<Position> AllPossibleFoodPositions;

        public Game()
        {
            SetAllPositions();
            CenterPosition = new Position(Columns / 2, Rows / 2);
            Snake = new Snake(CenterPosition);
            Food = new Food();
            Food.SetPositionAndValue(GetNewPositionForFood());
        }

        public void SetAllPositions()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    AllPossiblePositions.Add(new Position(x, y));
                }
            }
        }

        public void SetAllPossibleFoodPositions()
        {
            AllPossibleFoodPositions = (List<Position>)AllPossiblePositions.Except(Snake.GetAllSnakeElements());
        }

        public Position GetNewPositionForFood()
        {
            SetAllPossibleFoodPositions();
            int rand = new Random().Next(AllPossibleFoodPositions.Count() - 1);
            return AllPossibleFoodPositions[rand];
        }

        public bool NextFrame()
        {
            var nextHeadPos = Snake.GetNextPosition();

            if (nextHeadPos == Food)
            {
                Snake.Eat(Food.Value);
                Food.SetPositionAndValue(GetNewPositionForFood());
            }

            if (Snake.GetAllSnakeElements().Contains(nextHeadPos))
            {
                return false;
            }

            if (IsPositionOutOfGame(nextHeadPos))
            {
                return false;
            }

            return true;
        }

        public bool IsPositionOutOfGame(Position Position)
        {
            return (Position.Column < 0)
                || (Position.Column >= Columns)
                || (Position.Row < 0)
                || (Position.Row >= Rows);
        }
    }
}
