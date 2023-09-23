namespace Common.Combinatorics;

public static class PermutationGenerator
{
    public static IList<IEnumerable<int>> GetPermutations(IList<int> numbers)
    {
        return GetPermutations(numbers, numbers.Count).ToList();
    }

    public static IList<IEnumerable<string>> GetPermutations(IList<string> strings)
    {
        return GetPermutations(strings, strings.Count).ToList();
    }

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IList<T> list, int length)
    {
        if (length == 1) return list.Select(t => new[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new[] { t2 }));
    }
}