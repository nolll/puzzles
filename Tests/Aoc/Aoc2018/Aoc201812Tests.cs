using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201812Tests : PuzzleTest<Aoc201812>
{
    [Fact]
    public void PlantScoreIsCorrect()
    {
        const string input = """
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
                             ####. => #
                             """;

        var spreader = new Aoc201812.PlantSpreader(input);

        spreader.PlantScore20.Should().Be(325);
    }
}