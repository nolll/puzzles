namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202213;

public class Aoc202213Tests
{
    [Fact]
    public void Part1()
    {
        var signal = new DistressSignal();
        var result = signal.Part1(Input);

        result.Should().Be(13);
    }

    [Fact]
    public void Parse1()
    {
        var result = DistressSignal.ParseSignalItem("[1,1,3,1,1]");

        result.Print().Should().Be("[1,1,3,1,1]");
    }

    [Fact]
    public void Parse2()
    {
        var result = DistressSignal.ParseSignalItem("[[1],4]");

        result.Print().Should().Be("[[1],4]");
    }

    [Fact]
    public void Parse3()
    {
        var result = DistressSignal.ParseSignalItem("[[[]]]");

        result.Print().Should().Be("[[[]]]");
    }

    [Fact]
    public void Parse4()
    {
        var result = DistressSignal.ParseSignalItem("[[8,7,6]]");

        result.Print().Should().Be("[[8,7,6]]");
    }

    [Fact]
    public void Parse5()
    {
        var result = DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");

        result.Print().Should().Be("[1,[2,[3,[4,[5,6,7]]]],8,9]");
    }

    [Fact]
    public void Compare1()
    {
        var left = DistressSignal.ParseSignalItem("[1,1,3,1,1]");
        var right = DistressSignal.ParseSignalItem("[1,1,5,1,1]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare2()
    {
        var left = DistressSignal.ParseSignalItem("[[1],[2,3,4]]");
        var right = DistressSignal.ParseSignalItem("[[1],4]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare3()
    {
        var left = DistressSignal.ParseSignalItem("[9]");
        var right = DistressSignal.ParseSignalItem("[[8,7,6]]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare4()
    {
        var left = DistressSignal.ParseSignalItem("[[4,4],4,4]");
        var right = DistressSignal.ParseSignalItem("[[4,4],4,4,4]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare5()
    {
        var left = DistressSignal.ParseSignalItem("[7,7,7,7]");
        var right = DistressSignal.ParseSignalItem("[7,7,7]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare6()
    {
        var left = DistressSignal.ParseSignalItem("[]");
        var right = DistressSignal.ParseSignalItem("[3]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare7()
    {
        var left = DistressSignal.ParseSignalItem("[[[]]]");
        var right = DistressSignal.ParseSignalItem("[[]]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare8()
    {
        var left = DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");
        var right = DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,0]]]],8,9]");
        var result = SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Part2()
    {
        var signal = new DistressSignal();
        var result = signal.Part2(Input);

        result.Should().Be(140);
    }

    private const string Input = """
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
                                 [1,[2,[3,[4,[5,6,0]]]],8,9]
                                 """;
}