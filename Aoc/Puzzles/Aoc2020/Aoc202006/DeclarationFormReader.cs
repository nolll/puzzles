using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202006;

public class DeclarationFormReader
{
    private readonly IList<IList<string>> _groups;

    public DeclarationFormReader(string input)
    {
        _groups = StringReader.ReadLineGroups(input);
    }

    public int SumOfAtLeastOneYes
    {
        get
        {
            var lettersByGroup = _groups.Select(GetLettersWithAtLeastOneYes);
            var groupCounts = lettersByGroup.Select(o => o.Length);
            return groupCounts.Sum();
        }
    }

    public int SumOfAllYes
    {
        get
        {
            var lettersByGroup = _groups.Select(GetLettersWithAllYes);
            var groupCounts = lettersByGroup.Select(o => o.Length);
            return groupCounts.Sum();
        }
    }

    private static char[] GetLettersWithAtLeastOneYes(IList<string> group)
    {
        var allAnswers = string.Join("", group);
        return allAnswers.ToCharArray().Distinct().OrderBy(o => o).ToArray();
    }

    private static char[] GetLettersWithAllYes(IList<string> group)
    {
        var allAnswers = string.Join("", group);
        var peopleInGroup = group.Count;
        var distinctLetters = allAnswers.ToCharArray().Distinct().OrderBy(o => o);
        var allLetters = allAnswers.ToCharArray().ToList();
        var allYesAnswers = distinctLetters.Where(o => allLetters.Count(c => c == o) == peopleInGroup);
        return allYesAnswers.ToArray();
    }
}