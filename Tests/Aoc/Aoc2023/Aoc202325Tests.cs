using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202325Tests : PuzzleTest<Aoc202325>
{
    private const string Input = """
                                 jqt: rhn xhk nvd
                                 rsh: frs pzl lsr
                                 xhk: hfx
                                 cmg: qnr nvd lhk bvb
                                 rhn: xhk bvb hfx
                                 bvb: xhk hfx
                                 pzl: lsr hfx nvd
                                 qnr: nvd
                                 ntq: jqt hfx bvb xhk
                                 nvd: lhk
                                 lsr: lhk
                                 rzs: qnr cmg lsr rsh
                                 frs: qnr lhk lsr
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(54);
}