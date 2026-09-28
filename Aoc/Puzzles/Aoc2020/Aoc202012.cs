using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Rain Risk")]
public class Aoc202012 : AocPuzzle
{
    [Puzzle("c78da9d22889e3d4313249117e3752f4")]
    public int Part1(string input)
    {
        var system = new SimpleFerryNavigationSystem(input);
        system.Run();
        return system.DistanceTravelled;
    }

    [Puzzle("c0c5befc741f65a1030078ab200ffe10")]
    public int Part2(string input)
    {
        var system = new WaypointFerryNavigationSystem(input);
        system.Run();
        return system.DistanceTravelled;
    }
    
    public class SimpleFerryNavigationSystem
    {
        private readonly Grid<int> _grid;
        private readonly IEnumerable<FerryNavigationInstruction> _intructions;
        public int DistanceTravelled => _grid.Coord.ManhattanDistanceTo(_grid.StartCoord);
        
        public SimpleFerryNavigationSystem(string input)
        {
            var rows = input.Split(LineBreaks.Single);
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

    public class WaypointFerryNavigationSystem
    {
        private Coord _address;
        private Coord _waypoint;
        private readonly IEnumerable<FerryNavigationInstruction> _intructions;
        public int DistanceTravelled => _address.ManhattanDistanceTo(new Coord(0, 0));

        public WaypointFerryNavigationSystem(string input)
        {
            var rows = input.Split(LineBreaks.Single);
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

        private void MoveForward(int steps) =>
            _address = new Coord(_address.X + _waypoint.X * steps, _address.Y + _waypoint.Y * steps);

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

        private void RotateLeft() => _waypoint = new Coord(-_waypoint.Y, _waypoint.X);
        private void RotateRight() => _waypoint = new Coord(_waypoint.Y, -_waypoint.X);
    }
    
    public class FerryNavigationInstruction
    {
        public char Direction { get; }
        public int Value { get; }

        public FerryNavigationInstruction(char direction, int value)
        {
            Direction = direction;
            Value = value;
        }

        public static FerryNavigationInstruction Parse(string s)
        {
            return new FerryNavigationInstruction(s[0], int.Parse(s.Substring(1)));
        }
    }
}