using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202012;

public class SimpleFerryNavigationSystem
{
    private readonly Matrix<int> _matrix;
    private readonly IEnumerable<FerryNavigationInstruction> _intructions;
    public int DistanceTravelled => _matrix.Address.ManhattanDistanceTo(_matrix.StartAddress);
        
    public SimpleFerryNavigationSystem(string input)
    {
        var rows = StringReader.ReadLines(input);
        _intructions = rows.Select(FerryNavigationInstruction.Parse);

        _matrix = new Matrix<int>();
        _matrix.TurnRight();
    }

    public void Run()
    {
        foreach (var instruction in _intructions)
        {
            Move(instruction);
        }
    }

    private void Move(FerryNavigationInstruction instruction)
    {
        switch (instruction.Direction)
        {
            case 'N':
                _matrix.MoveUp(instruction.Value);
                break;
            case 'E':
                _matrix.MoveRight(instruction.Value);
                break;
            case 'S':
                _matrix.MoveDown(instruction.Value);
                break;
            case 'W':
                _matrix.MoveLeft(instruction.Value);
                break;
            case 'L':
                TurnLeft(instruction.Value);
                break;
            case 'R':
                TurnRight(instruction.Value);
                break;
            default:
                MoveForward(instruction.Value);
                break;
        }
    }

    private void MoveForward(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            _matrix.MoveForward();
        }
    }

    private void TurnLeft(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            _matrix.TurnLeft();
        }
    }

    private void TurnRight(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            _matrix.TurnRight();
        }
    }
}