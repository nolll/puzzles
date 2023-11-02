using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201804;

public class Aoc201804Tests
{
    [Test]
    public void StrategyOne()
    {
        var puzzle = new GuardSleepPuzzle(Input);
        puzzle.StrategyOneGuardId.Should().Be(10);
        puzzle.StrategyOneMinute.Should().Be(24);
        puzzle.StrategyOneScore.Should().Be(240);
    }

    [Test]
    public void StrategyTwo()
    {
        var puzzle = new GuardSleepPuzzle(Input);
        puzzle.StrategyTwoGuardId.Should().Be(99);
        puzzle.StrategyTwoMinute.Should().Be(45);
        puzzle.StrategyTwoScore.Should().Be(4455);
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