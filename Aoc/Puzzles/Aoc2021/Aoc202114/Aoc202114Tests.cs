namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

public class Aoc202114Tests
{
    [Fact]
    public void OneStep() => Sut.Solve(Input, 1).Should().Be(1);

    [Fact]
    public void TwoSteps() => Sut.Solve(Input, 2).Should().Be(5);

    [Fact]
    public void TenSteps() => Sut.Solve(Input, 10).Should().Be(1588);

    [Fact]
    public void Part2() => Sut.Solve(Input, 40).Should().Be(2188189693529);

    private const string Input = """
                                 NNCB

                                 CH -> B
                                 HH -> N
                                 CB -> H
                                 NH -> C
                                 HB -> C
                                 HC -> B
                                 HN -> C
                                 NN -> C
                                 BH -> H
                                 NC -> B
                                 NB -> B
                                 BN -> B
                                 BB -> N
                                 BC -> B
                                 CC -> N
                                 CN -> C
                                 """;

    public Aoc202114 Sut => new();
}