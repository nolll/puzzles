using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202012;

public class SimpleFerryNavigationSystem
{
    private readonly Grid<int> _grid;
    private readonly IEnumerable<FerryNavigationInstruction> _intructions;
    public int DistanceTravelled => _grid.Coord.ManhattanDistanceTo(_grid.StartCoord);
        
    public SimpleFerryNavigationSystem(string input)
    {
        var rows = StringReader.ReadLines(input);
        _intructions = rows.Select(FerryNavigationInstruction.Parse);

        _grid = new Grid<int>();
        _grid.TurnRight();
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
                _grid.MoveUp(instruction.Value);
                break;
            case 'E':
                _grid.MoveRight(instruction.Value);
                break;
            case 'S':
                _grid.MoveDown(instruction.Value);
                break;
            case 'W':
                _grid.MoveLeft(instruction.Value);
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
            _grid.MoveForward();
        }
    }

    private void TurnLeft(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            _grid.TurnLeft();
        }
    }

    private void TurnRight(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            _grid.TurnRight();
        }
    }
}