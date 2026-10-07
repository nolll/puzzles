using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201818Tests : PuzzleTest<Aoc201818>
{
    [Fact]
    public void ResourceValueIsCorrect()
    {
        const string input = """
                             .#.#...|#.
                             .....#|##|
                             .|..|...#.
                             ..|#.....#
                             #.#|||#|#|
                             ...#.||...
                             .|....|...
                             ||...#|.#|
                             |.||||..|.
                             ...#.|..|.
                             """;

        var collection = new Aoc201818.LumberCollection(input);
        collection.Run(10);
        collection.ResourceValue.Should().Be(1147);
    }
}