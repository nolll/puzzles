using ConsoleApp.Puzzles.Year2018.Day12;
using NUnit.Framework;

namespace Tests
{
    public class SubterraneanSustainabilityTests
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