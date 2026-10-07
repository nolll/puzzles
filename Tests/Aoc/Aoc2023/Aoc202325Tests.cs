using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202325Tests : PuzzleTest<Aoc202325>
{
    [Fact]
    public void Part1()
    {
        const string input = """
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

        Sut.Part1(input).Should().Be(54);
    }
}