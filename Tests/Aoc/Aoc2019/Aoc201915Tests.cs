using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201915Tests
{
    [Fact]
    public void Returns4Minutes()
    {
        const string map = """
                            ##
                           #..##
                           #.#..#
                           #.X.#
                            ###
                           """;

        var filler = new Aoc201915.OxygenFiller(map);
        var result = filler.Fill();

        result.Should().Be(4);
    }
}