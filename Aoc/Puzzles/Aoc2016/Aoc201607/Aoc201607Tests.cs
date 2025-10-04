namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

public class Aoc201607Tests
{
    [Theory]
    [InlineData("abba[mnop]qrst", true)]
    [InlineData("abcd[bddb]xyyx", false)]
    [InlineData("aaaa[qwer]tyui", false)]
    [InlineData("ioxxoj[asdfgh]zxcvbn", true)]
    public void SupportsTls(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsTls(ip);

        result.Should().Be(result);
    }

    [Theory]
    [InlineData("aba[bab]xyz", true)]
    [InlineData("xyx[xyx]xyx", false)]
    [InlineData("aaa[kek]eke", true)]
    [InlineData("zazbz[bzb]cdb", true)]
    public void SupportsSsl(string ip, bool expected)
    {
        var ipTester = new IpTester();
        var result = ipTester.SupportsSsl(ip);

        result.Should().Be(result);
    }
}