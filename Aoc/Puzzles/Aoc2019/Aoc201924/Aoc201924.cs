using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

[Name("Planet of Discord")]
public class Aoc201924 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var simulator = new BugLifeSimulator(input);
        simulator.RunUntilRepeat();

        return new PuzzleResult(simulator.BiodiversityRating, "1871d15193d508d5be66268ad3cc074a");
    }

    public PuzzleResult RunPart2(string input)
    {
        var recursiveSimulator = new RecursiveBugLifeSimulator(input);
        recursiveSimulator.Run(200);

        return new PuzzleResult(recursiveSimulator.BugCount, "4309fbaca8e02ca8066a8fa6b49f9b2b");
    }
}