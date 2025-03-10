using System.Collections;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202215;

public static class IntervalMerger
{
    public static List<Interval> MergeIntervals(List<Interval> intervals)
    {
        if (intervals.Count <= 0)
            return new List<Interval>();

        var arr = intervals.OrderBy(o => o.Start).ThenBy(o => o.End).ToArray();
        var stack = new Stack<Interval>();
        stack.Push(arr[0]);

        for (var i = 1; i < arr.Length; i++)
        {
            var top = stack.Peek();

            if (top.End < arr[i].Start)
                stack.Push(arr[i]);

            else if (top.End < arr[i].End)
            {
                top.End = arr[i].End;
                stack.Pop();
                stack.Push(top);
            }
        }

        var mergedIntervals = new List<Interval>();
        while (stack.Count != 0)
        {
            mergedIntervals.Add(stack.Pop());
        }

        return mergedIntervals.OrderBy(o => o.Start).ThenBy(o => o.End).ToList();
    }

    private class IntervalSorter : IComparer
    {
        int IComparer.Compare(object? a, object? b)
        {
            var first = a as Interval ?? new Interval(0, 0);
            var second = b as Interval ?? new Interval(0, 0);

            return first.Start == second.Start
                ? first.End - second.End
                : first.Start - second.Start;
        }
    }
}