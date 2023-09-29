using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201714;

public class Aoc201714Tests
{
    [Test]
    public void UsedSquaresAreCorrect()
    {
        const string input = "flqrgnkx";

        var defragmenter = new DiskDefragmenter(input);

        Assert.That(defragmenter.UsedCount, Is.EqualTo(8108));
    }

    [Test]
    public void FindsRegions()
    {
        const string input = "flqrgnkx";

        var defragmenter = new DiskDefragmenter(input);

        Assert.That(defragmenter.RegionCount, Is.EqualTo(1242));
    }
}