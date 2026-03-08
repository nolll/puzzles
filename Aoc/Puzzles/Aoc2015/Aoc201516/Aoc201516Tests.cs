namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

public class Aoc201516Tests
{
    private const string Input = """
                                 Sue 1: pomeranians: 3, perfumes: 6, vizslas: 0
                                 Sue 2: vizslas: 0, perfumes: 1, trees: 3
                                 Sue 3: vizslas: 7, pomeranians: 1, akitas: 10
                                 """;

    [Fact]
    public void SelectsCorrectAuntSue() => Sut.Part1(Input).Should().Be(2);

    private static Aoc201516 Sut => new();
}