using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq05;

public class Aquaq05Tests
{
    [Test]
    public void RotateDiceLeft()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateLeft();

        Assert.That(dice.Front, Is.EqualTo(5));
        Assert.That(dice.Back, Is.EqualTo(2));
        Assert.That(dice.Left, Is.EqualTo(1));
        Assert.That(dice.Right, Is.EqualTo(6));
        Assert.That(dice.Top, Is.EqualTo(3));
        Assert.That(dice.Bottom, Is.EqualTo(4));
    }

    [Test]
    public void RotateDiceRight()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateRight();

        Assert.That(dice.Front, Is.EqualTo(2));
        Assert.That(dice.Back, Is.EqualTo(5));
        Assert.That(dice.Left, Is.EqualTo(6));
        Assert.That(dice.Right, Is.EqualTo(1));
        Assert.That(dice.Top, Is.EqualTo(3));
        Assert.That(dice.Bottom, Is.EqualTo(4));
    }

    [Test]
    public void RotateDiceUp()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateUp();

        Assert.That(dice.Front, Is.EqualTo(4));
        Assert.That(dice.Back, Is.EqualTo(3));
        Assert.That(dice.Left, Is.EqualTo(2));
        Assert.That(dice.Right, Is.EqualTo(5));
        Assert.That(dice.Top, Is.EqualTo(1));
        Assert.That(dice.Bottom, Is.EqualTo(6));
    }

    [Test]
    public void RotateDiceDown()
    {
        var dice = new Dice(1, 6, 2, 5, 3, 4);
        dice.RotateDown();

        Assert.That(dice.Front, Is.EqualTo(3));
        Assert.That(dice.Back, Is.EqualTo(4));
        Assert.That(dice.Left, Is.EqualTo(2));
        Assert.That(dice.Right, Is.EqualTo(5));
        Assert.That(dice.Top, Is.EqualTo(6));
        Assert.That(dice.Bottom, Is.EqualTo(1));
    }

    [Test]
    public void FindSumOfIndexes()
    {
        var result = Aquaq05.FindSumOfIndexesWithMatchingDice("LRDLU");

        Assert.That(result, Is.EqualTo(5));
    }
}