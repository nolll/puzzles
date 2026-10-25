using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202403Tests : PuzzleTest<Aoc202403>
{
    [Fact]
    public void Part1() => Sut.Part1("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))").Should().Be(161);

    [Fact]
    public void Part2() => Sut.Part2("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))").Should().Be(48);
}