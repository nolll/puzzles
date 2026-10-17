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
        var rows = input.Split(LineBreaks.Single);
        var instructions = rows.Select(Parse);

        var grid = new Grid<int>();
        grid.TurnRight();

        foreach (var (direction, value) in instructions)
        {
            MovePart1(grid, direction, value);
        }

        return DistanceTravelled(grid.Coord);
    }

    [Puzzle("c0c5befc741f65a1030078ab200ffe10")]
    public int Part2(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var intructions = rows.Select(Parse);

        var state = new State(new Coord(0, 0), new Coord(10, 1));
        foreach (var (direction, value) in intructions)
        {
            MovePart2(state, direction, value);
        }

        return DistanceTravelled(state.Address);
    }

    private static void MovePart1(Grid<int> grid, char direction, int value)
    {
        switch (direction)
        {
            case 'N':
                grid.MoveUp(value);
                break;
            case 'E':
                grid.MoveRight(value);
                break;
            case 'S':
                grid.MoveDown(value);
                break;
            case 'W':
                grid.MoveLeft(value);
                break;
            case 'L':
                grid.TurnLeft(value);
                break;
            case 'R':
                grid.TurnRight(value);
                break;
            default:
                grid.MoveForward(value);
                break;
        }
    }

    private static void MovePart2(State state, char direction, int value)
    {
        // The coordinate system is upside down here for some reason
        // Could be that the waypoint should start at 10,-1 but that does not work either
        switch (direction)
        {
            case 'N':
                state.Waypoint = state.Waypoint.Down(value);
                break;
            case 'E':
                state.Waypoint = state.Waypoint.Right(value);
                break;
            case 'S':
                state.Waypoint =  state.Waypoint.Up(value);
                break;
            case 'W':
                state.Waypoint = state.Waypoint.Left(value);
                break;
            case 'L':
                RotateLeft(state, value);
                break;
            case 'R':
                RotateRight(state, value);
                break;
            default:
                MoveForward(state, value);
                break;
        }
    }

    private static void MoveForward(State state, int steps) => 
        state.Address = state.Address.Move(state.Waypoint.X * steps, state.Waypoint.Y * steps);

    private static void RotateLeft(State state, int degrees) => Rotate(RotateLeft, state, degrees);
    private static void RotateRight(State state, int degrees) => Rotate(RotateRight, state, degrees);
    private static void RotateLeft(State state) => state.Waypoint = state.Waypoint.RotateLeft();
    private static void RotateRight(State state) => state.Waypoint = state.Waypoint.RotateRight();
    private static int DistanceTravelled(Coord coord) => coord.ManhattanDistanceTo(new Coord(0, 0));
    
    private static void Rotate(Action<State> rotate, State state, int degrees)
    {
        for (var i = 0; i < degrees / 90; i++) 
            rotate(state);
    }
    
    private class State(Coord address, Coord waypoint)
    {
        public Coord Address { get; set; } = address;
        public Coord Waypoint { get; set; } = waypoint;
    }
    
    public static (char direction, int value) Parse(string s) => new(s[0], int.Parse(s[1..]));
}