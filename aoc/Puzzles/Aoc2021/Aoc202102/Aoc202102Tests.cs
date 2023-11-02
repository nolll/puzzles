using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Aoc202102;

public class Aoc202102Tests
{
    [Test]
    public void Part1()
    {
        var validator = new SubmarineControl(Input.Trim(), false);
        validator.Move();

        validator.Result.Should().Be(150);
    }

    [Test]
    public void Part2()
    {
        var validator = new SubmarineControl(Input.Trim(), true);
        validator.Move();

        validator.Result.Should().Be(900);
    }

    private const string Input = """
forward 5
down 5
forward 8
up 3
down 8
forward 2
""";
}