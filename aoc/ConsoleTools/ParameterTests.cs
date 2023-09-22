using NUnit.Framework;

namespace Aoc.ConsoleTools;

public class ParameterTests
{
    [Test]
    public void NoParameters()
    {
        var result = Parameters.Parse("");

        Assert.That(result.Id, Is.Null);
        Assert.That(result.Year, Is.Null);
        Assert.That(result.RunSlowOnly, Is.False);
        Assert.That(result.RunCommentedOnly, Is.False);
        Assert.That(result.ShowHelp, Is.False);
    }

    [TestCase("--id 1")]
    [TestCase("-i 1")]
    public void ParseDay(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.Id, Is.EqualTo(1));
    }

    [TestCase("--year 1")]
    [TestCase("-y 1")]
    public void ParseYear(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.Year, Is.EqualTo(1));
    }

    [TestCase("--slow")]
    [TestCase("--slow true")]
    [TestCase("-s")]
    [TestCase("-s true")]
    public void ParseSlow(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.RunSlowOnly, Is.True);
    }

    [TestCase("--comment")]
    [TestCase("--comment true")]
    [TestCase("-c")]
    [TestCase("-c true")]
    public void ParseCommented(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.RunCommentedOnly, Is.True);
    }

    [TestCase("--fun")]
    [TestCase("--fun true")]
    [TestCase("-f")]
    [TestCase("-f true")]
    public void ParseFun(string input)
    {
        var result = Parameters.Parse(input);

        Assert.That(result.RunFunOnly, Is.True);
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