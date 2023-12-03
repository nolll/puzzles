using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq12;

public class Aquaq12Tests
{
    private const string Input =
"""
1 2
0 3
1 1
0 1
1 5
""";

    [Test]
    public void RideTheLift()
    {
        var result = Aquaq12.RideLift(Input);

        result.Should().Be(7);
    }
}