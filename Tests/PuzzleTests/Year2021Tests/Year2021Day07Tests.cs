using System;
using System.Linq;
using Core.Common.Strings;
using Core.Puzzles.Year2021.Day07;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2021Tests
{
    public class Year2021Day07Tests
    {
        [Test]
        public void Part1()
        {
            var puzzle = new Year2021Day07();
            var result = puzzle.GetFuel1(Input);

            Assert.That(result, Is.EqualTo(37));
        }

        [Test]
        public void Part2()
        {
            var puzzle = new Year2021Day07();
            var result = puzzle.GetFuel2(Input);

            Assert.That(result, Is.EqualTo(168));
        }

        [TestCase(16, 5, 66)]
        [TestCase(1, 5, 10)]
        [TestCase(2, 5, 6)]
        [TestCase(0, 5, 15)]
        [TestCase(4, 5, 1)]
        [TestCase(2, 5, 6)]
        [TestCase(7, 5, 3)]
        [TestCase(1, 5, 10)]
        [TestCase(2, 5, 6)]
        [TestCase(14, 5, 45)]
        [TestCase(5, 16, 66)]
        [TestCase(5, 5, 0)]
        public void Cost(int a, int b, int expected)
        {
            var puzzle = new Year2021Day07();
            var result = puzzle.GetCost(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        private const string Input = "16,1,2,0,4,2,7,1,2,14";
    }
}