using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201714Tests
{
    [Fact]
    public void UsedSquaresAreCorrect()
    {
        const string input = "flqrgnkx";

        var defragmenter = new Aoc201714.DiskDefragmenter(input);

        defragmenter.UsedCount.Should().Be(8108);
    }

    [Fact]
    public void FindsRegions()
    {
        const string input = "flqrgnkx";

        var defragmenter = new Aoc201714.DiskDefragmenter(input);

        defragmenter.RegionCount.Should().Be(1242);
    }
}