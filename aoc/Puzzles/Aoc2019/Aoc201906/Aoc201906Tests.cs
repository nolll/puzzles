using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Aoc201906;

public class Aoc201906Tests
{
    [Test]
    public void ReturnsCorrectNumberOfOrbits()
    {
        const string input = """
COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
""";

        var calculator = new OrbitCalculator(input);
        var result = calculator.GetOrbitCount();

        result.Should().Be(42);
    }

    [Test]
    public void ReturnsDistanceFromMeToSanta()
    {
        const string input = """
COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN
""";

        var calculator = new OrbitCalculator(input);
        var result = calculator.GetSantaDistance();

        result.Should().Be(4);
    }
}