using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201808;

[Name("Memory Maneuver")]
public class Aoc201808(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var calculator = new LicenseNumberCalculator(Input);
        return new PuzzleResult(calculator.MetadataSum, "9c669208d829c31c0fdab74511ee9b14");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new LicenseNumberCalculator(Input);
        return new PuzzleResult(calculator.RootNodeValue, "67f685a992923369c5d0aca6b658a5d0");
    }
}