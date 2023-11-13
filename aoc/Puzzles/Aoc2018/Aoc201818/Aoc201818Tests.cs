using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201818;

public class Aoc201818Tests
{
    [Test]
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

        var collection = new LumberCollection(input);
        collection.Run(10);
        collection.ResourceValue.Should().Be(1147);
    }
}