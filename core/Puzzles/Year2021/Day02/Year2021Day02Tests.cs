using NUnit.Framework;

namespace App.Puzzles.Year2021.Day02;

public class Year2021Day02Tests
{
    [Test]
    public void Part1()
    {
        var validator = new SubmarineControl(Input, false);
        validator.Move();

        Assert.That(validator.Result, Is.EqualTo(150));
    }

    [Test]
    public void Part2()
    {
        var validator = new SubmarineControl(Input, true);
        validator.Move();

        Assert.That(validator.Result, Is.EqualTo(900));
    }

    private const string Input = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
}