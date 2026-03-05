using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0302;

[Name("")]
public class Ecs0302 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var start = grid.FindAddresses('@').First();
        grid.MoveTo(start);
        grid.WriteValue('+');
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;

        while (true)
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

            if (grid.ReadValue() == '#')
                break;
            
            grid.WriteValue('+');
            grid.TurnRight();
        }
        
        return new PuzzleResult(stepCount, "38aac781a486c5ca9eb6efe32f529b4e");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}