using Pzl.Common;
using Pzl.Tools.Grids;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202404;

[Name("Ceres Search")]
public class Aoc202404 : AocPuzzle
{
    private const int Part1WordLength = 4;

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);

        var xmasCount = 0;
        foreach (var coord in grid.Coords)
        {
            var words = new List<string>();
            
            foreach (var dir in GridConstants.AllDirections)
            {
                grid.MoveTo(coord);
                var word = ReadWord(grid, dir);
                words.Add(word);
            }

            xmasCount += words.Count(o => o == "XMAS");
        }
        
        return new PuzzleResult(xmasCount, "31feb999cd31f07ccd5a86b42272d1d3");
    }
    
    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');

        var xmasCount = 0;
        foreach (var coord in grid.Coords)
        {
            grid.MoveTo(coord);
            xmasCount += IsX(grid) ? 1 : 0;
        }
        
        return new PuzzleResult(xmasCount, "be01756ac17140a11342a320132dee7e");
    }

    private static string ReadWord(Grid<char> grid, (int x, int y) dir) => 
        string.Join("", ReadWordAsEnumerable(grid, dir));

    private static IEnumerable<char> ReadWordAsEnumerable(Grid<char> grid, (int x, int y) dir)
    {
        yield return grid.ReadValue();

        var i = 1;
        while (i < Part1WordLength)
        {
            if (!grid.TryMoveTo(grid.Coord.X + dir.x, grid.Coord.Y + dir.y))
                break;

            yield return grid.ReadValue();
            i++;
        }
    }
    
    private static bool IsX(Grid<char> grid)
    {
        var c = grid.ReadValue();
        if (c != 'A')
            return false;

        var chars = GridConstants.DiagonalDirections
            .Select(o => grid.ReadValueAt(grid.Coord.X + o.x, grid.Coord.Y - o.y)).ToArray();
        
        return IsMas($"{chars[0]}A{chars[2]}") && IsMas($"{chars[1]}A{chars[3]}");
    }

    private static bool IsMas(string word) => word is "MAS" or "SAM";
}