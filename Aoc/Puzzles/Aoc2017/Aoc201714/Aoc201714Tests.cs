using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201714;

public class Aoc201714Tests
{
    [Test]
    public void UsedSquaresAreCorrect()
    {
        const string input = "flqrgnkx";

        var defragmenter = new DiskDefragmenter(input);

        defragmenter.UsedCount.Should().Be(8108);
    }

    [Test]
    public void FindsRegions()
    {
        const string input = "flqrgnkx";

        var defragmenter = new DiskDefragmenter(input);

        defragmenter.RegionCount.Should().Be(1242);
    }
}