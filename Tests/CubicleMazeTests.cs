using System;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class CubicleMazeTests
    {
        [Test]
        public void ShortestRouteLengthIsCorrect()
        {
            const int input = 10;

            var maze = new Maze(10, 7, input);

            Assert.That(maze.RouteLength, Is.EqualTo(11));
        }
    }

    public class Maze
    {
        public int RouteLength { get; }

        public Maze(in int width, in int height, in int secretNumber)
        {
            var matrix = BuildMatrix(width, height, secretNumber);
            matrix.MoveTo(1, 1);

            RouteLength = 0;
        }

        private Matrix<char> BuildMatrix(in int width, in int height, in int secretNumber)
        {
            var matrix = new Matrix<char>();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    matrix.MoveTo(x, y);
                    var value = x * x + 3 * x + 2 * x * y + y + y * y + secretNumber;
                    var binary = Convert.ToString(value, 2);
                    var binaryString = binary.ToString();
                    var numberOfSetBits = binaryString.Count(o => o == '1');
                    var isOpenSpace = numberOfSetBits % 2 == 0;
                    var c = isOpenSpace ? '.' : '#';
                    matrix.WriteValue(c);
                }
            }

            return matrix;
        }
    }
}