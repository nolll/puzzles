namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201616;

public class Aoc201616Tests
{
    [Theory]
    [InlineData("1", "100")]
    [InlineData("0", "001")]
    [InlineData("11111", "11111000000")]
    [InlineData("111100001010", "1111000010100101011110000")]
    public void DataIsCorrect(string input, string expected)
    {
        var dragonCurve = new DragonCurve();
        var data = dragonCurve.ApplyAlgorithm(input);

        data.Should().Be(expected);
    }

    [Fact]
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

    [Fact]
    public void ChecksumIsCorrect()
    {
        const string input = "110010110100";
        const string expected = "100";

        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Checksum(input);

        checksum.Should().Be(expected);
    }
}