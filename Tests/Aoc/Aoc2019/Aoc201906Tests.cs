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

        Sut.Part1(input).Should().Be(42);
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

        Sut.Part2(input).Should().Be(4);
    }
}