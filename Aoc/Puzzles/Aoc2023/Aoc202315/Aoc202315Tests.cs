namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202315;

public class Aoc202315Tests
{
    [Fact]
    public void HashScore()
    {
        var result = Aoc202315.HashScore("HASH");

        result.Should().Be(52);
    }
    
    [Fact]
    public void Part1()
    {
        var result = new Aoc202315().RunPart1("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");

        result.Answer.Should().Be("1320");
    }

    [Fact]
    public void Part2()
    {
        var result = new Aoc202315().RunPart2("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");

        result.Answer.Should().Be("145");
    }
}