using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202017Tests : PuzzleTest<Aoc202017>
{
    [Fact]
    public void AfterSixIterations_3D()
    {
        const string input = """
                             .#.
                             ..#
                             ###
                             """;

        var cube = new Aoc202017.ConwayCube();
        var activeCubes = cube.Boot3D(input, 6);

        activeCubes.Should().Be(112);
    }

    [Fact]
    public void AfterSixIterations_4D()
    {
        const string input = """
                             .#.
                             ..#
                             ###
                             """;

        var cube = new Aoc202017.ConwayCube();
        var activeCubes = cube.Boot4D(input, 6);

        activeCubes.Should().Be(848);
    }
}