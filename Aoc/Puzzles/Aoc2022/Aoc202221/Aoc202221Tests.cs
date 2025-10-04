namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202221;

public class Aoc202221Tests
{
    [Fact]
    public void Part1()
    {
        var result = new Aoc202221().Part1(Input);

        result.Should().Be(152);
    }

    [Fact]
    public void Part2()
    {
        var result = new Aoc202221().Part2(Input);

        result.Should().Be(301);
    }

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