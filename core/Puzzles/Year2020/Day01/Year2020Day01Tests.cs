using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day01;

public class Year2020Day01Tests
{
    [Test]
    public void FindTwoNumbers()
    {
        const string input = @"
1721
979
366
299
675
1456";

        var sumFinder = new SumFinder(input.Trim());
        var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 2);

        Assert.That(numbers[0], Is.EqualTo(1721));
        Assert.That(numbers[1], Is.EqualTo(299));
    }

    [Test]
    public void FindThreeNumbers()
    {
        const string input = @"
1721
979
366
299
675
1456";

        var sumFinder = new SumFinder(input.Trim());
        var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 3);

        Assert.That(numbers[0], Is.EqualTo(979));
        Assert.That(numbers[1], Is.EqualTo(366));
        Assert.That(numbers[2], Is.EqualTo(675));
    }
}