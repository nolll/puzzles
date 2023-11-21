using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aquaq.Puzzles.Aquaq36;

public class Aquaq36Tests
{
    [Test]
    public void SolveWithKnownNumbers()
    {
        var gridNumbers = "252 260 13 30 25 144 36 30 48 21 40 30 224 56 46 22"
            .Split().Select(int.Parse).ToArray();

        var inputNumbers = "1 2 2 5 6 6 8 10 14 16 21 23 24 26 28 42"
            .Split().Select(int.Parse).ToArray();

        var result = Aquaq36.Solve(gridNumbers, inputNumbers);

        result.Should().Be(142);
    }

    [Test]
    public void Factors()
    {
        //var gridNumbers = "10 12 25 99 45 20 16 28 64 20 15 14 8 36 11 16"
        var gridNumbers = "10 12 25 99 45 20"
            .Split().Select(int.Parse).ToArray();

        var result = Aquaq36.GetFactors(gridNumbers);

        var expected = new Dictionary<int, int[]>
        {
            { 10, new[] { 1, 2, 5, 10 } },
            { 12, new[] { 1, 2, 3, 4, 6, 12 } },
            { 25, new[] { 1, 5, 25 } },
            { 99, new[] { 1, 3, 9, 11, 33, 99 } },
            { 45, new[] { 1, 3, 5, 9, 15, 45 } },
            { 20, new[] { 1, 2, 4, 5, 10, 20 } }
        };
        result.Should().BeEquivalentTo(expected);
    }
}