namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202315;

public class Aoc202315Tests
{
    [Fact]
    public void HashScore() => Aoc202315.HashScore("HASH").Should().Be(52);

    [Fact]
    public void Part1() => Sut.Part1("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7").Should().Be(1320);

    [Fact]
    public void Part2() => Sut.Part2("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7").Should().Be(145);

    private static Aoc202315 Sut => new();
}