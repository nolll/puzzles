using System;
using System.Linq;

namespace Core.Puzzles.Year2022.Day17;

public static class CycleFinder
{
    public static RepeatCycle FindRepeatCycle(int[] numbers, int minLength = 0, int startSearchAt = 0)
    {
        var searchList = numbers.Skip(startSearchAt).ToArray();
        var repeatList = FindRepeatSequence(searchList, minLength);
        var repeatStart = FindCycleStart(numbers, repeatList);
        return repeatList.Length > 0
            ? new RepeatCycle(repeatStart, repeatList.Length) 
            : new RepeatCycle(0, 0);
    }

    private static int FindCycleStart(int[] numbers, int[] repeatList)
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            var length = repeatList.Length;
            var compareList = numbers.Skip(i).Take(length);
            if (repeatList.SequenceEqual(compareList))
                return i;
        }

        return 0;
    }

    private static int[] FindRepeatSequence(int[] numbers, int minLength = 0)
    {
        var repeatList = Array.Empty<int>();

        for (var length = minLength; length < numbers.Length; length++)
        {
            var list1 = numbers.Take(length);
            var list2 = numbers.Skip(length).Take(length);
            if (list1.SequenceEqual(list2))
            {
                repeatList = list1.ToArray();
                break;
            }
        }

        return repeatList;
    }
}