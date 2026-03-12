using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202401;

[Name("Handling the Budget")]
public class Codyssi202401 : CodyssiPuzzle
{
    [Puzzle("2c9b60f4690033fb65c71e08bbc479a7")]
    public int Part1(string input) => input.Split(LineBreaks.Single).Select(int.Parse).Sum();

    [Puzzle("c0e85368ae1524b621528b134724ecaa")]
    public int Part2(string input, int freeItemCount = 20) => input.Split(LineBreaks.Single).Select(int.Parse).Order().SkipLast(freeItemCount).Sum();

    [Puzzle("e7acbc96d2194896218445e87e203855")]
    public int Part3(string input)
    {
        var items = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var sum = 0;
        for (var i = 0; i < items.Length; i++)
        {
            var multiplier = i % 2 == 0 ? 1 : -1;
            sum += items[i] * multiplier;
        }
        return sum;
    }
}