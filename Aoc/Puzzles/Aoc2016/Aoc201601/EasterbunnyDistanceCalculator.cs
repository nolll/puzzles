using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201601;

public class EasterbunnyDistanceCalculator
{
    private readonly Grid<int> _grid = new();
    private int? _distanceToFirstRepeatedAddress;

    public void Go(string input)
    {
        var instructions = input.Split(',').Select(o => o.Trim());
        _grid.TurnTo(GridDirection.Up);
        _grid.WriteValue(1);
        foreach (var instruction in instructions)
        {
            var direction = instruction.Substring(0, 1);
            var distance = int.Parse(instruction.Substring(1));
            if (direction == "R")
                _grid.TurnRight();
            else
                _grid.TurnLeft();
            
            for (var i = 0; i < distance; i++)
            {
                _grid.MoveForward();
                if (_grid.ReadValue() == 1 && _distanceToFirstRepeatedAddress == null)
                {
                    _distanceToFirstRepeatedAddress = _grid.StartAddress.ManhattanDistanceTo(_grid.Address);
                }
                _grid.WriteValue(1);
            }
        }
    }

    public int DistanceToTarget => _grid.StartAddress.ManhattanDistanceTo(_grid.Address);
    public int DistanceToFirstRepeat => _distanceToFirstRepeatedAddress ?? 0;
}