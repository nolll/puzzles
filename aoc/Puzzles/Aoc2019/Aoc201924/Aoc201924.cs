using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201924;

public class Aoc201924 : AocPuzzle
{
    public override string Name => "Planet of Discord";

    protected override PuzzleResult RunPart1()
    {
        var simulator = new BugLifeSimulator(InputFile);
        simulator.RunUntilRepeat();

        return new PuzzleResult(simulator.BiodiversityRating, 12_129_040);
    }

    protected override PuzzleResult RunPart2()
    {
        var recursiveSimulator = new RecursiveBugLifeSimulator(InputFile);
        recursiveSimulator.Run(200);

        return new PuzzleResult(recursiveSimulator.BugCount, 2109);
    }
}