using Pzl.Aoc.Puzzles.Aoc2017;
using Pzl.Tools.Cryptography;

namespace Tests.Aoc.Aoc2017;

public class Aoc201710Tests : PuzzleTest<Aoc201710>
{
    [Fact]
    public void SimulatesIntHash() => Sut.GetChecksum("3,4,1,5", 5).Should().Be(12);

    [Theory]
    [InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
    [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
    [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
    [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
    public void SimulatesAsciiHash(string input, string expected) => Sut.Part2(input).Should().Be(expected);
}