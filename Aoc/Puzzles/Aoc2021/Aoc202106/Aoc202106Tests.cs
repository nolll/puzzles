using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202106;

public class Aoc202106Tests
{
    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    [TestCase(256, 26_984_457_539)]
    public void Test(int days, long expected)
    {
        var fishCounter = new FishCounter(Input);
        var result = fishCounter.FishCountAfter(days);

        result.Should().Be(expected);
    }
        
    private const string Input = "3,4,3,1,2";
}