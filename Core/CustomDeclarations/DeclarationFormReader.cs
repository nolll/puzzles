using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CustomDeclarations
{
    public class DeclarationFormReader
    {
        public int SumOfYesAnswers { get; }

        public DeclarationFormReader(string input)
        {
            var groups = PuzzleInputReader.ReadGroups(input);
            var lettersByGroup = groups.Select(GetGroupLetters);
            var groupCounts = lettersByGroup.Select(o => o.Length);
            SumOfYesAnswers = groupCounts.Sum();
        }

        private static char[] GetGroupLetters(IList<string> group)
        {
            var allAnswers = string.Join("", group);
            return allAnswers.ToCharArray().Distinct().OrderBy(o => o).ToArray();
        }
    }
}