using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201804;

public class Year2018Day04Tests
{
    [Test]
    public void StrategyOne()
    {
        var puzzle = new GuardSleepPuzzle(Input);
        Assert.AreEqual(10, puzzle.StrategyOneGuardId);
        Assert.AreEqual(24, puzzle.StrategyOneMinute);
        Assert.AreEqual(240, puzzle.StrategyOneScore);
    }

    [Test]
    public void StrategyTwo()
    {
        var puzzle = new GuardSleepPuzzle(Input);
        Assert.AreEqual(99, puzzle.StrategyTwoGuardId);
        Assert.AreEqual(45, puzzle.StrategyTwoMinute);
        Assert.AreEqual(4455, puzzle.StrategyTwoScore);
    }

    private const string Input = """
[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up
""";
}