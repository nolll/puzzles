using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Combinatorics;

public static class CombinationGenerator
{
    public static List<List<T>> GetAllCombinations<T>(IList<T> list)
    {
        var result = new List<List<T>> { new List<T>() };
        result.Last().Add(list[0]);
        if (list.Count == 1)
            return result;
        var tailCombos = GetAllCombinations(list.Skip(1).ToList());
        tailCombos.ForEach(combo =>
        {
            result.Add(new List<T>(combo));
            combo.Add(list[0]);
            result.Add(new List<T>(combo));
        });
        return result;
    }

    public static IEnumerable<List<T>> GetAllCombinations<T>(IList<T> list, int size)
    {
        var n = list.Count;
        var result = new int[size];
        var stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();

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
}