using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202012;

public class WaypointFerryNavigationSystem
{
    private Coord _address;
    private Coord _waypoint;
    private readonly IEnumerable<FerryNavigationInstruction> _intructions;
    public int DistanceTravelled => _address.ManhattanDistanceTo(new Coord(0, 0));

    public WaypointFerryNavigationSystem(string input)
    {
        var rows = StringReader.ReadLines(input);
        _intructions = rows.Select(FerryNavigationInstruction.Parse);

        _address = new Coord(0, 0);
        _waypoint = new Coord(10, 1);
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
                _waypoint = new Coord(_waypoint.X, _waypoint.Y + instruction.Value);
                break;
            case 'E':
                _waypoint = new Coord(_waypoint.X + instruction.Value, _waypoint.Y);
                break;
            case 'S':
                _waypoint = new Coord(_waypoint.X, _waypoint.Y - instruction.Value);
                break;
            case 'W':
                _waypoint = new Coord(_waypoint.X - instruction.Value, _waypoint.Y);
                break;
            case 'L':
                RotateLeft(instruction.Value);
                break;
            case 'R':
                RotateRight(instruction.Value);
                break;
            default:
                MoveForward(instruction.Value);
                break;
        }
    }

    private void MoveForward(int steps)
    {
        _address = new Coord(_address.X + _waypoint.X * steps, _address.Y + _waypoint.Y * steps);
    }

    private void RotateLeft(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            RotateLeft();
        }
    }

    private void RotateRight(int degrees)
    {
        for (var i = 0; i < degrees; i += 90)
        {
            RotateRight();
        }
    }

    private void RotateLeft()
    {
        _waypoint = new Coord(-_waypoint.Y, _waypoint.X);
    }

    private void RotateRight()
    {
        _waypoint = new Coord(_waypoint.Y, -_waypoint.X);
    }
}