namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202221;

public class Aoc202221Tests
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(152);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(301);

    private static Aoc202221 Sut => new();

    private const string Input = """
                                 root: pppw + sjmn
                                 dbpl: 5
                                 cczh: sllz + lgvd
                                 zczc: 2
                                 ptdq: humn - dvpt
                                 dvpt: 3
                                 lfqf: 4
                                 humn: 5
                                 ljgn: 2
                                 sjmn: drzm * dbpl
                                 sllz: 4
                                 pppw: cczh / lfqf
                                 lgvd: ljgn * ptdq
                                 drzm: hmdt - zczc
                                 hmdt: 32
                                 """;
}