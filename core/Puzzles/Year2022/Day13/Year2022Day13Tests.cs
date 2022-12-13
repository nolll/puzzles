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
    public void Compare1()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[1,1,3,1,1]");
        var right = signal.ParseSignalItem("[1,1,5,1,1]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Compare2()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[[1],[2,3,4]]");
        var right = signal.ParseSignalItem("[[1],4]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Compare3()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[9]");
        var right = signal.ParseSignalItem("[[8,7,6]]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare4()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[[4,4],4,4]");
        var right = signal.ParseSignalItem("[[4,4],4,4,4]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Compare5()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[7,7,7,7]");
        var right = signal.ParseSignalItem("[7,7,7]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare6()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[]");
        var right = signal.ParseSignalItem("[3]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Compare7()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[[[]]]");
        var right = signal.ParseSignalItem("[[]]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare8()
    {
        var signal = new DistressSignal();
        var left = signal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");
        var right = signal.ParseSignalItem("[1,[2,[3,[4,[5,6,0]]]],8,9]");
        var pair = new SignalPair(left, right);
        var result = pair.Compare();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Part2()
    {
        var signal = new DistressSignal();
        var result = signal.Part2(Input);

        Assert.That(result, Is.EqualTo(140));
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