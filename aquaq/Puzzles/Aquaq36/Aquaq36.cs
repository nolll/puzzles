using System.Diagnostics;
using Puzzles.common.Combinatorics;
using Puzzles.common.Maths;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq36;

public class Aquaq36 : AquaqPuzzle
{
    public override string Name => "Tetonor Terror";

    protected override PuzzleResult Run()
    {
        var grid = "55 285 27 323 22 400 20 49 40 336 50 98 36 12 96 294";
        var gridNumbers = grid.Split(' ').Select(o => new GridNumber(int.Parse(o))).ToList();
        var allFactors = gridNumbers.SelectMany(o => o.Factors).Distinct().Order().ToList();
        return PuzzleResult.Empty;
    }

    public static int Solve(int[] gridNumbers, int[] inputNumbers)
    {
        var indexCombinations = CombinationGenerator.GetUniqueCombinationsFixedSize(Enumerable.Range(0, 16).ToList(), 2);
        //var inputCombinations = CombinationGenerator.GetCombinationsFixedSize(inputNumbers, 2);
        var candidates = indexCombinations.Select(o => new Candidate(o[0], o[1], inputNumbers[o[0]], inputNumbers[o[1]])).Distinct().ToList();
        var matchingCandidates = candidates
            .Where(o => gridNumbers.Contains(o.Sum) || gridNumbers.Contains(o.Product))
            .ToList();
        //var gridNumberCandidates =
        //    gridNumbers.Select(v => matchingCandidates.Where(o => o.IsMatching(v)).ToList()).ToList();

        var sortedInputNumbers = inputNumbers.OrderDescending().ToList();
        var largestSum = sortedInputNumbers[0] + sortedInputNumbers[1];
        var tooLargeToBeSum = gridNumbers.Where(o => o > largestSum);

        var gridDivisors = gridNumbers.Distinct()
            .Select((n, index) => (Number: n, Index: index))
            .ToDictionary(k => k.Index, v => FindDivisors(v.Number)
                .Where(inputNumbers.Contains)
                .ToArray());
        var sortedGridNumbers = gridNumbers.OrderDescending().ToList();

        var sum = 0;
        var pairs = new List<Candidate>();

        while (sortedGridNumbers.Any())
        {
            foreach (var gridNumber in sortedGridNumbers)
            {
                //var divisors = FindDivisors(gridNumber)
                //    .Where(inputNumbers.Contains)
                //    .ToArray();

                var productCandidates = candidates
                    .Where(o => o.Product == gridNumber || o.Sum == gridNumber)
                    .ToList();

                if (productCandidates.Count > 0)
                {
                    var candidate = productCandidates.First();
                    sortedGridNumbers.Remove(candidate.Product);
                    sortedGridNumbers.Remove(candidate.Sum);
                    sortedInputNumbers.Remove(candidate.A);
                    sortedInputNumbers.Remove(candidate.B);
                    pairs.Add(candidate);
                    sum += candidate.Diff;
                    candidates.Remove(candidate);
                    break;
                }
            }
        }

        var usedGridNumbers = new HashSet<int>();
        var usedInputNumbers = new HashSet<int>();

        return sum;
    }

    private static int[] FindDivisors(int n)
    {
        var divisors = new List<int>();
        for (var i = 1; i <= n; i++)
        {
            if(n % i == 0)
                divisors.Add(i);
        }
        return divisors.ToArray();
    }

    [DebuggerDisplay("{A},{B} -- Sum: {Sum} Product: {Product}")]
    private class Candidate : IEquatable<Candidate>
    {
        public int IndexA { get; }
        public int IndexB { get; }
        public int A { get; }
        public int B { get; }
        public int Sum { get; }
        public int Product { get; }
        public int Diff { get; }

        public Candidate(int indexA, int indexB, int a, int b)
        {
            IndexA = indexA;
            IndexB = indexB;
            A = Math.Min(a, b);
            B = Math.Max(b, a);
            Sum = a + b;
            Product = a * b;
            Diff = B - A;
        }

        public bool IsMatching(int gridNumber)
        {
            return gridNumber == Sum || gridNumber == Product;
        }

        public bool Equals(Candidate? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return A == other.A && B == other.B;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Candidate)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }
    }

    [DebuggerDisplay("{Number}: {FactorString}")]
    private class GridNumber
    {
        public List<int> Factors { get; }
        public string FactorString { get; }
        public int Number { get; }

        public GridNumber(int number)
        {
            Number = number;
            Factors = MathTools.GetFactors(number);
            FactorString = string.Join(", ", Factors);
        }
    }

    public static int[] GetAllFactors(IEnumerable<int> gridNumbers)
    {
        var list = new List<int>();
        foreach (var n in gridNumbers)
        {
            var factors = MathTools.GetFactors(n).ToArray();
            list.AddRange(factors);
        }

        return list.Order().ToArray();
    }
}