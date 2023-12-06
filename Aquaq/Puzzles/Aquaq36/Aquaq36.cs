using Puzzles.Common.Maths;
using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aquaq.Puzzles.Aquaq36;

public class Aquaq36 : AquaqPuzzle
{
    public override string Name => "Tetonor Terror";
    public override bool IsSlow => true;
    public override bool NeedsRewrite => true;

    protected override PuzzleResult Run()
    {
        var factorProvider = new FactorCache();
        var tetonors = StringReader.ReadStringGroups(InputFile);
        var sum = 0;

        foreach (var tetonor in tetonors)
        {
            var rows = StringReader.ReadLines(tetonor);
            var grid = rows[0][2..].Split(' ').Select(int.Parse).ToList();
            var input = rows[1][2..].Split(' ').Select(o => (int?)(o == "*" ? null : int.Parse(o))).ToList();
            var result = Solve(grid, input, factorProvider);

            sum += result;
        }

        return new PuzzleResult(sum, "ed32dfd657e38da7c712ea1c69f58f6d");
    }

    public static int Solve(List<int> grid, List<int?> input, FactorCache? factorCache = null)
    {
        var concreteFactorCache = factorCache ?? new FactorCache();
        var sortedGrid = grid.OrderDescending().ToList();
        var factorSet = GetAllFactors(sortedGrid).Distinct().ToHashSet();
        var inputs = FindPossibleInputNumbers(input, sortedGrid.Max(), factorSet);

        var result = Solve(sortedGrid, inputs, concreteFactorCache, 0);
        if (result > 0)
            return result;

        return 0;
    }

    private static List<GridPair> GetGridPairs(int n, List<int> grid, FactorCache factorCache)
    {
        var list = new List<GridPair>();
        var gridNumbers = factorCache.Get(n);
        foreach (var gridNumber in gridNumbers)
        {
            var sum = gridNumber.A + gridNumber.B;
            if (grid.Contains(sum))
            {
                var a = Math.Min(gridNumber.A, gridNumber.B);
                var b = Math.Max(gridNumber.A, gridNumber.B);
                list.Add(new GridPair(n, sum, a, b));
            }
        }

        return list;
    }

    private static int Solve(List<int> grid, List<HashSet<int>> inputs, FactorCache factorCache, int sum)
    {
        if (!grid.Any())
            return sum;

        //var seen = new HashSet<GridPair>();
        foreach (var gridNumber in grid)
        {
            var pairs = GetGridPairs(gridNumber, grid, factorCache);
            foreach (var pair in pairs)
            {
                //seen.Add(pair);
                var aIndices = IndicesContaining(inputs, pair.A);
                var bIndices = IndicesContaining(inputs, pair.B);

                foreach (var a in aIndices)
                {
                    foreach (var b in bIndices)
                    {
                        if (a != b)
                        {
                            var newGrid = grid.ToList();
                            var newInput = inputs.ToList();
                            newGrid.Remove(pair.Product);
                            newGrid.Remove(pair.Sum);
                            newInput.RemoveAt(Math.Max(a, b));
                            newInput.RemoveAt(Math.Min(a, b));
                            var result = Solve(newGrid, newInput, factorCache, sum + Math.Abs(pair.B - pair.A));
                            if (result > 0)
                                return result;
                        }
                    }
                }
            }
        }
        
        return 0;
    }

    public static IEnumerable<int> IndicesContaining(List<HashSet<int>> inputs, int n)
    {
        for (var i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].Contains(n))
                yield return i;
        }
    }

    public class FactorCache
    {
        private readonly Dictionary<int, List<GridNumber>> _gridNumberCache = new();
        private readonly Dictionary<int, List<int>> _factorCache = new();

        public List<GridNumber> Get(int n)
        {
            if (_gridNumberCache.TryGetValue(n, out var gridNumbers))
                return gridNumbers;

            var factors = MathTools.GetMultiplicationFactors(n);
            gridNumbers = factors.Select(o => new GridNumber(n, o.a, o.b)).ToList();
            _gridNumberCache.Add(n, gridNumbers);
            return gridNumbers;
        }
    }

    public static List<int> GetAllFactors(IEnumerable<int> gridNumbers)
    {
        var list = new List<int>();
        foreach (var n in gridNumbers)
        {
            var factors = MathTools.GetFactors(n).ToArray();
            list.AddRange(factors);
        }

        return list.Order().ToList();
    }

    public static List<HashSet<int>> FindPossibleInputNumbers(List<int?> input, int max, HashSet<int>? factors = null)
    {
        var list = new List<HashSet<int>>();
        for (var i = 0; i < input.Count; i++)
        {
            var v = input[i];
            if (v is null)
            {
                var lowerBound = FindLowerBound(input, i);
                var upperBound = FindUpperBound(input, i, max);
                var rangeCount = upperBound - lowerBound + 1;
                var numbers = Enumerable.Range(lowerBound, rangeCount);
                if (factors != null)
                    numbers = numbers.Where(factors.Contains);
                list.Add(numbers.ToHashSet());
            }
            else
            {
                list.Add(new() { v.Value });
            }
        }

        return list;
    }

    private static int FindLowerBound(List<int?> input, int index)
    {
        for (var j = index - 1; j >= 0; j--)
        {
            var v = input[j];
            if (v is not null)
                return v.Value;
        }

        return 1;
    }

    private static int FindUpperBound(List<int?> input, int index, int max)
    {
        for (var j = index + 1; j < input.Count; j++)
        {
            var v = input[j];
            if (v is not null)
                return v.Value;
        }

        return max;
    }

    public record GridPair(int Product, int Sum, int A, int B);
    public record GridNumber(int Product, int A, int B);
}