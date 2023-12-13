using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202312;

[Name("Hot Springs")]
public class Aoc202312(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var lines = StringReader.ReadLines(input);
        var counts = lines.Select(o => CombinationCount(o));

        return new PuzzleResult(counts.Sum(), "ec83138b082ab4da38bb60e88263c52f");
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);

        var lines = StringReader.ReadLines(input);
        var counts = lines.Select(o => CombinationCount(o, true));

        return new PuzzleResult(counts.Sum());
    }

    public static long CombinationCount(string s, bool isPart2 = false)
    {
        var parts = s.Split(' ');
        var layout = parts.First();
        var damagedGroups = parts.Last().Split(',').Select(int.Parse).ToList();

        if (isPart2)
        {
            var layouts2 = new List<string>();
            var damagedGroups2 = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                layouts2.Add(layout);
                damagedGroups2.AddRange(damagedGroups);
            }

            layout = string.Join('?', layouts2);
            damagedGroups = damagedGroups2;
        }

        var count = GetValidCount(layout.ToCharArray().ToList(), damagedGroups, 0);

        return count;
    }

    private static long GetValidCount(List<char> layout, List<int> damagedGroups, int pos)
    {
        if (damagedGroups.Count == 0)
            return layout.Skip(pos).Any(o => o == '#') ? 0 : 1;

        var minLength = damagedGroups.Sum() +  damagedGroups.Count - 1;
        var loopLength = layout.Count - pos - minLength;
        var validCount = 0L;
        var groupSize = damagedGroups.First();
        for (var i = 0; i <= loopLength; i++)
        {
            var canBeAtPos = CanGroupBeAtPos(layout, groupSize, pos + i);
            
            if (canBeAtPos)
            {
                validCount += GetValidCount(layout, damagedGroups.Skip(1).ToList(), pos + i + groupSize + 1);
            }
        }

        return validCount;
    }

    private static bool CanGroupBeAtPos(List<char> layout, int length, int pos)
    {
        if (pos > 0)
        {
            if (layout[pos - 1] == '#')
                return false;
        }

        for (var i = 0; i < length; i++)
        {
            if (layout[pos + i] == '.')
                return false;
        }

        if (pos + length < layout.Count - 1)
        {
            if (layout[pos + length] == '#')
                return false;
        }

        return true;
    }

    public static int CombinationCountOld(string s, bool isPart2 = false)
    {
        var parts = s.Split(' ');
        var layout = parts.First();
        var damagedGroups = parts.Last().Split(',').Select(int.Parse).ToList();

        if (isPart2)
        {
            var layouts2 = new List<string>();
            var damagedGroups2 = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                layouts2.Add(layout);
                damagedGroups2.AddRange(damagedGroups);
            }

            layout = string.Join('?', layouts2);
            damagedGroups = damagedGroups2;
        }

        var layoutlength = layout.Length;
        var damagedGroupCount = damagedGroups.Count();
        var totalGroupCount = damagedGroupCount * 2 - 1;
        var damagedCount = damagedGroups.Sum();
        var minOkGroupCount = damagedGroupCount - 1;
        var maxOkGroupCount = damagedGroupCount + 1;
        var okCount = layoutlength - damagedCount;
        var partitions = GetPartitions(okCount)
            .Select(o => o.ToList())
            .Where(o => o.Count >= minOkGroupCount && o.Count <= maxOkGroupCount)
            .ToList();

        var completePartitions = CompletePartitions(partitions, maxOkGroupCount);
        var strings = BuildStrings(completePartitions, damagedGroups);
        var validStrings = strings.Where(o => IsValid(o, layout)).ToList();

        var partitionCount = completePartitions.Count;

        Console.WriteLine($"___ {s} => {validStrings.Count}");

        return validStrings.Count;
    }

    private static bool IsValid(string s, string pattern)
    {
        var arr = s.ToCharArray();
        var patternArr = pattern.ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            var a = arr[i];
            var p = patternArr[i];
            if(a == p || p == '?')
                continue;

            if (a != p)
                return false;
        }

        return true;
    }

    private static List<string> BuildStrings(List<List<int>> partitions, List<int> damagedGroups)
    {
        return partitions.Select(o => BuildString(o, damagedGroups)).ToList();
    }

    public static string BuildString(List<int> okCounts, List<int> damagedCounts)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < okCounts.Count; i++)
        {
            if (i > 0)
            {
                sb.Append(GenerateString('#', damagedCounts[i - 1]));
            }
            sb.Append(GenerateString('.', okCounts[i]));
        }

        return sb.ToString();
    }

    private static string GenerateString(char c, int length)
    {
        return string.Join("", Enumerable.Range(0, length).Select(o => c));
    }

    private static List<List<int>> CompletePartitions(List<List<int>> partitions, int maxCount)
    {
        var completePartitions = new List<List<int>>();
        foreach (var partition in partitions)
        {
            if (partition.Count < maxCount)
            {
                if (partition.Count == maxCount - 1)
                {
                    var p1 = partition.ToList();
                    p1.Add(0);
                    var p2 = partition.ToList();
                    p2.Insert(0, 0);
                    completePartitions.Add(p1);
                    completePartitions.Add(p2);
                }

                if (partition.Count == maxCount - 2)
                {
                    var p = partition.ToList();
                    p.Add(0);
                    p.Insert(0, 0);
                    completePartitions.Add(p);
                }
            }
            else
            {
                completePartitions.Add(partition);
            }
        }
        return completePartitions;
    }

    internal class Combination
    {
        internal int Num;
        internal IEnumerable<Combination> Combinations;
    }

    internal static IEnumerable<Combination> GetCombinationTrees(int num, int max)
    {
        return Enumerable.Range(1, num)
            // removes duplicates
            //.Where(n => n <= max) 
            .Select(n =>
                new Combination
                {
                    Num = n,
                    Combinations = GetCombinationTrees(num - n, n)
                });
    }

    internal static IEnumerable<IEnumerable<int>> BuildCombinations(
        IEnumerable<Combination> combinations)
    {
        if (combinations.Count() == 0)
        {
            return new[] { new int[0] };
        }
        else
        {
            return combinations.SelectMany(c =>
                BuildCombinations(c.Combinations)
                    .Select(l => new[] { c.Num }.Concat(l))
            );
        }
    }

    public static IEnumerable<IEnumerable<int>> GetPartitions(int num)
    {
        var combinationsList = GetCombinationTrees(num, num);

        return BuildCombinations(combinationsList);
    }
}