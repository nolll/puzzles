namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202209;

public class Aoc202209Tests
{
    [Fact]
    public void Part1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(Input1);

        result.Should().Be(13);
    }

    [Fact]
    public void Part2Example1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(Input1);

        result.Should().Be(1);
    }

    [Fact]
    public void Part2Example2()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(Input2);

        result.Should().Be(36);
    }

    private const string Input1 = """
                                  R 4
                                  U 4
                                  L 3
                                  D 1
                                  R 4
                                  D 1
                                  L 5
                                  R 2
                                  """;

    private const string Input2 = """
                                  R 5
                                  U 8
                                  L 8
                                  D 3
                                  R 17
                                  D 10
                                  L 25
                                  U 20
                                  """;
}