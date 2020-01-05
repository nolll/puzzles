using System;
using System.Linq;
using Core.Tools;

namespace Core.EasterbunnyHq
{
    public class EasterbunnyDistanceCalculator
    {
        private readonly Matrix<int> _matrix;

        public EasterbunnyDistanceCalculator()
        {
            _matrix = new Matrix<int>();
        }


        public void Go(string input)
        {
            var instructions = input.Split(',').Select(o => o.Trim());
            _matrix.TurnTo(MatrixDirection.Up);
            foreach (var instruction in instructions)
            {
                var direction = instruction.Substring(0, 1);
                var distance = int.Parse(instruction.Substring(1));
                if (direction == "R")
                    _matrix.TurnRight();
                else
                    _matrix.TurnLeft();
                _matrix.MoveForward(distance);
            }
        }

        public int DistanceFromStart
        {
            get
            {
                var start = _matrix.StartAddress;
                var current = _matrix.Address;

                var xMax = Math.Max(start.X, current.X);
                var xMin = Math.Min(start.X, current.X);
                var xDiff = xMax - xMin;

                var yMax = Math.Max(start.Y, current.Y);
                var yMin = Math.Min(start.Y, current.Y);
                var yDiff = yMax - yMin;

                return xDiff + yDiff;
            }
        }
    }
}