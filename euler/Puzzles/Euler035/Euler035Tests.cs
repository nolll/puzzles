using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler035;

public class Euler035Tests
{
    [Test]
    public void Rotations()
    {
        var result = Euler035.GetRotations(12345).ToArray();

        result.Length.Should().Be(5);
        result[0].Should().Be(12345);
        result[1].Should().Be(23451);
        result[2].Should().Be(34512);
        result[3].Should().Be(45123);
        result[4].Should().Be(51234);
    }
}