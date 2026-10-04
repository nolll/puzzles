using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Spiral Memory")]
public class Aoc201703 : AocPuzzle
{
    [Puzzle("748d6bb1c2e5af3bdc9deece20b7d9f5")]
    public int Part1(string input)
    {
        var grid = BuildGrid(int.Parse(input), SpiralMemoryMode.RunToTarget);
        return grid.Coord.ManhattanDistanceTo(grid.StartCoord);
    }

    [Puzzle("5378201bd68f309919ec6a47cde9888d")]
    public long Part2(string input)
    {
        var grid = BuildGrid(int.Parse(input), SpiralMemoryMode.RunToValue);
        return grid.ReadValue();
    }
    
    private static Grid<long> BuildGrid(int targetSquare, SpiralMemoryMode mode)
    {
        var grid = new Grid<long>();
        grid.TurnTo(GridDirection.Down);
        var currentSquare = 1;
        grid.WriteValue(currentSquare);
        while (currentSquare < targetSquare)
        {
            grid.TurnLeft();
            grid.MoveForward();
            var v = grid.ReadValue();
            if (v > 0)
            {
                grid.MoveBackward();
                grid.TurnRight();
                grid.MoveForward();
            }
            var valueToWrite = mode == SpiralMemoryMode.RunToValue
                ? grid.AllAdjacentValues.Sum() 
                : currentSquare;

            grid.WriteValue(valueToWrite);
            if (mode == SpiralMemoryMode.RunToValue && valueToWrite > targetSquare)
                break;

            currentSquare += 1;
        }

        return grid;
    }

    private enum SpiralMemoryMode
    {
        RunToTarget,
        RunToValue
    }
}