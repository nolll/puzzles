using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day13;

public class Year2022Day13Tests
{
    [Test]
    public void Part1()
    {
        var signal = new DistressSignal();
        var result = signal.Part1(Input);

        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void Parse1()
    {
        var signal = new DistressSignal();
        var result = signal.ParseSignalItem("[1,1,3,1,1]");

        Assert.That(result.Print(), Is.EqualTo("[1,1,3,1,1]"));
    }

    [Test]
    public void Parse2()
    {
        var signal = new DistressSignal();
        var result = signal.ParseSignalItem("[[1],4]");

        Assert.That(result.Print(), Is.EqualTo("[[1],4]"));
    }

    [Test]
    public void Parse3()
    {
        var signal = new DistressSignal();
        var result = signal.ParseSignalItem("[[[]]]");

        Assert.That(result.Print(), Is.EqualTo("[[[]]]"));
    }

    [Test]
    public void Parse4()
    {
        var signal = new DistressSignal();
        var result = signal.ParseSignalItem("[[8,7,6]]");

        Assert.That(result.Print(), Is.EqualTo("[[8,7,6]]"));
    }

    [Test]
    public void Parse5()
    {
        var signal = new DistressSignal();
        var result = signal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");

        Assert.That(result.Print(), Is.EqualTo("[1,[2,[3,[4,[5,6,7]]]],8,9]"));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = @"
[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";
}