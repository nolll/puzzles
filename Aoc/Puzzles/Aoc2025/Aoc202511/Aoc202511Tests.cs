namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202511;

public class Aoc202511Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             aaa: you hhh
                             you: bbb ccc
                             bbb: ddd eee
                             ccc: ddd eee fff
                             ddd: ggg
                             eee: out
                             fff: out
                             ggg: out
                             hhh: ccc fff iii
                             iii: out
                             """;

        Sut.Part1(input).Answer.Should().Be("5");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             svr: aaa bbb
                             aaa: fft
                             fft: ccc
                             bbb: tty
                             tty: ccc
                             ccc: ddd eee
                             ddd: hub
                             hub: fff
                             eee: dac
                             dac: fff
                             fff: ggg hhh
                             ggg: out
                             hhh: out
                             """;

        Sut.Part2(input).Answer.Should().Be("2");
    }

    private static Aoc202511 Sut => new();
}