using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202516;

[Name("Harmonics of Stone")]
public class Ece202516 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var numbers = Numbers.IntsFromString(input);
        var blocks = new List<List<int>>();
        for (var i = 0; i < 90; i++)
        {
            blocks.Add([]);
        }
        for (var i = 1; i <= 90; i++)
        {
            foreach (var number in numbers)
            {
                if (i % number == 0)
                {
                    blocks[i - 1].Add(number);
                }
            }
        }
        
        return new PuzzleResult(blocks.Select(o => o.Count).Sum(), "c43ffe414cd1f0d7024f9014c035703a");
    }

    public PuzzleResult Part2(string input)
    {
        var wall = Numbers.IntsFromString(input);

        var block = 1;
        var spell = new List<int>();
        while (wall.Sum() > 0)
        {
            var index = block - 1;
            if (wall[block - 1] == 1)
            {
                spell.Add(block);

                for (var i = index; i < wall.Length; i += block)
                {
                    wall[i]--;
                }
            }

            block++;
        }

        var product = spell.Aggregate(1L, (current, b) => current * b);

        return new PuzzleResult(product, "d543f8d5b11ac6d4e21685cd8674fc6f");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}