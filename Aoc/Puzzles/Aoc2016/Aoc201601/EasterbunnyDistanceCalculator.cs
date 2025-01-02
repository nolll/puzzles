using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201601;

public class EasterbunnyDistanceCalculator
{
    private readonly Matrix<int> _matrix = new();
    private int? _distanceToFirstRepeatedAddress;

    public void Go(string input)
    {
        var instructions = input.Split(',').Select(o => o.Trim());
        _matrix.TurnTo(MatrixDirection.Up);
        _matrix.WriteValue(1);
        foreach (var instruction in instructions)
        {
            var direction = instruction.Substring(0, 1);
            var distance = int.Parse(instruction.Substring(1));
            if (direction == "R")
                _matrix.TurnRight();
            else
                _matrix.TurnLeft();
            
            for (var i = 0; i < distance; i++)
            {
                _matrix.MoveForward();
                if (_matrix.ReadValue() == 1 && _distanceToFirstRepeatedAddress == null)
                {
                    _distanceToFirstRepeatedAddress = _matrix.StartAddress.ManhattanDistanceTo(_matrix.Address);
                }
                _matrix.WriteValue(1);
            }
        }
    }

    public int DistanceToTarget => _matrix.StartAddress.ManhattanDistanceTo(_matrix.Address);
    public int DistanceToFirstRepeat => _distanceToFirstRepeatedAddress ?? 0;
}