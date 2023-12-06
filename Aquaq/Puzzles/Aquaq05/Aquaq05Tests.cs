using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq05;

public class Aquaq05Tests
{
    [Test]
    public void RotateDiceLeft()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateLeft();

        dice.Front.Should().Be(5);
        dice.Back.Should().Be(2);
        dice.Left.Should().Be(1);
        dice.Right.Should().Be(6);
        dice.Top.Should().Be(3);
        dice.Bottom.Should().Be(4);
    }

    [Test]
    public void RotateDiceRight()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateRight();

        dice.Front.Should().Be(2);
        dice.Back.Should().Be(5);
        dice.Left.Should().Be(6);
        dice.Right.Should().Be(1);
        dice.Top.Should().Be(3);
        dice.Bottom.Should().Be(4);
    }

    [Test]
    public void RotateDiceUp()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateUp();

        dice.Front.Should().Be(4);
        dice.Back.Should().Be(3);
        dice.Left.Should().Be(2);
        dice.Right.Should().Be(5);
        dice.Top.Should().Be(1);
        dice.Bottom.Should().Be(6);
    }

    [Test]
    public void RotateDiceDown()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateDown();

        dice.Front.Should().Be(3);
        dice.Back.Should().Be(4);
        dice.Left.Should().Be(2);
        dice.Right.Should().Be(5);
        dice.Top.Should().Be(6);
        dice.Bottom.Should().Be(1);
    }

    [Test]
    public void FindSumOfIndexes() =>
        Aquaq05.FindSumOfIndexesWithMatchingDice("LRDLU")
            .Should().Be(5);
}