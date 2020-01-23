using Core.SubterraneanSustainability;
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

            Assert.That(spreader.PlantScore, Is.EqualTo(325));
        }
    }
}