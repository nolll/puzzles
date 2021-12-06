using System;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2017.Day11
{
    public class HexGridNavigator
    {
        private readonly Matrix<int> _matrix;
        public int EndDistance { get; }
        public int MaxDistance { get; }

        public HexGridNavigator(string input)
        {
            _matrix = new Matrix<int>();
            _matrix.TurnTo(MatrixDirection.Up);

            var directions = input.Split(',');
            var maxDistance = 0;
            var currentDistance = 0;

            foreach (var direction in directions)
            {
                Move(direction);
                currentDistance = Distance;
                if(currentDistance > maxDistance)
                    maxDistance = currentDistance;
            }

            EndDistance = currentDistance;
            MaxDistance = maxDistance;
        }

        private int Distance
        {
            get
            {
                var x = _matrix.Address.X;
                var y = _matrix.Address.Y;
                var xStart = _matrix.StartAddress.X;
                var yStart = _matrix.StartAddress.Y;
                var xMax = Math.Max(xStart, x);
                var xMin = Math.Min(xStart, x);
                var yMax = Math.Max(yStart, y);
                var yMin = Math.Min(yStart, y);
                var xDistance = xMax - xMin;
                var yDistance = yMax - yMin;
                var distance = 0;

                while (xDistance > 0 && yDistance > 0)
                {
                    xDistance--;
                    yDistance--;
                    distance++;
                }

                while (xDistance > 0)
                {
                    xDistance--;
                    distance++;
                }

                while (yDistance > 0)
                {
                    yDistance--;
                    yDistance--;
                    distance++;
                }

                return distance;
            }
        }

        private void Move(string direction)
        {
            if (direction == "n")
            {
                _matrix.MoveUp();
                _matrix.MoveUp();
            }
            else if (direction == "ne")
            {
                _matrix.MoveRight();
                _matrix.MoveUp();
            }
            else if (direction == "se")
            {
                _matrix.MoveRight();
                _matrix.MoveDown();
            }
            else if (direction == "s")
            {
                _matrix.MoveDown();
                _matrix.MoveDown();
            }
            else if (direction == "sw")
            {
                _matrix.MoveLeft();
                _matrix.MoveDown();
            }
            else if (direction == "nw")
            {
                _matrix.MoveLeft();
                _matrix.MoveUp();
            }
        }
    }
}