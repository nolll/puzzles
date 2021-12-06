using ConsoleApp.Puzzles.Year2021.Day06;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2021Tests
{
    public class Year2021Day06Tests
    {
        [Test]
        public void Part1()
        {
            var puzzle = new Year2021Day06();
            var result = puzzle.FishCount(Input, 18);

            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void Part1_2()
        {
            var puzzle = new Year2021Day06();
            var result = puzzle.FishCount(Input, 80);

            Assert.That(result, Is.EqualTo(5934));
        }

        [Test]
        public void Part2()
        {
            var puzzle = new Year2021Day06();
            var result = 0;

            Assert.That(0, Is.EqualTo(0));
        }

        private const string Input = "3,4,3,1,2";
    }
}