using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201516Tests : PuzzleTest<Aoc201516>
{
    private const string Input = """
                                 Sue 1: pomeranians: 3, perfumes: 6, vizslas: 0
                                 Sue 2: vizslas: 0, perfumes: 1, trees: 3
                                 Sue 3: vizslas: 7, pomeranians: 1, akitas: 10
                                 """;

    [Fact]
    public void SelectsCorrectAuntSue() => Sut.Part1(Input).Should().Be(2);
}