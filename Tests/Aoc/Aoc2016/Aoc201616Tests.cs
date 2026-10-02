using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201616Tests : PuzzleTest<Aoc201616>
{
    [Theory]
    [InlineData("1", "100")]
    [InlineData("0", "001")]
    [InlineData("11111", "11111000000")]
    [InlineData("111100001010", "1111000010100101011110000")]
    public void DataIsCorrect(string input, string expected) => Sut.ApplyAlgorithm(input).Should().Be(expected);

    [Fact]
    public void DataAndLengthIsCorrect() => Sut.FillDisk("111100001010", 20).Should().Be("11110000101001010111");

    [Fact]
    public void ChecksumIsCorrect() => Sut.Checksum("110010110100").Should().Be("100");
}