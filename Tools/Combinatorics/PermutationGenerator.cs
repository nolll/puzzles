namespace Pzl.Tools.Combinatorics;

public static class PermutationGenerator
{
    public static IList<IEnumerable<T>> GetPermutations<T>(IList<T> list) =>
        GetPermutations(list, list.Count).ToList();
    
    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IList<T> list, int length)
    {
        if (length == 1) return list.Select(t => new[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat([t2]));
    }
}