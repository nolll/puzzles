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
        var gridNumbers = "10 12 25"
            .Split().Select(int.Parse).ToArray();

        var result = Aquaq36.GetAllFactors(gridNumbers);

        var expected = new[] { 1, 1, 1, 2, 2, 3, 4, 5, 5, 6, 10, 12, 25 };
        
        result.Should().BeEquivalentTo(expected);
    }
}