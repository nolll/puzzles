using NUnit.Framework;

namespace App.Puzzles.Year2017.Day22;

public class Year2017Day22Tests
{
    private const string Input = @"
..#
#..
...";

    [TestCase(7, 5)]
    [TestCase(70, 41)]
    [TestCase(10000, 5587)]
    public void InfectionCountIsCorrectForPart1(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart1(iterations);

        Assert.That(infectionCount, Is.EqualTo(expected));
    }

    [TestCase(100, 26)]
    [TestCase(10_000_000, 2_511_944)]
    public void InfectionCountIsCorrectForPart2(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart2(iterations);

        Assert.That(infectionCount, Is.EqualTo(expected));
    }
}