using NUnit.Framework;

namespace App.Puzzles.Year2021.Day23;

public class Year2021Day23Tests
{
    [Test]
    public void Part1()
    {
        var burrow = new AmphipodBurrow(Input);
        var result = burrow.Arrange();

        Assert.That(result, Is.EqualTo(12521));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = @"
#############
#...........#
###B#C#B#D###
###A#D#C#A###
#############";
}