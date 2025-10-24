namespace Pzl.Client.Params;

public class ParameterTests
{
    [Fact]
    public void NoParameters()
    {
        var result = Parameters.Parse("");

        result.Query.Should().BeNull();
        result.Tags.Should().BeEmpty();
        result.ShowHelp.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("--tags 1,test,3")]
    [InlineData("-t 1,test,3")]
    public void ParseTags(string input)
    {
        var result = Parameters.Parse(input);

        result.Tags[0].Should().Be("1");
        result.Tags[1].Should().Be("test");
        result.Tags[2].Should().Be("3");
    }

    [Theory]
    [InlineData("--search foo")]
    [InlineData("-s foo")]
    public void ParseSearch(string input)
    {
        var result = Parameters.Parse(input);

        result.Query.Should().Be("foo");
    }

    [Theory]
    [InlineData("--help")]
    [InlineData("--help true")]
    [InlineData("-h")]
    [InlineData("-h true")]
    public void ParseHelp(string input)
    {
        var result = Parameters.Parse(input);

        result.ShowHelp.Should().BeTrue();
    }

    [Theory]
    [InlineData("--aaa", true)]
    [InlineData("--aaa true", true)]
    [InlineData("--aaa false", false)]
    [InlineData("--aaa bad", null)]
    [InlineData("--bbb", false)]
    [InlineData("-a", true)]
    [InlineData("-a true", true)]
    [InlineData("-a false", false)]
    [InlineData("-a bad", null)]
    [InlineData("-b", false)]
    public void ParseBool(string input, bool? expected)
    {
        var parser = new ParameterParser(input.Split(' '));
        var result = parser.GetBoolValue("-a", "--aaa");

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("--aaa", null)]
    [InlineData("--aaa 1", 1)]
    [InlineData("--aaa 2", 2)]
    [InlineData("--aaa bad", null)]
    [InlineData("--bbb", null)]
    [InlineData("-a", null)]
    [InlineData("-a 1", 1)]
    [InlineData("-a 2", 2)]
    [InlineData("-a bad", null)]
    [InlineData("-b", null)]
    public void ParseInt(string input, int? expected)
    {
        var parser = new ParameterParser(input.Split(' '));
        var result = parser.GetIntValue("-a", "--aaa");

        result.Should().Be(expected);
    }
}