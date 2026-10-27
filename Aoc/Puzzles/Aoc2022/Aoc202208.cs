using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Treetop Tree House")]
public class Aoc202208 : AocPuzzle
{
    [Puzzle("db3773cdd4aa7c677d0d7b5276a6f31c")]
    public int Part1(string input)
    {
        var treeGrid = Parse(input);
        var grid = new Grid<bool>(treeGrid.Width, treeGrid.Height);
        foreach (var coord in treeGrid.Coords)
        {
            var visibility = InitVisibility();

            treeGrid.MoveTo(coord);
            var currentTreeHeight = treeGrid.ReadValue();

            foreach (var direction in GridDirection.Orthogonal)
            {
                treeGrid.TurnTo(direction);
                while (treeGrid.TryMoveForward())
                {
                    if (treeGrid.ReadValue() < currentTreeHeight)
                        continue;

                    visibility[direction] = false;
                    break;
                }

                treeGrid.MoveTo(coord);
            }

            grid.WriteValueAt(coord, visibility.Values.Any(o => o));
        }

        return grid.Values.Count(o => o);
    }

    [Puzzle("20def27ee2db6df6b7e178884edb9c87")]
    public int? Part2(string input)
    {
        var treeGrid = Parse(input);
        var grid = new Grid<int>(treeGrid.Width, treeGrid.Height);
        foreach (var coord in treeGrid.Coords)
        {
            var scores = InitScores();

            treeGrid.MoveTo(coord);
            var currentTreeHeight = treeGrid.ReadValue();

            foreach (var direction in GridDirection.Orthogonal)
            {
                treeGrid.TurnTo(direction);
                while (treeGrid.TryMoveForward())
                {
                    scores[direction]++;
                    if (treeGrid.ReadValue() >= currentTreeHeight)
                        break;
                }

                treeGrid.MoveTo(coord);
            }

            var scenicScore = scores.Values.Aggregate(1, (x, y) => x * y);
            grid.WriteValueAt(coord, scenicScore);
        }

        return grid.Values.Max();
    }

    private static Grid<int> Parse(string input) => GridBuilder.BuildIntGridFromNonSeparated(input);
    private static Dictionary<GridDirection, int> InitScores() => GridDirection.Orthogonal.ToDictionary(k => k, _ => 0);
    private static Dictionary<GridDirection, bool> InitVisibility() => GridDirection.Orthogonal.ToDictionary(k => k, _ => true);
}