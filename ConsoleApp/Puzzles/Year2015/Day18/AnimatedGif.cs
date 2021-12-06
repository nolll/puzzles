using System.Linq;
using Core.Common.CoordinateSystems;

namespace ConsoleApp.Puzzles.Year2015.Day18
{
    public class AnimatedGif
    {
        private const char LightOn = '#';
        private const char LightOff = '.';

        private readonly bool _isCornersLit;
        private Matrix<char> _matrix;

        public int LightCount => _matrix.Values.Count(o => o == LightOn);

        public AnimatedGif(in string input, in bool isCornersLit = false)
        {
            _isCornersLit = isCornersLit;
            _matrix = MatrixBuilder.BuildCharMatrix(input);
            if (_isCornersLit)
                TurnOnCornerLights();
        }

        public void RunAnimation(in int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                var newMatrix = new Matrix<char>();
                for (var y = 0; y < _matrix.Height; y++)
                {
                    for (var x = 0; x < _matrix.Width; x++)
                    {
                        _matrix.MoveTo(x, y);
                        newMatrix.MoveTo(x, y);
                        var adjacentValues = _matrix.AllAdjacentValues;
                        newMatrix.WriteValue(GetNewState(_matrix.ReadValue(), adjacentValues.Count(o => o == LightOn)));
                    }
                }

                _matrix = newMatrix;
                if (_isCornersLit)
                    TurnOnCornerLights();
            }
        }

        private void TurnOnCornerLights()
        {
            var xMax = _matrix.Width - 1;
            var yMax = _matrix.Height - 1;
            TurnOnLight(0, 0);
            TurnOnLight(xMax, 0);
            TurnOnLight(xMax, yMax);
            TurnOnLight(0, yMax);
        }

        private void TurnOnLight(int x, int y)
        {
            _matrix.MoveTo(x, y);
            _matrix.WriteValue(LightOn);
        }

        private char GetNewState(in char value, in int adjacentOnCount)
        {
            if (value == LightOn)
            {
                return adjacentOnCount == 2 || adjacentOnCount == 3 
                    ? LightOn 
                    : LightOff;
            }

            return adjacentOnCount == 3 
                ? LightOn 
                : LightOff;
        }
    }
}