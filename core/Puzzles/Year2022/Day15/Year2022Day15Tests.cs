using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day15;

public class Year2022Day15Tests
{
    [Test]
    public void Part1()
    {
        var zone = new BeaconZone();
        var result = zone.Part1(Input, 10, false);

        Assert.That(result, Is.EqualTo(26));
    }

    [Test]
    public void Part2()
    {
        var zone = new BeaconZone();
        var result = zone.Part2(Input, 20);

        Assert.That(result, Is.EqualTo(56_000_011));
    }

    private const string Input = """
Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3
""";
}