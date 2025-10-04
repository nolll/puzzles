namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202110;

public class Aoc202110Tests
{
    [Fact]
    public void Part1()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetTotalErrorScore(Input);

        result.Should().Be(26397);
    }

    [Fact]
    public void ValidateSingle()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>");

        result.Should().Be(1197);
    }

    [Fact]
    public void Part2()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.FindMiddleScore(Input.Trim());

        result.Should().Be(288957);
    }

    [Fact]
    public void CompletionString()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetCompletionString("[({(<(())[]>[[{[]{<()<>>");

        result.Should().Be("}}]])})]");
    }

    [Fact]
    public void CompletionScore()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>");

        result.Should().Be(1197);
    }

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