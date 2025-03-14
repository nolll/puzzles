using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201822;

[Name("Mode Maze")]
public class Aoc201822 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var rows = StringReader.ReadLines(input);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();

        var caveSystem = new CaveSystem(depth, targetX, targetY);
        return new PuzzleResult(caveSystem.TotalRiskLevel, "5df14da907f6928ed33a598ab21592eb");
    }

    public PuzzleResult RunPart2(string input)
    {
        var rows = StringReader.ReadLines(input);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();
        var caveSystem = new CaveSystem(depth, targetX, targetY);

        var time = caveSystem.ResqueMan();
        return new PuzzleResult(time, "4e117a44b69dd25c64f6f7b08d9c3a18");
    }
}