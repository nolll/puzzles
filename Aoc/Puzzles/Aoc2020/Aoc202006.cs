using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Custom Customs")]
public class Aoc202006 : AocPuzzle
{
    [Puzzle("15504e0b1c6cbf2a51c9cae0ce1a7ec1")]
    public int Part1(string input) => new DeclarationFormReader(input).SumOfAtLeastOneYes;

    [Puzzle("68cdb9b46ee8ea4505031a144aef81d2")]
    public int Part2(string input) => new DeclarationFormReader(input).SumOfAllYes;
    
    public class DeclarationFormReader(string input)
    {
        private readonly List<List<string>> _groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();

        public int SumOfAtLeastOneYes => _groups.Select(GetLettersWithAtLeastOneYes).Select(o => o.Length).Sum();
        public int SumOfAllYes => _groups.Select(GetLettersWithAllYes).Select(o => o.Length).Sum();

        private static char[] GetLettersWithAtLeastOneYes(IList<string> group) => 
            string.Join("", group).ToCharArray().Distinct().OrderBy(o => o).ToArray();

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
}