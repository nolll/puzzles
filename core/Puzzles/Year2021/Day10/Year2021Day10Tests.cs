using NUnit.Framework;

namespace App.Puzzles.Year2021.Day10;

public class Year2021Day10Tests
{
    [Test]
    public void Part1()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetTotalErrorScore(Input);

        Assert.That(result, Is.EqualTo(26397));
    }

    [Test]
    public void ValidateSingle()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>");

        Assert.That(result, Is.EqualTo(1197));
    }

    [Test]
    public void Part2()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.FindMiddleScore(Input);

        Assert.That(result, Is.EqualTo(288957));
    }

    [Test]
    public void CompletionString()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetCompletionString("[({(<(())[]>[[{[]{<()<>>");

        Assert.That(result, Is.EqualTo("}}]])})]"));
    }

    [Test]
    public void CompletionScore()
    {
        var syntaxChecker = new SyntaxChecker();
        var result = syntaxChecker.GetErrorScore("{([(<{}[<>[]}>{[]{[(<()>");

        Assert.That(result, Is.EqualTo(1197));
    }

    private const string Input = @"
[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
}