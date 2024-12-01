using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202112;

[Name("Passage Pathing")]
public class Aoc202112 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var caveSystem = new CaveSystem(input, false);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, "f0ddaeeb33f1a0ff7a113ef020e9decd");
    }

    public PuzzleResult RunPart2(string input)
    {
        var caveSystem = new CaveSystem(input, true);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, "435c45d6610ccd392e06c43e52654eb5");
    }
}