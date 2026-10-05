using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201707Tests : PuzzleTest<Aoc201707>
{
    private const string Input = """
                                 pbga (66)
                                 xhth (57)
                                 ebii (61)
                                 havc (66)
                                 ktlj (57)
                                 fwft (72) -> ktlj, cntj, xhth
                                 qoyq (66)
                                 padx (45) -> pbga, havc, qoyq
                                 tknk (41) -> ugml, padx, fwft
                                 jptl (61)
                                 ugml (68) -> gyxo, ebii, jptl
                                 gyxo (61)
                                 cntj (57)
                                 """;

    [Fact]
    public void BothParts()
    {
        var (name, weight) = Sut.Run(Input);

        name.Should().Be("tknk");
        weight.Should().Be(60);
    }
}