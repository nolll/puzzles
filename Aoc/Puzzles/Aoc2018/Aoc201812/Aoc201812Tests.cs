namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201812;

public class Aoc201812Tests
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

        var spreader = new PlantSpreader(input);

        spreader.PlantScore20.Should().Be(325);
    }
}