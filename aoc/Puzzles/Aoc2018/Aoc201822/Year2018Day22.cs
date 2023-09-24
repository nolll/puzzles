using System.Linq;
using Common.Puzzles;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2018.Aoc201822;

public class Year2018Day22 : AocPuzzle
{
    public override string Name => "Mode Maze";

    protected override PuzzleResult RunPart1()
    {
        var rows = PuzzleInputReader.ReadLines(InputFile);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();

        var caveSystem = new CaveSystem(depth, targetX, targetY);
        return new PuzzleResult(caveSystem.TotalRiskLevel, 11_575);
    }

    protected override PuzzleResult RunPart2()
    {
        var rows = PuzzleInputReader.ReadLines(InputFile);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();
        var caveSystem = new CaveSystem(depth, targetX, targetY);

        var time = caveSystem.ResqueMan();
        return new PuzzleResult(time, 1068);
    }
}