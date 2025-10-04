namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

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

        var filler = new OxygenFiller(map);
        var result = filler.Fill();

        result.Should().Be(4);
    }
}