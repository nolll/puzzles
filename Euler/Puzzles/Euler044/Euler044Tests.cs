using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler044;

public class Euler044Tests
{
    [Test]
    public void PentagonalNumbers()
    {
        var result = Euler044.GeneratePentagonalNumbers(10);

        result.Should().BeEquivalentTo(new List<int>
        {
            1, 5, 12, 22, 35, 51, 70, 92, 117, 145
        });
    }
}