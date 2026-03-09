using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201822;

[Name("Mode Maze")]
public class Aoc201822 : AocPuzzle
{
    [Puzzle("5df14da907f6928ed33a598ab21592eb")]
    public long Part1(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();

        return new CaveSystem(depth, targetX, targetY).TotalRiskLevel;
    }

    [Puzzle("4e117a44b69dd25c64f6f7b08d9c3a18")]
    public int Part2(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();
        var caveSystem = new CaveSystem(depth, targetX, targetY);

        return caveSystem.ResqueMan();
    }
}