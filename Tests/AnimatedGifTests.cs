using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class AnimatedGifTests
    {
        [Test]
        public void FourLightsAfterFourSteps()
        {
            const string input = @"
.#.#.#
...##.
#....#
..#...
#.#..#
####..";

            var gif = new AnimatedGif(input);
            gif.RunAnimation(4);

            Assert.That(gif.LightCount, Is.EqualTo(4));
        }
    }

    public class AnimatedGif
    {
        private Matrix<char> _matrix;

        public int LightCount => _matrix.Values.Count(o => o == '#');

        public AnimatedGif(in string input)
        {
            _matrix = MatrixBuilder.BuildCharMatrix(input);
        }

        public void RunAnimation(in int steps)
        {
            var newMatrix = new Matrix<char>();
            for (var y = 0; y < _matrix.Height; y++)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    _matrix.MoveTo(x, y);
                    newMatrix.MoveTo(x, y);
                    var adjacentValues = _matrix.Adjacent8;
                    newMatrix.WriteValue(GetNewState(_matrix.ReadValue(), adjacentValues.Count(o => o == '#')));
                }

                _matrix = newMatrix;
            }
        }

        private char GetNewState(in char value, in int adjacentOnCount)
        {
            if (value == '#')
            {
                if (adjacentOnCount == 2 || adjacentOnCount == 3)
                    return '#';
                return '.';
            }

            if (adjacentOnCount == 3)
                return '#';
            return '.';
        }
    }
}