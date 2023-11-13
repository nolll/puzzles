using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202001;

public class Aoc202001Tests
{
    [Test]
    public void FindTwoNumbers()
    {
        const string input = """
1721
979
366
299
675
1456
""";

        var sumFinder = new SumFinder(input.Trim());
        var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 2);

        numbers[0].Should().Be(1721);
        numbers[1].Should().Be(299);
    }

    [Test]
    public void FindThreeNumbers()
    {
        const string input = """
1721
979
366
299
675
1456
""";

        var sumFinder = new SumFinder(input.Trim());
        var numbers = sumFinder.FindNumbersThatAddUpTo(2020, 3);

        numbers[0].Should().Be(979);
        numbers[1].Should().Be(366);
        numbers[2].Should().Be(675);
    }
}