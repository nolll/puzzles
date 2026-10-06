using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201716Tests : PuzzleTest<Aoc201716>
{
    private const string Input = "s1,x3/4,pe/b";
    private const string Programs = "abcde";

    [Fact]
    public void CorrectOrderAfterOneDance() => Sut.Dance(Input, 1, Programs).Should().Be("baedc");

    [Fact]
    public void CorrectOrderAfterOneBillionDances() => Sut.Dance(Input, 1_000_000_000, Programs).Should().Be("abcde");
}