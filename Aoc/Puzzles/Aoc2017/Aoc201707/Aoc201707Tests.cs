namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201707;

public class Aoc201707Tests
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
    public void FindsNameOfBottomProgram()
    {
        var towers = new RecursiveTowers(Input);
        var name = towers.BottomName;

        name.Should().Be("tknk");
    }

    [Fact]
    public void FindsWeightDiff()
    {
        var towers = new RecursiveTowers(Input);
        var diff = towers.AdjustedWeight;

        diff.Should().Be(60);
    }
}