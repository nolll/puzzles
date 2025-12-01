using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202501;

[Name("Secret Entrance")]
public class Aoc202501 : AocPuzzle
{
    private const int Size = 100;

    public PuzzleResult Part1(string input)
    {
        var instructions = input.Split(LineBreaks.Single);
        var dial = 50;
        var size = 100;
        var count = 0;
        foreach (var instruction in instructions)
        {
            var dir = instruction.First();
            var distance = int.Parse(instruction[1..]);
            var sign = dir == 'L' ? -1 : 1;

            dial = (dial + size + sign * distance) % size;
            if (dial == 0)
                count++;
        }
        
        return new PuzzleResult(count, "d2f803dcf38047e9fad770d795e8b7f9");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Part2(input, 0);
        
        return new PuzzleResult(result, "db97ff1b6b08f45e787696e9baa69bab");
    }
    
    public int Part2(string input, int extraOrbitsForTest)
    {
        var instructions = input.Split(LineBreaks.Single);
        var dial = 50;
        var count = 0;
        foreach (var instruction in instructions)
        {
            var dir = instruction.First();
            var distance = int.Parse(instruction[1..]) + extraOrbitsForTest * Size;
            var sign = dir == 'L' ? -1 : 1;
            var extraOrbits = distance / Size;
            distance -= extraOrbits * Size;
            count += extraOrbits;
            var newdial = (dial + Size + sign * distance) % Size;
            
            if (newdial == 0)
                count++;
            else if (sign < 0 && dial != 0 && newdial > dial)
                count++;
            else if (sign > 0 && dial != 0 && newdial < dial)
                count++;

            dial = newdial;
        }
        
        return count;
    }
}