using Common.Combinatorics;
using Common.Puzzles;
using System.Diagnostics;

namespace Aquaq.Puzzles.Aquaq36;

public class Aquaq36 : AquaqPuzzle
{
    public override string Name => "Tetonor Terror";

    protected override PuzzleResult Run()
    {
        throw new NotImplementedException();
    }

    public static int Solve(int[] gridNumbers, int[] inputNumbers)
    {
        var inputCombinations = CombinationGenerator.GetCombinationsFixedSize(inputNumbers, 2);
        var candidates = inputCombinations.Select(o => new Candidate(o[0], o[1]));
        var matchingCandidates = candidates
            .Where(o => gridNumbers.Contains(o.Sum) || gridNumbers.Contains(o.Product))
            .ToList();
        var gridNumberCandidates =
            gridNumbers.Select(v => matchingCandidates.Where(o => o.IsMatching(v)).ToList()).ToList();
        return 0;
    }

    [DebuggerDisplay("{A},{B},{Sum},{Product}")]
    private class Candidate : IEquatable<Candidate>
    {
        public int A { get; }
        public int B { get; }
        public int Sum { get; }
        public int Product { get; }

        public Candidate(int a, int b)
        {
            A = Math.Min(a, b);
            B = Math.Max(b, a);
            Sum = a + b;
            Product = a * b;
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
}