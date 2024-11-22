using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq29;

public class Aquaq29Tests
{
    [Test]
    public void CountGoodNumbers()
    {
        var input = new List<int>
        {
            1,
            45,
            777,
            1245,
            10,
            97,
            2099
        };

        Aquaq29.CountGoodNumbers(input)
            .Should().Be(4);
    }
}