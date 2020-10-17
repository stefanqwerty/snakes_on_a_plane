using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace snakes_on_a_plane
{
    public class Game
    {
        public Snake Snake = new Snake();
        public List<Position> allPossiblePositions = new List<Position>();
        public List<Position> allPossibleFoodPositions = new List<Position>();
        List<Position> SnakeElements = new List<Position>();
        bool isFirstFrame = true;

        public void getAllPositions()
        {
            for (int x = 0; x < 80; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    Position PossiblePosition = new Position();
                    PossiblePosition.column = x;
                    PossiblePosition.row = y;
                    allPossiblePositions.Add(PossiblePosition);
                    y++;
                }
                x++;
            }
        }

        public Game()
        {
            getAllPositions();
        }

        public void getAllPossibleFoodPositions()
        {
            SnakeElements = Snake.GetAllSnakeElements();
            allPossibleFoodPositions = (List<Position>)allPossiblePositions.Except(SnakeElements);
        }

        public Position GetNewPositionForFood()
        {
            if (isFirstFrame)
            {
                Snake.Eat(GetNewPositionForFood());
                isFirstFrame = false;
            }
            getAllPossibleFoodPositions();
            var k = new Random();
            int rand = k.Next(allPossibleFoodPositions.Count() - 1);
            Position result = new Position();
            result = allPossibleFoodPositions[rand];
            return result;
        }

        public bool NextFrame()
        {
            var nextHeadPos = Snake.GetNextPosition();

            if (nextHeadPos == Snake.Food.Position)
            {
                Snake.Eat(GetNewPositionForFood());
            }

            if (SnakeElements.Contains(nextHeadPos))
            {
                return false;
            }

            if (nextHeadPos.IsOutOfGame(nextHeadPos.column, nextHeadPos.row))
            {
                return false;
            }

            return true;
        }

        
    }
}
