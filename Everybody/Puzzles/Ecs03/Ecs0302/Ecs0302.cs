using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0302;

[Name("How Quack Echoes Back")]
public class Ecs0302 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        var start = grid.FindAddresses('@').First();
        var end = grid.FindAddresses('#').First();
        grid.MoveTo(start);
        grid.WriteValue('+');
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;

        while (grid.Coord != end)
        {
            stepCount++;
            while (true)
            {
                grid.MoveForward();
                if (grid.ReadValue() == '+')
                {
                    grid.MoveBackward();
                    grid.TurnRight();
                    continue;
                }

                break;
            }
            
            grid.WriteValue('+');
            grid.TurnRight();
        }
        
        return new PuzzleResult(stepCount, "38aac781a486c5ca9eb6efe32f529b4e");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        var start = grid.FindAddresses('@').First();
        var end = grid.FindAddresses('#').First();
        grid.MoveTo(start);
        grid.WriteValue('+');
        grid.WriteValueAt(end, '+');
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;
        
        var endAdjCoords = grid.PossibleOrthogonalAdjacentCoordsTo(end).ToList();

        while (endAdjCoords.Any(o => grid.ReadValueAt(o) != '+'))
        {
            stepCount++;
         
            while (true)
            {
                grid.MoveForward();
                if (grid.ReadValue() == '+')
                {
                    grid.MoveBackward();
                    grid.TurnRight();
                    continue;
                }

                break;
            }

            grid.WriteValue('+');
            var adj = grid.PossibleOrthogonalAdjacentCoords;
            foreach (var a in adj)
            {
                var ort = grid.OrthogonalAdjacentValuesTo(a);
                if(ort.Count == 4 && ort.All(o => o != '.'))
                    grid.WriteValueAt(a, '+');
            }
            
            grid.TurnRight();
        }
        
        return new PuzzleResult(stepCount, "9621d21040a0ca3450ce213d1dca7bb5");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}