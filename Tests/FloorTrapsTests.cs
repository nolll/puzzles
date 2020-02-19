using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class FloorTrapsTests
    {
        [Test]
        public void SafeCountIsCorrect()
        {
            const string input = "";

            var detector = new FloorTrapDetector(input);
            detector.FindTraps(10);

            Assert.That(detector.SafeCount, Is.EqualTo(38));
        }
    }

    public class FloorTrapDetector
    {
        private readonly Matrix<char> _matrix;

        public int SafeCount => _matrix.Values.Count(o => o == '.');

        public FloorTrapDetector(string input)
        {
            _matrix = BuildMatrix(input);
        }

        private Matrix<char> BuildMatrix(string input)
        {
            var chars = input.ToCharArray();
            var matrix = new Matrix<char>();

            var x = 0;
            foreach (var c in chars)
            {
                matrix.MoveTo(x, 0);
                x++;
            }

            return matrix;
        }

        public void FindTraps(int rows)
        {
            
        }
    }
}