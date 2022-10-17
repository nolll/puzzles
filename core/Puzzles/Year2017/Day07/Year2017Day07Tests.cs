using NUnit.Framework;

namespace Core.Puzzles.Year2017.Day07;

public class Year2017Day07Tests
{
    [Test]
    public void FindsNameOfBottomProgram()
    {
        const string input = @"
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
cntj (57)";

        var towers = new RecursiveTowers(input.Trim());
        var name = towers.BottomName;

        Assert.That(name, Is.EqualTo("tknk"));
    }

    [Test]
    public void FindsWeightDiff()
    {
        const string input = @"
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
cntj (57)";

        var towers = new RecursiveTowers(input.Trim());
        var diff = towers.AdjustedWeight;

        Assert.That(diff, Is.EqualTo(60));
    }
}