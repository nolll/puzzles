using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202110Tests : PuzzleTest<Aoc202110>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(26397);

    [Fact]
    public void ValidateSingle() => Sut.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>").Should().Be(1197);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(288957);

    [Fact]
    public void CompletionString() => Sut.GetCompletionString("[({(<(())[]>[[{[]{<()<>>").Should().Be("}}]])})]");

    [Fact]
    public void CompletionScore() => Sut.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>").Should().Be(1197);

    private const string Input = """
                                 [({(<(())[]>[[{[]{<()<>>
                                 [(()[<>])]({[<{<<[]>>(
                                 {([(<{}[<>[]}>{[]{[(<()>
                                 (((({<>}<{<{<>}{[]{[]{}
                                 [[<[([]))<([[{}[[()]]]
                                 [{[{({}]{}}([{[{{{}}([]
                                 {<[[]]>}<{[{[{[]{()[[[]
                                 [<(<(<(<{}))><([]([]()
                                 <{([([[(<>()){}]>(<<{{
                                 <{([{{}}[<[[[<>{}]]]>[]]
                                 """;
}