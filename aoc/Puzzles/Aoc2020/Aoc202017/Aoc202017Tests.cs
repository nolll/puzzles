using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2020.Aoc202017;

public class Aoc202017Tests
{
    [Test]
    public void AfterSixIterations_3D()
    {
        const string input = """
.#.
..#
###
""";

        var cube = new ConwayCube();
        var activeCubes = cube.Boot3D(input, 6);

        Assert.That(activeCubes, Is.EqualTo(112));
    }

    [Test]
    public void AfterSixIterations_4D()
    {
        const string input = """
.#.
..#
###
""";

        var cube = new ConwayCube();
        var activeCubes = cube.Boot4D(input, 6);

        Assert.That(activeCubes, Is.EqualTo(848));
    }
}