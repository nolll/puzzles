using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Aoc202102;

public class Year2021Day02Tests
{
    [Test]
    public void Part1()
    {
        var validator = new SubmarineControl(Input.Trim(), false);
        validator.Move();

        Assert.That(validator.Result, Is.EqualTo(150));
    }

    [Test]
    public void Part2()
    {
        var validator = new SubmarineControl(Input.Trim(), true);
        validator.Move();

        Assert.That(validator.Result, Is.EqualTo(900));
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