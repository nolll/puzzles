using ConsoleApp.Puzzles.Year2021.Day06;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2021Tests
{
    public class Year2021Day06Tests
    {
        [TestCase(18, 26)]
        [TestCase(80, 5934)]
        [TestCase(256, 26_984_457_539)]
        public void Test(int days, long expected)
        {
            var puzzle = new Year2021Day06();
            var result = puzzle.FishCount(Input, days);

            Assert.That(result, Is.EqualTo(expected));
        }
        
        private const string Input = "3,4,3,1,2";
    }
}