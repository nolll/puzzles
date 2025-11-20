using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202513;

[Name("")]
public class Ece202513 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var inputNumbers = input.Split(LineBreaks.Single).Select(int.Parse).ToList();
        List<int> numbers = [1];
        var startPos = 0;
        for (var i = 0; i < inputNumbers.Count; i++)
        {
            if(i % 2 == 0)
            {
                numbers.Add(inputNumbers[i]);
            }
            else
            {
                numbers.Insert(0, inputNumbers[i]);
                startPos++;
            }
        }
        
        var result = (startPos + 2025) % numbers.Count;
        
        return new PuzzleResult(numbers[result], "18ccf03875ad98259b4de347203fb45a");
    }

    public PuzzleResult Part2(string input) => new(Part2And3(input, 20252025), "120dc70bb2265cf1dd44b351a776f4eb");
    public PuzzleResult Part3(string input) => new(Part2And3(input, 202520252025), "ad5947829c2a32c895e2406a54daa389");

    private int Part2And3(string input, long steps)
    {
        var inputRanges = input.Split(LineBreaks.Single);
        List<Interval> intervals = [new(1, 1)];
        var startPos = 0;
        for (var i = 0; i < inputRanges.Length; i++)
        {
            var (lower, upper) = inputRanges[i].Split('-').Select(int.Parse).ToArray();
            if(i % 2 == 0)
            {
                intervals.Add(new Interval(lower, upper));
            }
            else
            {
                var interval = new Interval(upper, lower);
                intervals.Insert(0, interval);
                startPos += interval.Length;
            }
        }
        
        var target = (int)((startPos + steps) % intervals.Sum(o => o.Length));
        var pos = 0;
        var index = 0;
        
        while (true)
        {
            if (pos + intervals[index].Length > target)
                return intervals[index].GetNumberAt(target - pos);
            
            pos += intervals[index].Length;
            index++;
        }
    }

    private class Interval(int start, int end)
    {
        public int Length => Math.Abs(end - start) + 1;
        public int GetNumberAt(int pos) => start < end ? start + pos : start - pos;
    }
}