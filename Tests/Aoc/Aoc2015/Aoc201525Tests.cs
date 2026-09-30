using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201525Tests : PuzzleTest<Aoc201525>
{
    [Fact]
    public void FindsCode3_3() => Sut.FindCodeAt(3, 3).Should().Be(1601130);

    [Fact]
    public void FindsCode6_4() => Sut.FindCodeAt(6, 4).Should().Be(31527494);
}