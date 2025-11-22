using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202515;

[Name("Definitely Not a Maze")]
public class Ece202515 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var instructions = input.Split(',');
        var grid = new Grid<char>(1, 1, '.');
        grid.WriteValue('S');
        grid.TurnTo(GridDirection.Up);
        
        foreach (var instruction in instructions)
        {
            var direction = instruction.First();
            var distance = int.Parse(instruction[1..]);
            if (direction == 'L')
                grid.TurnLeft();
            else
                grid.TurnRight();
            for (var _ = 0; _ < distance; _++)
            {
                grid.MoveForward();
                grid.WriteValue('#');
            }
        }

        var startPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
        grid.WriteValueAt(startPoint, '.');
        var endPoint = grid.Coord;

        var path = PathFinder.ShortestPathTo(grid, startPoint, endPoint);
        
        return new PuzzleResult(path.Count(), "4a1a3b7a0e4af4aaf4c4f9e0b95430d4");
    }

    public PuzzleResult Part2(string input)
    {
        var instructions = input.Split(',');
        var grid = new Grid<char>(1, 1, '.');
        grid.WriteValue('S');
        grid.TurnTo(GridDirection.Up);
        grid.ExtendDown();
        
        foreach (var instruction in instructions)
        {
            var direction = instruction.First();
            var distance = int.Parse(instruction[1..]);
            if (direction == 'L')
                grid.TurnLeft();
            else
                grid.TurnRight();
            for (var _ = 0; _ < distance; _++)
            {
                grid.MoveForward();
                grid.WriteValue('#');
            }
        }

        var startPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
        grid.WriteValueAt(startPoint, '.');
        var endPoint = grid.Coord;

        var path = PathFinder.ShortestPathTo(grid, startPoint, endPoint);
        
        return new PuzzleResult(path.Count(), "c9e63859efb2156d5906e433e50285d0");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}