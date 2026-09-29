using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Perfectly Spherical Houses in a Vacuum")]
public class Aoc201503 : AocPuzzle
{
    [Puzzle("68e2d15877e8590fe0285bff9141a8cf")]
    public int Part1(string input) => DeliverAccordingToDirections(new(), input.ToCharArray());

    [Puzzle("7d063c75c9ee4f2a8fe2d97228a36f79")]
    public int Part2(string input)
    {
        var grid = new Grid<int>();
        var (santaDirections, robotDirections) = SplitDirections(input.ToCharArray());
        DeliverAccordingToDirections(grid, santaDirections);
        grid.MoveTo(grid.StartCoord);
        DeliverAccordingToDirections(grid, robotDirections);
        return grid.Values.Count(o => o > 0);
    }
    
    private static (IEnumerable<char> santa, IEnumerable<char> robot) SplitDirections(char[] allDirections)
    {
        var santaDirections = new List<char>();
        var robotDirections = new List<char>();
        for (var i = 0; i < allDirections.Length; i += 2)
        {
            santaDirections.Add(allDirections[i]);
            robotDirections.Add(allDirections[i + 1]);
        }

        return (santaDirections, robotDirections);
    }

    private static int DeliverAccordingToDirections(Grid<int> grid, IEnumerable<char> directions)
    {
        DeliverPresent(grid);
        foreach (var direction in directions)
        {
            Move(grid, direction);
            DeliverPresent(grid);
        }
            
        return grid.Values.Count(o => o > 0);
    }

    private static void DeliverPresent(Grid<int> grid) => grid.WriteValue(grid.ReadValue() + 1);
    private static void Move(Grid<int> grid, char direction) => grid.Move(GridDirection.Get(direction));
}