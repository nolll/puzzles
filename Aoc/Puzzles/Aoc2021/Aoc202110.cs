using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Syntax Scoring")]
public class Aoc202110 : AocPuzzle
{
    private readonly string _openingChars;
    private readonly Dictionary<char, SyntaxTag> _byOpeningTag;
    private readonly Dictionary<char, SyntaxTag> _byClosingTag;

    private readonly List<SyntaxTag> _tags =
    [
        new('(', ')', 1, 3),
        new('[', ']', 2, 57),
        new('{', '}', 3, 1197),
        new('<', '>', 4, 25137)
    ];

    public Aoc202110()
    {
        _byClosingTag = _tags.ToDictionary(k => k.ClosingTag, v => v);
        _byOpeningTag = _tags.ToDictionary(k => k.OpeningTag, v => v);
        _openingChars = string.Concat(_byOpeningTag.Keys);
    }

    [Puzzle("e9bf166092809cfd161479766d825cb5")]
    public int Part1(string input) => input.Split(LineBreaks.Single).Sum(GetErrorScore);

    [Puzzle("064772af126a16832237033503572a30")]
    public long Part2(string input)
    {
        var scores = input.Split(LineBreaks.Single).Where(o => GetErrorScore(o) == 0)
            .Select(GetCompletionString)
            .Select(GetCompletionsScore).ToList();
        var middleIndex = (scores.Count - 1) / 2;
        return scores.OrderBy(o => o).ToArray()[middleIndex];
    }

    private long GetCompletionsScore(string completionString) =>
        completionString.Aggregate<char, long>(0, (current, c) => current * 5 + GetCompletionScore(c));

    public string GetCompletionString(string code)
    {
        var expectedClosing = new Stack<char>();
        foreach (var c in code)
        {
            if (IsOpeningChar(c))
                expectedClosing.Push(GetClosingTag(c));
            else
                expectedClosing.Pop();
        }

        return string.Concat(expectedClosing);
    }

    private bool IsOpeningChar(char c) => _openingChars.Contains(c);

    public int GetErrorScore(string code)
    {
        var expectedClosing = new Stack<char>();
        foreach (var c in code)
        {
            if (IsOpeningChar(c))
                expectedClosing.Push(GetClosingTag(c));
            else if (c != expectedClosing.Pop())
                return GetErrorScore(c);
        }

        return 0;
    }

    private int GetCompletionScore(char closingTag) => _byClosingTag[closingTag].CompletionScore;
    private char GetClosingTag(char openingTag) => _byOpeningTag[openingTag].ClosingTag;
    private int GetErrorScore(char closingTag) => _byClosingTag[closingTag].ErrorScore;

    private record SyntaxTag(char OpeningTag, char ClosingTag, int CompletionScore, int ErrorScore);
}