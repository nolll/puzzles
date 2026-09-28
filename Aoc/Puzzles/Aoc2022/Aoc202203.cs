using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Rucksack Reorganization")]
public class Aoc202203 : AocPuzzle
{
    [Puzzle("734ddef10b36997c859308e094bc4baf")]
    public int Part1(string input) => Rucksacks.GetPriority1(input);

    [Puzzle("9fd65a1dd39fabc5782fd0b774cda196")]
    public int Part2(string input) => Rucksacks.GetPriority2(input);
    
    public static class Rucksacks
    {
        public static int GetPriority1(string input) => GetPrioritySumForLines(Parse(input));
        public static int GetPriority2(string input) => GetPrioritySumForGroups(Parse(input));
        private static List<string> Parse(string input) => input.Split(LineBreaks.Single).Where(o => o.Length > 0).ToList();

        private static int GetPrioritySumForLines(IList<string> lines) => 
            lines.Select(SplitInTwo).Sum(parts => GetPriorityForLine(parts[0], parts[1]));

        private static int GetPriorityForLine(string s1, string s2)
        {
            var a1 = s1.ToCharArray();
            var a2 = s2.ToCharArray();
            foreach (var c in a1)
            {
                if (a2.Contains(c))
                    return GetPriority(c);
            }

            return 0;
        }

        private static int GetPrioritySumForGroups(IList<string> lines)
        {
            var totalSum = 0;
        
            for (var i = 0; i < lines.Count; i += 3)
            {
                totalSum += GetPriorityForGroup(lines[i], lines[i + 1], lines[i + 2]);
            }

            return totalSum;
        }

        private static int GetPriorityForGroup(string s1, string s2, string s3)
        {
            var a1 = s1.ToCharArray();
            var a2 = s2.ToCharArray();
            var a3 = s3.ToCharArray();

            foreach (var c in a1)
            {
                if (a2.Contains(c) && a3.Contains(c))
                {
                    return GetPriority(c);
                }
            }

            return 0;
        }

        private static int GetPriority(char c) => char.IsUpper(c)
            ? c - 38
            : c - 96;

        private static string[] SplitInTwo(string s) =>
        [
            s[..(s.Length / 2)],
            s[(s.Length / 2)..]
        ];
    }
}