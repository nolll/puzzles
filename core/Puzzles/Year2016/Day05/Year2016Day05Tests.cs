using NUnit.Framework;

namespace App.Puzzles.Year2016.Day05;

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
    [Ignore("Too slow")]
    public void GeneratesPasswordWithSecondAlgorithm()
    {
        const string input = "abc";
        var generator = new PasswordGenerator();
        var pwd = generator.Generate2(input);

        Assert.That(pwd, Is.EqualTo("05ace8e3"));
    }
}