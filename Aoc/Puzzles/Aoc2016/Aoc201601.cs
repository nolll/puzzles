using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("No Time for a Taxicab")]
public class Aoc201601 : AocPuzzle
{
    [Puzzle("1dd73ae9ac359d399e07fb888b022f7a")]
    public int Part1(string input) => Solve(input, false);

    [Puzzle("4648ca473c884f7676991b343c2db8e0")]
    public int Part2(string input) => Solve(input, true);

    private static int Solve(string input, bool exitOnRepeat)
    {
        var grid = new Grid<int>();
        var instructions = input.Split(',').Select(o => o.Trim());
        grid.TurnTo(GridDirection.Up);
        grid.WriteValue(1);
        foreach (var instruction in instructions)
        {
            var direction = instruction[..1];
            var distance = int.Parse(instruction[1..]);
            if (direction == "R")
                grid.TurnRight();
            else
                grid.TurnLeft();
            
            for (var i = 0; i < distance; i++)
            {
                grid.MoveForward();
                if (exitOnRepeat && grid.ReadValue() == 1)
                    return grid.StartCoord.ManhattanDistanceTo(grid.Coord);
                
                grid.WriteValue(1);
            }
        }
        
        return grid.StartCoord.ManhattanDistanceTo(grid.Coord);
    }
}