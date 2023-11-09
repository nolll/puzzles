using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202112;

public class Aoc202112 : AocPuzzle
{
    public override string Name => "Passage Pathing";

    protected override PuzzleResult RunPart1()
    {
        var caveSystem = new CaveSystem(InputFile, false);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, "f0ddaeeb33f1a0ff7a113ef020e9decd");
    }

    protected override PuzzleResult RunPart2()
    {
        var caveSystem = new CaveSystem(InputFile, true);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, "435c45d6610ccd392e06c43e52654eb5");
    }
}