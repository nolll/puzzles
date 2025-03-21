using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202401;

[Name("")]
public class Codyssi202401 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select(int.Parse).Sum();
        return new PuzzleResult(sum, "2c9b60f4690033fb65c71e08bbc479a7");
    }

    public PuzzleResult Part2(string input) => new(RunPart2(input, 20), "c0e85368ae1524b621528b134724ecaa");

    public int RunPart2(string input, int freeItemCount) => 
        input.Split(LineBreaks.Single).Select(int.Parse).Order().SkipLast(freeItemCount).Sum();

    public PuzzleResult Part3(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var sum = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var multiplier = i % 2 == 0 ? 1 : -1;
            sum += items[i] * multiplier;
        }
        return new PuzzleResult(sum, "e7acbc96d2194896218445e87e203855");
    }
}