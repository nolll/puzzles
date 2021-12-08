using Core.Puzzles.Year2018.Day12;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2018Tests
{
    public class Year2018Day12Tests
    {
        [Test]
        public void PlantScoreIsCorrect()
        {
            const string input = @"
initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";

            var spreader = new PlantSpreader(input);

            Assert.That(spreader.PlantScore20, Is.EqualTo(325));
        }
    }
}