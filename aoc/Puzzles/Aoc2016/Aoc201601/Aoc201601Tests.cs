using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201601;

public class Aoc201601Tests
{
    [TestCase("R2, L3", 5)]
    [TestCase("R2, R2, R2", 2)]
    [TestCase("R5, L5, R5, R3", 12)]
    public void ManhattanDistanceToTargetIsCorrect(string input, int expected)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);

        calc.DistanceToTarget.Should().Be(expected);
    }
}