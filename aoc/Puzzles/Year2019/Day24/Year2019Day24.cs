using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day24;

public class Year2019Day24 : AocPuzzle
{
    public override string Name => "Planet of Discord";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new BugLifeSimulator(FileInput);
        simulator.RunUntilRepeat();

        return new PuzzleResult(simulator.BiodiversityRating, 12_129_040);
    }

    protected override PuzzleResult RunPart2()
    {
        var recursiveSimulator = new RecursiveBugLifeSimulator(FileInput);
        recursiveSimulator.Run(200);

        return new PuzzleResult(recursiveSimulator.BugCount, 2109);
    }
}