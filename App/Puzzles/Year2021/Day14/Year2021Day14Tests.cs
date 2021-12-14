using System.Collections.Generic;
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
            var result = polymerization.Run(Input, 10);

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

    public class Polymerization
    {
        public long Run2(string input, int stepCount)
        {
            var groups = PuzzleInputReader.ReadLineGroups(input);

            var rules = new Dictionary<(char, char), PolymerRule>();
            foreach (var strRule in groups[1])
            {
                var parts = strRule.Split(" -> ");
                var arr = parts[0].ToCharArray();
                rules.Add((arr[0], arr[1]), new PolymerRule(arr[0], arr[1], parts[1].ToCharArray().First()));
            }

            var chars = groups[0].First().ToCharArray();
            for (var i = 1; i < chars.Length; i++)
            {
                var a = chars[i - 1];
                var b = chars[i];
                var combination = new RecursivePolymerCombination(a, b, 0, stepCount);
            }

            return 0;
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
        private Dictionary<char, int> _dictionary;

        public RecursivePolymerCombination(char a, char b)
        {
            _a = a;
            _b = b;
        }

        public Dictionary<char, int> GetCounts()
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<char, int>();
            }

            return _dictionary;
        }

        private void Increment(char c)
        {
            if (_dictionary.ContainsKey(c))
                _dictionary[c]++;

            _dictionary[c] = 1;
        }
    }

    public class PolymerRule
    {
        private readonly Dictionary<char, int> _dictionary;

        public PolymerRule(char a, char b, char c)
        {
            _dictionary = new Dictionary<char, int>();
            Increment(a);
            Increment(b);
            Increment(c);
        }

        public Dictionary<char, int> Counts => _dictionary;

        private void Increment(char c)
        {
            if (_dictionary.ContainsKey(c))
                _dictionary[c]++;

            _dictionary[c] = 1;
        }
    }
}