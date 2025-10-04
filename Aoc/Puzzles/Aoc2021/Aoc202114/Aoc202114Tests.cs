namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

public class Aoc202114Tests
{
    [Fact]
    public void OneStep()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 1);

        result.Should().Be(1);
    }

    [Fact]
    public void TwoSteps()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 2);

        result.Should().Be(5);
    }

    [Fact]
    public void TenSteps()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 10);

        result.Should().Be(1588);
    }

    [Fact]
    public void Part2()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 40);

        result.Should().Be(2188189693529);
    }

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
}