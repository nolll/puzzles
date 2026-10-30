using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Coneservation")]
public class Ece202601 : EverybodyEventPuzzle
{
    [Puzzle("86dc3e9ad50547c3863d65b1b3f0896d")]
    public int Part1(string input) => Numbers.IntsFromString(input).Sum(o => NextSquare(o) - o);

    [Puzzle("865d18a926d70f3b5451c40e73c2ef1c")]
    public int Part2(string input) => Numbers.IntsFromString(input).Sum(o => NextBorder(o) - o);

    [Puzzle("7cc42f9d78dbb3a9924fbdae71e8cf6c")]
    public int Part3(string input) => Numbers.IntsFromString(input).Sum(o => NextAlmostSquare(o) - o);

    private static int NextSquare(int n)
    {
        var i = 1;
        var square = 0;
        while (square < n)
        {
            square = i * i;
            i++;
        }

        return square;
    }
    
    private static int NextBorder(int n)
    {
        var i = 3;
        var frame = 0;
        while (frame < n)
        {
            var inner = i - 2;
            frame = i * i - inner * inner;
            i++;
        }

        return frame;
    }
    
    private static int NextAlmostSquare(int n)
    {
        var i = 3;
        var frame = 0;
        while (frame < n)
        {
            frame = i * i - 1;
            i += 2;
        }

        return frame;
    }
}