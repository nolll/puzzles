using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202514;

[Name("The Game of Light")]
public class Ece202514 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = 0;
        for (var i = 0; i < 10; i++)
        {
            grid = NextStep(grid);
            count += grid.Values.Count(o => o == '#');
        }
        
        return new PuzzleResult(count, "a0147003c53749f3fe07887624e7f4fb");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = 0;
        for (var i = 0; i < 2025; i++)
        {
            grid = NextStep(grid);
            count += grid.Values.Count(o => o == '#');
        }
        
        return new PuzzleResult(count, "18d5ea1ad565154844e4544540b67cf5");
    }

    public PuzzleResult Part3(string input)
    {
        var seen = new Dictionary<string, (int index, int count)>();
        const int size = 34;
        var grid = new Grid<char>(size, size, '.');
        var patternGrid = GridBuilder.BuildCharGrid(input);
        var searchFor = patternGrid.Print().Replace(LineBreaks.Single, "");
        var (centerWidth, centerHeight) = (patternGrid.Width, patternGrid.Height);
        var sliceCoord = new Coord((grid.Width - centerWidth) / 2, (grid.Height - centerHeight) / 2);
        int loopLength;
        var index = 0;
        while (true)
        {
            grid = NextStep(grid);

            var center = grid.Slice(sliceCoord, centerWidth, centerHeight);
            var key = center.Print().Replace(LineBreaks.Single, "");
            if (key == searchFor)
            {
                var fullKey = grid.Print().Replace(LineBreaks.Single, "");
                
                if (seen.TryGetValue(fullKey, out var value))
                {
                    loopLength = index - value.index;
                    break;
                }
                
                var count = grid.Values.Count(o => o == '#');
                seen.Add(fullKey, (index, count));
            }
            
            index++;
        }
        
        var totalCount = 0L;
        foreach (var value in seen.Values)
        {
            var n = value.index;
            while (n <= 1_000_000_000)
            {
                totalCount += value.count;
                n += loopLength;
            }
        }
        
        return new PuzzleResult(totalCount, "4093ed780cd8cd567ea1d2fdf4e14cb6");
    }

    private static Grid<char> NextStep(Grid<char> grid)
    {
        var newGrid = new Grid<char>(grid.Width, grid.Height, '.');
        foreach (var coord in grid.Coords)
        {
            var isLit = grid.ReadValueAt(coord) == '#';
            var adj = grid.DiagonalAdjacentCoordsTo(coord);
            var litCount = adj.Count(o => grid.ReadValueAt(o) == '#');
            if (isLit && litCount % 2 != 0 || !isLit && litCount % 2 == 0)
                newGrid.WriteValueAt(coord, '#');
        }

        return newGrid;
    }
}