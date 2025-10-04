namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202423;

public class Aoc202423Tests
{
    private const string Input = """
                                 kh-tc
                                 qp-kh
                                 de-cg
                                 ka-co
                                 yn-aq
                                 qp-ub
                                 cg-tb
                                 vc-aq
                                 tb-ka
                                 wh-tc
                                 yn-cg
                                 kh-ub
                                 ta-co
                                 de-co
                                 tc-td
                                 tb-wq
                                 wh-td
                                 ta-ka
                                 td-qp
                                 aq-cg
                                 wq-ub
                                 ub-vc
                                 de-ta
                                 wq-aq
                                 wq-vc
                                 wh-yn
                                 ka-de
                                 kh-ta
                                 co-tc
                                 wh-qp
                                 tb-vc
                                 td-yn
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("7");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("co,de,ka,ta");

    private static Aoc202423 Sut => new();
}