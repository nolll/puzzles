using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using App.Common.Strings;
using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day14
{
    public class Year2021Day14Tests
    {
        [Test]
        public void Part1()
        {
            var polymerization = new Polymerization();
            var result = polymerization.Run2(Input, 1);

            Assert.That(result, Is.EqualTo(1588));
        }

        [Test]
        public void Part2()
        {
            var polymerization = new Polymerization();
            var result = polymerization.Run(Input, 40);

            Assert.That(result, Is.EqualTo(2188189693529));
        }

        private const string Input = @"
NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
    }

    public static class CountMerger
    {
        public static Dictionary<char, long> MergeCounts(params Dictionary<char, long>[] dictionaries)
        {
            var merged = new Dictionary<char, long>();
            foreach (var dictionary in dictionaries)
            {
                foreach (var key in dictionary.Keys)
                {
                    if (!merged.ContainsKey(key))
                        merged[key] = 0;

                    merged[key] += dictionary[key];
                }
            }

            return merged;
        }
    }

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
            var countList = new List<Dictionary<char, long>>();
            for (var i = 1; i < chars.Length; i++)
            {
                var a = chars[i - 1];
                var b = chars[i];
                var combination = new RecursivePolymerCombination(rules, a, b, 0, stepCount);
                countList.Add(combination.CountsChars(cache));
            }

            var counts = CountMerger.MergeCounts(countList.ToArray());

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

    public class RecursivePolymerCombination
    {
        private readonly char _a;
        private readonly char _b;
        private readonly int _level;
        private readonly int _maxLevel;
        private readonly Dictionary<(char, char), char> _rules;

        public RecursivePolymerCombination(Dictionary<(char, char), char> rules, char a, char b, int level, int maxLevel)
        {
            _rules = rules;
            _a = a;
            _b = b;
            _level = level;
            _maxLevel = maxLevel;
        }

        public Dictionary<char, long> CountsChars(Dictionary<(char, char, int), Dictionary<char, long>> cache)
        {
            var cacheKey = (_a, _b, _level);
            if (cache.ContainsKey(cacheKey))
                return cache[cacheKey];

            if (_level == _maxLevel)
            {
                var counts = new Dictionary<char, long>();
                //Increment(counts, _a);
                var insert = _rules[(_a, _b)];
                Increment(counts, insert);
                cache.Add(cacheKey, counts);
                return counts;
            }
            else
            {
                var insert = _rules[(_a, _b)];
                var left = new RecursivePolymerCombination(_rules, _a, insert, _level + 1, _maxLevel);
                var right = new RecursivePolymerCombination(_rules, insert, _b, _level + 1, _maxLevel);
                var leftCounts = left.CountsChars(cache);
                var rightCounts = right.CountsChars(cache);
                var counts = CountMerger.MergeCounts(leftCounts, rightCounts);
                cache.Add(cacheKey, counts);
                return counts;
            }
        }

        private void Increment(Dictionary<char, long> counts, char c)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }
    }
}