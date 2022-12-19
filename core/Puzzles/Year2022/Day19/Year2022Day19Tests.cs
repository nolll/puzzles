using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day19;

public class RobotFactory
{
    public int Part1(string input)
    {
        return 0;
    }
}

public class Year2022Day19Tests
{
    [Test]
    public void Part1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(Input);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = """
Blueprint 1:
  Each ore robot costs 4 ore.
  Each clay robot costs 2 ore.
  Each obsidian robot costs 3 ore and 14 clay.
  Each geode robot costs 2 ore and 7 obsidian.

Blueprint 2:
  Each ore robot costs 2 ore.
  Each clay robot costs 3 ore.
  Each obsidian robot costs 3 ore and 8 clay.
  Each geode robot costs 3 ore and 12 obsidian.
""";
}