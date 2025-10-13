using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201703;

public class SpiralMemory
{
    public int Distance { get; }
    public long Value { get; }

    public SpiralMemory(int targetSquare, SpiralMemoryMode mode)
    {
        var grid = BuildGrid(targetSquare, mode);
        Distance = grid.Coord.ManhattanDistanceTo(grid.StartCoord);
        Value = grid.ReadValue();
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
}