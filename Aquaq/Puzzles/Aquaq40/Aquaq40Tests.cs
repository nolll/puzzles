using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq40;

public class Aquaq40Tests
{
    private const string Input = "0 1 2 4 6 8 9 8 6 4 2 3 5 6 5 4 5 7 8 6 4 2 1 0";

    [Test]
    public void FindPeaks()
    {
        var result = Aquaq40.FindPeakIndices(Input);

        result.Should().BeEquivalentTo(new[] { 6, 13, 18 });
    }

    [Test]
    public void Sum()
    {
        var result = Aquaq40.GetSum(Input);

        result.Should().Be(17);
    }
}