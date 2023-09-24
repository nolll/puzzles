using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Aoc201605;

public class Year2016Day05Tests
{
    [Test]
    public void GeneratesPasswordWithFirstAlgorithm()
    {
        const string input = "abc";
        var generator = new PasswordGenerator();
        var pwd = generator.Generate1(input);

        Assert.That(pwd, Is.EqualTo("18f47a30"));
    }

    [Test]
    public void GeneratesPasswordWithSecondAlgorithm()
    {
        const string input = "abc";
        var generator = new PasswordGenerator();
        var pwd = generator.Generate2(input);

        Assert.That(pwd, Is.EqualTo("05ace8e3"));
    }
}