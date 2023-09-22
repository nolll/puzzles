using common.Puzzles;
using NUnit.Framework;

namespace Aoc.ConsoleTools;

public class ParameterTests
{
    [Test]
    public void NoParameters()
    {
        var result = Parameters.Parse("");

        Assert.That(result.Id, Is.Null);
        Assert.That(result.Tags, Is.Empty);
        Assert.That(result.ShowHelp, Is.False);
    }

    [TestCase("--id 1")]
    [TestCase("-i 1")]
    public void ParseDay(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.Id, Is.EqualTo(1));
    }

    [TestCase("--tags 1,test,3")]
    [TestCase("-t 1,test,3")]
    public void ParseYear(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.Tags[0], Is.EqualTo("1"));
        Assert.That(result.Tags[1], Is.EqualTo("test"));
        Assert.That(result.Tags[2], Is.EqualTo("3"));
    }
    
    [TestCase("--help")]
    [TestCase("--help true")]
    [TestCase("-h")]
    [TestCase("-h true")]
    public void ParseHelp(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.ShowHelp, Is.True);
    }
}