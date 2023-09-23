using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day12;

public class Year2021Day12 : AocPuzzle
{
    public override string Name => "Passage Pathing";

    protected override PuzzleResult RunPart1()
    {
        var caveSystem = new CaveSystem(FileInput, false);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, 5254);
    }

    protected override PuzzleResult RunPart2()
    {
        var caveSystem = new CaveSystem(FileInput, true);
        var result = caveSystem.CountPaths();
            
        return new PuzzleResult(result, 149385);
    }
}