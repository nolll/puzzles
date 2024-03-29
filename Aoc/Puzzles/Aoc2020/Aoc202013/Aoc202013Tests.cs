using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202013;

public class Aoc202013Tests
{
    [Test]
    public void EarliestDeparture()
    {
        const string input = """
                             939
                             7,13,x,x,59,x,31,19
                             """;

        var scheduler = new BusScheduler1(input.Trim());
        var value = scheduler.GetBusValue();

        value.Should().Be(295);
    }

    [TestCase("0\r\n7,13,x,x,59,x,31,19", 1_068_781)]
    [TestCase("0\r\n17,x,13,19", 3_417)]
    [TestCase("0\r\n67,7,59,61", 754_018)]
    [TestCase("0\r\n67,x,7,59,61", 779_210)]
    [TestCase("0\r\n67,7,x,59,61", 1_261_476)]
    [TestCase("0\r\n1789,37,47,1889", 1_202_161_486)]
    public void ScheduleContest(string input, long expected)
    {
        var scheduler = new BusScheduler2(input);
        var value = scheduler.GetContestMinute();

        value.Should().Be(expected);
    }
}