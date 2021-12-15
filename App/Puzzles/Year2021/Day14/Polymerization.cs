using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day14;

public class Polymerization
{
    public long Run2(string input, int stepCount)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);

        var rules = new Dictionary<(char, char), char>();
        foreach (var strRule in groups[1])
        {
            var parts = strRule.Split(" -> ");
            var arr = parts[0].ToCharArray();
            rules.Add((arr[0], arr[1]), parts[1].ToCharArray().First());
        }

        var cache = new Dictionary<(char, char, int), Dictionary<char, long>>();
        var chars = groups[0].First().ToCharArray();
        var lastChar = chars.Last();
        var countList = new List<Dictionary<char, long>>();
        for (var i = 1; i < chars.Length; i++)
        {
            var a = chars[i - 1];
            var b = chars[i];
            var combination = new RecursivePolymerCombination(rules, a, b, 0, stepCount);
            countList.Add(combination.CountsChars(cache));
        }

        var counts = CountMerger.MergeCounts(countList.ToArray());
        counts[lastChar]++;

        var min = counts.Values.Min();
        var max = counts.Values.Max();

        return max - min;
    }

    public long Run(string input, int stepCount)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var linkedList = new LinkedList<char>();
        foreach (var c in groups[0].First())
        {
            linkedList.AddLast(c);
        }
        var strRules = groups[1];
        var rules = new Dictionary<(char, char), char>();

        foreach (var strRule in strRules)
        {
            var parts = strRule.Split(" -> ");
            var arr = parts[0].ToCharArray();
            var key = (arr[0], arr[1]);
            rules.Add(key, parts[1].ToCharArray().First());
        }

        var currentNode = linkedList.First;
        for (var i = 0; i < stepCount; i++)
        {
            while (currentNode!.Next != null)
            {
                var currentValue = currentNode!.Value;
                var nextNode = currentNode.Next;
                var nextValue = nextNode!.Value;
                var insert = rules[(currentValue, nextValue)];
                linkedList.AddBefore(nextNode, insert);
                currentNode = nextNode;
            }
            currentNode = linkedList.First;
        }

        currentNode = linkedList.First!;
        var counts = new Dictionary<char, int>();

        var str = new StringBuilder();
        while (currentNode != null)
        {
            var c = currentNode.Value;
            str.Append(c);
            currentNode = currentNode.Next;
            if (currentNode!.Next == null)
                break;
        }

        currentNode = linkedList.First!;
        while (currentNode != null)
        {
            var c = currentNode!.Value;
            if (!counts.ContainsKey(c))
                counts[c] = 1;

            counts[c]++;

            currentNode = currentNode.Next;
        }

        return counts.Values.Max(o => o) - counts.Values.Min(o => o);
    }
}