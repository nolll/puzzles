using NUnit.Framework;

namespace Core.Puzzles.Year2017.Day07;

public class Year2017Day07Tests
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

    [Test]
    public void FindsNameOfBottomProgram()
    {
        var towers = new RecursiveTowers(Input);
        var name = towers.BottomName;

        Assert.That(name, Is.EqualTo("tknk"));
    }

    [Test]
    public void FindsWeightDiff()
    {
        var towers = new RecursiveTowers(Input);
        var diff = towers.AdjustedWeight;

        Assert.That(diff, Is.EqualTo(60));
    }
}