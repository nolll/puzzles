using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202501;

[Name("Secret Entrance")]
public class Aoc202501 : AocPuzzle
{
    private const int Size = 100;

    public PuzzleResult Part1(string input) => new(Solve(input).stops, "d2f803dcf38047e9fad770d795e8b7f9");
    public PuzzleResult Part2(string input) => new(Solve(input).passes, "db97ff1b6b08f45e787696e9baa69bab");

    private static (int stops, int passes) Solve(string input)
    {
        var instructions = input.Split(LineBreaks.Single);
        var dial = 50;
        var stopCount = 0;
        var passCount = 0;
        foreach (var instruction in instructions)
        {
            var distance = int.Parse(instruction[1..]);
            var sign = instruction.First() == 'L' ? -1 : 1;

            for (var i = 0; i < distance; i++)
            {
                dial += sign + Size;
                dial %= Size;
                if (dial == 0)
                    passCount++;
            }
            
            if (dial == 0)
                stopCount++;
        }

        return (stopCount, passCount);
    }
}