using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0103;

[Name("The Conical Snail Clock")]
public class Ecs0103 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var snails = ParseSnails(input);
        const int iterations = 100;
        for (var c = 0; c < iterations; c++)
        {
            snails = MoveSnails(snails);
        }

        var sum = snails.Select(o => o.x + 100 * o.y).Sum();
        
        return new PuzzleResult(sum, "d051048d8661618a7c960f4992e086fd");
    }
    
    public PuzzleResult Part2(string input) => new(Part2And3(input), "6e4751eb49b140761150b2eca665319e");
    public PuzzleResult Part3(string input) => new(Part2And3(input), "4473ea2d23dce203ae09dd779eaca555");

    private static long Part2And3(string input)
    {
        var snails = ParseSnails(input)
            .Select(o => (loopSize: GetLoopSize(o), offset: GetOffset(o)))
            .OrderBy(o => o.loopSize).ToArray();

        var days = 0L;
        var totalSize = 1L;
        foreach (var (loopSize, offset) in snails)
        {
            while ((days - offset) % loopSize != 0)
                days += totalSize;
            
            totalSize = MathTools.Lcm(loopSize, totalSize);
        }
        
        return days;
    }

    private static long GetLoopSize((long x, long y) snail) => snail.y + snail.x - 1; 
    private static long GetOffset((long x, long y) snail) => snail.y - 1; 

    private static (long x, long y)[] ParseSnails(string input) => input.Split(LineBreaks.Single)
        .Select(Numbers.LongsFromString)
        .Select(o => (x: o[0], y: o[1]))
        .ToArray();

    private static (long x, long y)[] MoveSnails((long x, long y)[] snails)
    {
        for (var i = 0; i < snails.Length; i++)
        {
            snails[i].x += 1;
            snails[i].y -= 1;
            if (snails[i].y == 0)
            {
                snails[i].y = snails[i].x - 1;
                snails[i].x = 1;
            }
        }

        return snails;
    }
}