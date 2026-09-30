using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201607Tests : PuzzleTest<Aoc201607>
{
    [Theory]
    [InlineData("abba[mnop]qrst", true)]
    [InlineData("abcd[bddb]xyyx", false)]
    [InlineData("aaaa[qwer]tyui", false)]
    [InlineData("ioxxoj[asdfgh]zxcvbn", true)]
    public void SupportsTls(string ip, bool expected) => Aoc201607.SupportsTls(ip).Should().Be(expected);

    [Theory]
    [InlineData("aba[bab]xyz", true)]
    [InlineData("xyx[xyx]xyx", false)]
    [InlineData("aaa[kek]eke", true)]
    [InlineData("zazbz[bzb]cdb", true)]
    public void SupportsSsl(string ip, bool expected) => Aoc201607.SupportsSsl(ip).Should().Be(expected);
}