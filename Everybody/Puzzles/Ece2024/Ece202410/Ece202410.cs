using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202410;

[Name("Shrine Needs to Shine")]
public class Ece202410 : EverybodyEventPuzzle
{
    private const int SegmentSize = 8;

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var offset = new Coord(0, 0);
        FillSymbols(grid, offset);
        var word = ReadWord(grid, offset);
        
        return new PuzzleResult(word, "b62fc815678f7269aae352e26d1c3600");
    }
    
    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var offsets = GetOffsets(grid, 1).ToList();

        foreach (var offset in offsets)
        {
            FillSymbols(grid, offset);
        }

        var result = offsets.Select(offset => ReadWord(grid, offset)).ToList().Sum(GetScore);
        return new PuzzleResult(result, "ca8e2900fb3be19c6e0fbea1fa76eff6");
    }
    
    public PuzzleResult Part3(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        
        const int overlap = 2;
        var offsets = GetOffsets(grid, -overlap).ToList();

        const int sweepCount = 2;
        for (var i = 0; i < sweepCount; i++)
        {
            foreach (var offset in offsets)
            {
                FillSymbols(grid, offset);
                FillUnknowns(grid, offset);
            }
        }

        var result = offsets
            .Select(offset => ReadWord(grid, offset))
            .Where(o => !o.Contains('.'))
            .Sum(GetScore);
        
        return new PuzzleResult(result, "97cbe83a7e216984c51535fb553cf098");
    }

    public static long GetScore(string word)
    {
        const int charDiff = 64;
        var score = 0L;
        for (var i = 0; i < word.Length; i++)
        {
            var baseScore = word[i] - charDiff;
            score += baseScore * (i + 1);
        }

        return score;
    }
    
    private static string ReadWord(Grid<char> grid, Coord offset)
    {
        var wordGrid = grid.Slice(new Coord(offset.X + 2, offset.Y + 2), 4, 4);
        var chars = wordGrid.Coords.Select(o => wordGrid.ReadValueAt(o));
        return string.Join("", chars);
    }
    
    private static void FillSymbols(Grid<char> grid, Coord offset)
    {
        var coords = GetLocalCoords(offset);
        
        int[] positions = [0, 1, 6, 7];
        foreach (var coord in coords)
        {
            if (grid.ReadValueAt(coord) != '.')
                continue;
            
            var horizontal = positions.Aggregate("", (current, pos) => current + grid.ReadValueAt(pos + offset.X, coord.Y));
            var vertical = positions.Aggregate("", (current, pos) => current + grid.ReadValueAt(coord.X, pos + offset.Y));
            var c = horizontal.FirstOrDefault(o => vertical.Contains(o));
            if (c == default)
                c = '.';
            grid.WriteValueAt(coord, c);
        }
    }
    
    private static void FillUnknowns(Grid<char> grid, Coord offset)
    {
        var coords = GetLocalCoords(offset);
        var positions = Enumerable.Range(0, 8).ToArray();
        foreach (var coord in coords)
        {
            if (grid.ReadValueAt(coord) != '.')
                continue;

            var horizontal = positions.Select(o => new Coord(o + offset.X, coord.Y));
            var vertical = positions.Select(o => new Coord(coord.X, o + offset.Y));
            var all = horizontal.Concat(vertical).Where(o => !o.Equals(coord)).ToList();
            var questionMarkCoords = all.Where(o => grid.ReadValueAt(o) == '?').ToList();
            var allChars = all.Select(grid.ReadValueAt);
            var charsWithOneOccurrence = allChars.Where(o => o != '.' && o != '?').GroupBy(o => o).Where(o => o.Count() == 1).Select(o => o.Key).ToList();
            if (charsWithOneOccurrence.Count == 1)
            {
                var c = charsWithOneOccurrence.First();
                grid.WriteValueAt(coord, charsWithOneOccurrence.First());
                if(questionMarkCoords.Count == 1)
                    grid.WriteValueAt(questionMarkCoords.First(), c);
            }
        }
    }
    
    private static IEnumerable<Coord> GetLocalCoords(Coord offset)
    {
        for (var y = 0; y < SegmentSize; y++)
        {
            for (var x = 0; x < SegmentSize; x++)
            {
                yield return new Coord(offset.X + x, offset.Y + y);
            }    
        }
    }
    
    private static IEnumerable<Coord> GetOffsets(Grid<char> grid, int space)
    {
        var x = grid.XMin;
        var y = grid.YMin;
        while (y <= grid.YMax + space)
        {
            while (x <= grid.XMax + space)
            {
                yield return new Coord(x, y);
                x += SegmentSize + space;
            }

            x = grid.XMin;
            y += SegmentSize + space;
        }
    }
}