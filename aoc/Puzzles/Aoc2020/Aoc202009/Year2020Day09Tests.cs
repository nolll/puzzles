using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2020.Day09;

public class Year2020Day09Tests
{
    private const string Input = """
35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576
""";

    [Test]
    public void FirstInvalidNumber()
    {
        var port = new XmasPort(Input.Trim(), 5);
        var num = port.FindFirstInvalidNumber();

        Assert.That(num, Is.EqualTo(127));
    }

    [Test]
    public void FirstWeakness()
    {
        var port = new XmasPort(Input.Trim(), 5);
        var num = port.FindWeakness();

        Assert.That(num, Is.EqualTo(62));
    }
}