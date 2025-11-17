using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202509;

[Name("Encoded in the Scales")]
public class Ece202509 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var totalScore = FindChildren(ParseDucks(input)).Sum(o => o.Score);

        return new PuzzleResult(totalScore, "02cb5b8f30a69972766eb4d6122b6667");
    }

    public PuzzleResult Part2(string input)
    {
        var totalScore = FindChildren(ParseDucks(input)).Sum(o => o.Score);
        
        return new PuzzleResult(totalScore, "f1dada234df0c5304571179c87ccfa7c");
    }

    public PuzzleResult Part3(string input)
    {
        var ducks = ParseDucks(input);
        var pairs = CombinationGenerator.GetUniqueCombinationsFixedSize(ducks.ToList(), 2).ToList();
        foreach (var duck in ducks)
        {
            foreach (var pair in pairs)
            {
                var p1 = pair[0];
                var p2 = pair[1];

                if (duck.Dna == p1.Dna || duck.Dna == p2.Dna)
                    continue;

                if (!duck.IsChildOf(p1, p2))
                    continue;
                
                duck.SetParents(p1, p2);
                p1.AddChild(duck);
                p2.AddChild(duck);
                break;
            }
        }
        
        var traversed = new HashSet<int>();
        var families = new List<HashSet<Duck>>();
        var remaining = ducks;
        while (traversed.Count < ducks.Length)
        {
            var family = new HashSet<Duck>();
            var queue = new Queue<Duck>();
            queue.Enqueue(remaining.First());

            while (queue.Count > 0)
            {
                var duck = queue.Dequeue();
                family.Add(duck);
                traversed.Add(duck.Id);
                var connections = duck.Parents.Concat(duck.Children).Where(o => !traversed.Contains(o.Id)).ToList();
                if(connections.Any())
                    queue.Enqueue(connections);
            }

            families.Add(family);
            remaining = remaining.Where(o => !traversed.Contains(o.Id)).ToArray();
        }

        var best = families.MaxBy(o => o.Count);
        var score = best?.Sum(o => o.Id) ?? 0;
        
        return new PuzzleResult(score, "1b1c63b79876197254b3c527798a8269");
    }
    
    private static Duck[] ParseDucks(string input) => 
        input.Split(LineBreaks.Single).Select(o => o.Split(':')).Select(o => new Duck(int.Parse(o.First()), o.Last())).ToArray();

    private static List<Duck> FindChildren(Duck[] ducks)
    {
        var items = new List<Duck>();
        foreach (var duck in ducks)
        {
            var possibleParents = ducks.Where(o => o.Dna != duck.Dna).ToList();
            var combinations = CombinationGenerator.GetUniqueCombinationsFixedSize(possibleParents, 2);
            foreach (var combination in combinations)
            {
                var p1 = combination.First();
                var p2 = combination.Last();
                if (duck.IsChildOf(p1, p2))
                {
                    duck.SetParents(p1, p2);
                    items.Add(duck);
                }
            }
        }

        return items;
    }

    public class Duck(int id, string dna)
    {
        public int Id { get; } = id;
        public string Dna { get; } = dna;

        public readonly List<Duck> Parents = new();
        public readonly List<Duck> Children = new();

        public void SetParents(Duck p1, Duck p2)
        {
            Parents.Add(p1);
            Parents.Add(p2);
        }
        
        public void AddChild(Duck child) => Children.Add(child);

        public bool IsChildOf(Duck parent1, Duck parent2) => 
            !Dna.Where((t, i) => t != parent1.Dna[i] && t != parent2.Dna[i]).Any();

        public int Score
        {
            get
            {
                if (!Parents.Any())
                    return 0;

                var p1 = Parents[0];
                var p2 = Parents[1];
                var p1Score = 0;
                var p2Score = 0;
                for (var i = 0; i < Dna.Length; i++)
                {
                    p1Score += Dna[i] == p1.Dna[i] ? 1 : 0;
                    p2Score += Dna[i] == p2.Dna[i] ? 1 : 0;
                }

                return p1Score * p2Score;
            }
        }
    }
}