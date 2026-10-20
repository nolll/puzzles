using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Sea Cucumber")]
public class Aoc202125 : AocPuzzle
{
    [Puzzle("b2c5d4f507c64adf10e3434888f5c9a9")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);

        var steps = 0;
        var moved = true;
        while (moved)
        {
            moved = Move(grid);
            steps++;
        }

        return steps;
    }

    private static bool Move(Grid<char> grid)
    {
        var cucumbersToMoveEast = FindCucumbersToMoveEast(grid);
        MoveCucumberEast(grid, cucumbersToMoveEast);

        var cucumbersToMoveSouth = FindCucumbersToMoveSouth(grid);
        MoveCucumberSouth(grid, cucumbersToMoveSouth);

        return cucumbersToMoveEast.Count != 0 || cucumbersToMoveSouth.Count != 0;
    }

    private static List<Coord> FindCucumbersToMoveEast(Grid<char> grid) => FindCucumbersToMove(grid, '>', NextValueEast);
    private static List<Coord> FindCucumbersToMoveSouth(Grid<char> grid) => FindCucumbersToMove(grid, 'v', NextValueSouth);

    private static List<Coord> FindCucumbersToMove(Grid<char> grid, char direction, Func<Grid<char>, char> nextValue)
    {
        var cucumbersToMove = new List<Coord>();
        foreach (var coord in grid.Coords)
        {
            grid.MoveTo(coord);
            if (grid.ReadValue() != direction)
                continue;

            if (nextValue(grid) == '.')
                cucumbersToMove.Add(coord);
        }

        return cucumbersToMove;
    }

    private static char NextValueEast(Grid<char> grid) => grid.TryMoveRight() ? grid.ReadValue() : grid.ReadValueAt(0, grid.Coord.Y);
    private static char NextValueSouth(Grid<char> grid) => grid.TryMoveDown() ? grid.ReadValue() : grid.ReadValueAt(grid.Coord.X, 0);

    private static void MoveCucumberSouth(Grid<char> grid, List<Coord> cucumbersToMove) =>
        MoveCucumber(grid, cucumbersToMove, 'v', TryMoveDown, WrapAroundDown);

    private static void MoveCucumberEast(Grid<char> grid, List<Coord> cucumbersToMove) =>
        MoveCucumber(grid, cucumbersToMove, '>', TryMoveRight, WrapAroundRight);

    private static void MoveCucumber(
        Grid<char> grid,
        List<Coord> cucumbersToMove,
        char direction,
        Func<Grid<char>, bool> tryMove,
        Action<Grid<char>> wrapAround)
    {
        foreach (var coord in cucumbersToMove)
        {
            grid.MoveTo(coord);
            grid.WriteValue('.');
            if (tryMove(grid))
            {
                grid.WriteValue(direction);
            }
            else
            {
                wrapAround(grid);
                grid.WriteValue(direction);
            }
        }
    }

    private static bool TryMoveRight(Grid<char> grid) => grid.TryMoveRight();
    private static bool TryMoveDown(Grid<char> grid) => grid.TryMoveDown();
    private static void WrapAroundRight(Grid<char> grid) => grid.MoveTo(0, grid.Coord.Y);
    private static void WrapAroundDown(Grid<char> grid) => grid.MoveTo(grid.Coord.X, 0);
}