namespace Pzl.Tools.Combinatorics;

public static class CombinationGenerator
{
    public static List<List<T>> GetUniqueCombinationsAnySize<T>(IList<T> list)
    {
        var result = new List<List<T>> { new() };
        result.Last().Add(list[0]);
        if (list.Count == 1)
            return result;
        var tailCombos = GetUniqueCombinationsAnySize(list.Skip(1).ToList());
        tailCombos.ForEach(combo =>
        {
            result.Add([..combo]);
            combo.Add(list[0]);
            result.Add([..combo]);
        });
        return result;
    }

    public static IEnumerable<List<T>> GetUniqueCombinationsFixedSize<T>(IList<T> list, int size)
    {
        var n = list.Count;
        var result = new int[size];
        var stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            var index = stack.Count - 1;
            var value = stack.Pop();

            while (value < n)
            {
                result[index++] = value++;
                stack.Push(value);

                if (index == size)
                {
                    yield return result.Select(o => list[o]).ToList();
                    break;
                }
            }
        }
    }

    public static IEnumerable<List<T>> GetUniqueCombinationsMaxSize<T>(IList<T> list, int size)
    {
        var result = new List<List<T>> { new() };
        result.Last().Add(list[0]);
        if (list.Count == 1)
            return result;
        var tailCombos = GetUniqueCombinationsAnySize(list.Skip(1).ToList());
        tailCombos.ForEach(combo =>
        {
            result.Add([..combo]);
            combo.Add(list[0]);
            result.Add([..combo]);
        });
        return result.Where(o => o.Count <= size);
    }

    public static IEnumerable<IList<T>> GetCombinationsFixedSize<T>(IList<T> list, int size) => 
        GetCombinationsFixedSizeRecursive(new List<T>(), list, size, 0);

    private static IEnumerable<IList<T>> GetCombinationsFixedSizeRecursive<T>(IList<T> accList, IList<T> list, int size, int i)
    {
        var e = new List<IList<T>>();

        if(i == size)
        {
            e.Add(accList);
            return e;
        }

        foreach (var item in list)
        {
            e.AddRange(
                GetCombinationsFixedSizeRecursive<T>(
                    accList.Concat(new List<T> { item }).ToList(), list, size, i + 1));
        }

        return e;
    }
    
    // Found here: https://stackoverflow.com/questions/3093622/generating-all-possible-combinations/3098381
    public static  IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        IEnumerable<IEnumerable<T>> emptyProduct = [[]];
        return sequences.Aggregate(
            emptyProduct,
            (accumulator, sequence) =>
                from accseq in accumulator 
                from item in sequence
                select accseq.Concat([item])              
        );
    }
}