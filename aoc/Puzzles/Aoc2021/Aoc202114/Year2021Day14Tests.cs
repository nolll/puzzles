using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Day14;

public class Year2021Day14Tests
{
    [Test]
    public void OneStep()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 1);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void TwoSteps()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 2);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void TenSteps()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 10);

        Assert.That(result, Is.EqualTo(1588));
    }

    [Test]
    public void Part2()
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(Input, 40);

        Assert.That(result, Is.EqualTo(2188189693529));
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