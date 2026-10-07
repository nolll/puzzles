using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201724Tests : PuzzleTest<Aoc201724>
{
    private const string Input = """
                                 0/2
                                 2/2
                                 2/3
                                 3/4
                                 3/5
                                 0/1
                                 10/1
                                 9/10
                                 """;
    
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(31);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(19);
}