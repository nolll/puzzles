using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201805Tests : PuzzleTest<Aoc201805>
{
    [Fact]
    public void FullPolymer() => Sut.RunPart1("dabAcCaCBAcCcaDA").Should().Be("dabCBAcaDA");

    [Fact]
    public void ImprovedPolymer() => Sut.RunPart2("dabAcCaCBAcCcaDA").Should().Be("daDA");
}