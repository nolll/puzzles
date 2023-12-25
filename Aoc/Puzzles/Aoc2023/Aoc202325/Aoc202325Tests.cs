using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202325;

public class Aoc202325Tests
{
    [Test]
    public void DivideIntoGroups()
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

        var result = Aoc202325.DivideIntoGroups(input);

        result.Should().Be(54);
    }
}