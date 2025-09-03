using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0103;

[Name("The Conical Snail Clock")]
public class Ecs0103 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var snails = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => (x: o[0], y: o[1]))
            .ToArray();

        const int iterations = 100;
        for (var c = 0; c < iterations; c++)
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
        }

        var sum = snails.Select(o => o.x + 100 * o.y).Sum();
        
        return new PuzzleResult(sum, "d051048d8661618a7c960f4992e086fd");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}