using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201808;

[Name("Memory Maneuver")]
public class Aoc201808 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var calculator = new LicenseNumberCalculator(input);
        return new PuzzleResult(calculator.MetadataSum, "9c669208d829c31c0fdab74511ee9b14");
    }

    public PuzzleResult RunPart2(string input)
    {
        var calculator = new LicenseNumberCalculator(input);
        return new PuzzleResult(calculator.RootNodeValue, "67f685a992923369c5d0aca6b658a5d0");
    }
}