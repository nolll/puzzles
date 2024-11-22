using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201616;

public class Aoc201616Tests
{
    [TestCase("1", "100")]
    [TestCase("0", "001")]
    [TestCase("11111", "11111000000")]
    [TestCase("111100001010", "1111000010100101011110000")]
    public void DataIsCorrect(string input, string expected)
    {
        var dragonCurve = new DragonCurve();
        var data = dragonCurve.ApplyAlgorithm(input);

        data.Should().Be(expected);
    }

    [Test]
    public void DataAndLengthIsCorrect()
    {
        const string input = "111100001010";
        const string expected = "11110000101001010111";
        const int expectedLength = 20;

        var dragonCurve = new DragonCurve();
        var data = dragonCurve.FillDisk(input, expectedLength);

        data.Should().Be(expected);
        data.Length.Should().Be(expectedLength);
    }

    [Test]
    public void ChecksumIsCorrect()
    {
        const string input = "110010110100";
        const string expected = "100";

        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Checksum(input);

        checksum.Should().Be(expected);
    }
}