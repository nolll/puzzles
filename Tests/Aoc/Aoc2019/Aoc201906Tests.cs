using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201906Tests : PuzzleTest<Aoc201906>
{
    [Fact]
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

        var calculator = new Aoc201906.OrbitCalculator(input);
        var result = calculator.GetOrbitCount();

        result.Should().Be(42);
    }

    [Fact]
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

        var calculator = new Aoc201906.OrbitCalculator(input);
        var result = calculator.GetSantaDistance();

        result.Should().Be(4);
    }
}