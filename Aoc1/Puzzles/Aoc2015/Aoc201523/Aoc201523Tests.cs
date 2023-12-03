using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201523;

public class Aoc201523Tests
{
    [Test]
    public void RegisterAContains2()
    {
        const string input = """
inc a
jio a, +2
tpl a
inc a
""";

        var computer = new ChristmasComputer();
        computer.Run(input.Trim());

        computer.RegisterA.Should().Be(2);
    }
}