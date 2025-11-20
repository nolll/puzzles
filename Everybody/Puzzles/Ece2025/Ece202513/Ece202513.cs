using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202513;

[Name("Unlocking the Mountain")]
public class Ece202513 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, 2025), "18ccf03875ad98259b4de347203fb45a");
    public PuzzleResult Part2(string input) => new(Solve(input, 20252025), "120dc70bb2265cf1dd44b351a776f4eb");
    public PuzzleResult Part3(string input) => new(Solve(input, 202520252025), "ad5947829c2a32c895e2406a54daa389");

    private static int Solve(string input, long steps)
    {
        var (intervals, startPos) = ParseDial(input);
        
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

    private static (List<Interval> intervals, int startPos) ParseDial(string input)
    {
        var inputRanges = input.Split(LineBreaks.Single).Select(ParseRange).ToArray();
        List<Interval> intervals = [new(1, 1)];
        var startPos = 0;
        var clockwise = true;
        foreach (var (lower, upper) in inputRanges)
        {
            if(clockwise)
            {
                intervals.Add(new Interval(lower, upper));
            }
            else
            {
                var interval = new Interval(upper, lower);
                intervals.Insert(0, interval);
                startPos += interval.Length;
            }

            clockwise = !clockwise;
        }

        return (intervals, startPos);
    }

    private static (int lower, int upper) ParseRange(string s)
    {
        var parts = s.Split('-').Select(int.Parse).ToArray();
        return parts.Length > 1 ? (parts[0], parts[1]) : (parts[0], parts[0]);
    }

    private class Interval(int start, int end)
    {
        public int Length => Math.Abs(end - start) + 1;
        public int GetNumberAt(int pos) => start < end ? start + pos : start - pos;
    }
}