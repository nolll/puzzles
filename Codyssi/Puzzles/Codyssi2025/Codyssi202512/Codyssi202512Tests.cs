namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202512;

public class Codyssi202512Tests
{
    private const string Input = """
                                 222 267 922 632 944
                                 110 33 503 758 129
                                 742 697 425 362 568
                                 833 408 425 349 631
                                 874 671 202 430 602
                                 
                                 SHIFT COL 2 BY 1
                                 MULTIPLY 4 COL 5
                                 SUB 28 ALL
                                 SHIFT COL 4 BY 2
                                 MULTIPLY 4 ROW 4
                                 ADD 26 ROW 3
                                 SHIFT COL 4 BY 2
                                 ADD 68 ROW 2
                                 
                                 TAKE
                                 CYCLE
                                 TAKE
                                 ACT
                                 TAKE
                                 CYCLE
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("18938");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("11496");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("19022");

    private static Codyssi202512 Sut => new();
}