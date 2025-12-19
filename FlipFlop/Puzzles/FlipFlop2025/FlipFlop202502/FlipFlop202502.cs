using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202502;

[Name("Rollercoaster Heights")]
public class FlipFlop202502 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var best = 0;
        var height = 0;
        foreach (var c in input)
        {
            height += c == '^' ? 1 : -1;
            best = Math.Max(best, height);
        }
        return new PuzzleResult(best, "a108ed87069fbb10b6d6595e8795dc16");
    }

    public PuzzleResult Part2(string input)
    {
        var direction = 0;
        var best = 0;
        var height = 0;
        var speed = 1;
        foreach (var c in input)
        {
            var newdir = c == '^' ? 1 : -1;
            if (newdir != direction)
            {
                direction = newdir;
                speed = 1;
            }
            else
            {
                speed += 1;
            }
                
            height += speed * direction;
            best = Math.Max(best, height);
        }
        
        return new PuzzleResult(best, "3d520917bed77059dbbb4bf1f7433ffa");
    }

    public PuzzleResult Part3(string input)
    {
        var best = 0L;
        var height = 0L;

        var chars = input.ToCharArray();
        var lastchar = chars.First();
        var length = 1;
        var sequences = new List<int>();
        for (var i = 1; i < chars.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                sequences.Add(length);
                length = 0;
            }

            length++;
        }
        sequences.Add(length);
        
        var direction = lastchar == '^' ? 1 : -1;
        foreach (var sequence in sequences)
        {
            height += direction * Numbers.Fibonacci(sequence);
            best = Math.Max(best, height);
            direction *= -1;
        }
        
        return new PuzzleResult(best, "9116cf946c0d82e0d08bffc0da078dd1");
    }
}