using System.Text;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202110;

public class SyntaxChecker
{
    private readonly Dictionary<char, SyntaxTag> _byOpeningTag;
    private readonly Dictionary<char, SyntaxTag> _byClosingTag;

    public SyntaxChecker()
    {
        var tags = new List<SyntaxTag>
        {
            new('(', ')', 1, 3),
            new('[', ']', 2, 57),
            new('{', '}', 3, 1197),
            new('<', '>', 4, 25137)
        };

        _byOpeningTag = tags.ToDictionary(k => k.OpeningTag, v => v);
        _byClosingTag = tags.ToDictionary(k => k.ClosingTag, v => v);
    }

    public int GetTotalErrorScore(string input) => input.Split(LineBreaks.Single).Sum(GetErrorScore);

    public long FindMiddleScore(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var completionStrings = new List<string>();
            
        foreach (var line in lines)
        {
            var s = GetErrorScore(line);
            if(s == 0)
                completionStrings.Add(GetCompletionString(line));
        }

        var scores = completionStrings.Select(GetCompletionsScore).ToList();

        var middleIndex = (scores.Count - 1) / 2;
        return scores.OrderBy(o => o).ToArray()[middleIndex];
    }

    private long GetCompletionsScore(string completionString)
    {
        return completionString.Aggregate<char, long>(0, (current, c) => current * 5 + GetCompletionScore(c));
    }

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

        var sb = new StringBuilder();
        while (expectedClosing.Any())
        {
            sb.Append(expectedClosing.Pop());
        }
            
        return sb.ToString();
    }

    private bool IsOpeningChar(char c)
    {
        const string openingChars = "([{<";
        return openingChars.Contains(c);
    }

    public int GetErrorScore(string code)
    {
        var expectedClosing = new Stack<char>();
        foreach (var c in code)
        {
            if (IsOpeningChar(c))
            {
                expectedClosing.Push(GetClosingTag(c));
            }
            else
            {
                var expected = expectedClosing.Pop();
                if (c != expected)
                    return GetErrorScore(c);
            }
        }

        return 0;
    }

    private int GetCompletionScore(char closingTag) => _byClosingTag[closingTag].CompletionScore;
    private char GetClosingTag(char openingTag) => _byOpeningTag[openingTag].ClosingTag;
    private int GetErrorScore(char closingTag) => _byClosingTag[closingTag].ErrorScore;

    private record SyntaxTag(char OpeningTag, char ClosingTag, int CompletionScore, int ErrorScore);
}