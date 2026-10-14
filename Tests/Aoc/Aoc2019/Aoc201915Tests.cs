using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201915Tests : PuzzleTest<Aoc201915>
{
    private const string Input = """
                                  ##
                                 #..##
                                 #.#..#
                                 #.X.#
                                  ###
                                 """;

    [Fact]
    public void Returns4Minutes() => Sut.Fill(Input).Should().Be(4);
}