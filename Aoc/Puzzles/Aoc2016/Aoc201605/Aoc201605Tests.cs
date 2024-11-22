using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201605;

public class Aoc201605Tests
{
    [Test]
    public void GeneratesPasswordWithFirstAlgorithm()
    {
        const string input = "abc";
        var generator = new PasswordGenerator();
        var pwd = generator.Generate1(input);

        pwd.Should().Be("18f47a30");
    }

    [Test]
    public void GeneratesPasswordWithSecondAlgorithm()
    {
        const string input = "abc";
        var generator = new PasswordGenerator();
        var pwd = generator.Generate2(input);

        pwd.Should().Be("05ace8e3");
    }
}