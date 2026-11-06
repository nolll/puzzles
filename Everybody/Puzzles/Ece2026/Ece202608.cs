using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Entgineering")]
public class Ece202608 : EverybodyEventPuzzle
{
    [Puzzle("2214c66a6958621009f2c79881b805c9")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        grid.ExtendAllDirections();
        var visible = new HashSet<Coord>();
        var startTrees = new HashSet<Coord>();
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v == '.')
                continue;
            
            if (grid.ReadValueAt(coord.Add(-1, -1)) == '.')
                startTrees.Add(coord);
        }

        foreach (var tree in startTrees)
        {
            grid.MoveTo(tree);
            visible.Add(tree);
            var shadowHeight = int.Parse(grid.ReadValue().ToString());
            while (true)
            {
                shadowHeight--;
                Move(grid);
                var v = grid.ReadValue();
                if (v == '.')
                    break;
                var treeHeight = int.Parse(v.ToString());
                var isVisible = treeHeight > shadowHeight;
                if (isVisible)
                {
                    visible.Add(grid.Coord);
                }

                shadowHeight = Math.Max(shadowHeight, treeHeight);
            }
        }

        return visible.Count;
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
    
    private static void Move(Grid<char> grid)
    {
        grid.MoveRight();
        grid.MoveDown();
    }
}