using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202516;

[Name("Harmonics of Stone")]
public class Ece202516 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var spell = Numbers.IntsFromString(input).ToList();
        var blockCount = CountRequiredBlocks(spell, 90);

        return new PuzzleResult(blockCount, "c43ffe414cd1f0d7024f9014c035703a");
    }

    public PuzzleResult Part2(string input)
    {
        var spell = GetSpell(input);
        var product = spell.Aggregate(1L, (current, b) => current * b);

        return new PuzzleResult(product, "d543f8d5b11ac6d4e21685cd8674fc6f");
    }

    public PuzzleResult Part3(string input) => new(Part3(input, 202_520_252_025_000), "b91ced40f2ab99acef778dbb6b61aeee");

    public long Part3(string input, long blocksAvailable) => BinarySearch(GetSpell(input), blocksAvailable);

    private static List<int> GetSpell(string input)
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

        return spell;
    }

    private static long BinarySearch(List<int> spell, long blocksAvailable)
    {
        var low = 0L;
        var high = blocksAvailable;
        
        while (low <= high) {
            var mid = low + (high - low) / 2;
            var requiredBlocks = CountRequiredBlocks(spell, mid);
            
            if (requiredBlocks == blocksAvailable)
                return mid;
            if (requiredBlocks < blocksAvailable)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return high;
    }

    private static long CountRequiredBlocks(List<int> spell, long wallLength) => spell.Sum(n => wallLength / n);
}