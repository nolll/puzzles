using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody10;

[Name("Shrine Needs to Shine")]
public class Everybody10 : EverybodyPuzzle
{
    private const int SegmentSize = 8;

    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var offset = new MatrixAddress(0, 0);
        FillSymbols(matrix, offset);
        var word = ReadWord(matrix, offset);
        
        return new PuzzleResult(word, "b62fc815678f7269aae352e26d1c3600");
    }
    
    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var offsets = GetOffsets(matrix, 1).ToList();

        foreach (var offset in offsets)
        {
            FillSymbols(matrix, offset);
        }

        var result = offsets.Select(offset => ReadWord(matrix, offset)).ToList().Sum(GetScore);
        return new PuzzleResult(result, "ca8e2900fb3be19c6e0fbea1fa76eff6");
    }
    
    public PuzzleResult Part3(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        
        const int overlap = 2;
        var offsets = GetOffsets(matrix, -overlap).ToList();

        const int sweepCount = 2;
        for (var i = 0; i < sweepCount; i++)
        {
            foreach (var offset in offsets)
            {
                FillSymbols(matrix, offset);
                FillUnknowns(matrix, offset);
            }
        }

        var result = offsets
            .Select(offset => ReadWord(matrix, offset))
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
    
    private static string ReadWord(Matrix<char> matrix, MatrixAddress offset)
    {
        var wordMatrix = matrix.Slice(new MatrixAddress(offset.X + 2, offset.Y + 2), 4, 4);
        var chars = wordMatrix.Coords.Select(o => wordMatrix.ReadValueAt(o));
        return string.Join("", chars);
    }
    
    private static void FillSymbols(Matrix<char> matrix, MatrixAddress offset)
    {
        var coords = GetLocalCoords(offset);
        
        int[] positions = [0, 1, 6, 7];
        foreach (var coord in coords)
        {
            if (matrix.ReadValueAt(coord) != '.')
                continue;
            
            var horizontal = positions.Aggregate("", (current, pos) => current + matrix.ReadValueAt(pos + offset.X, coord.Y));
            var vertical = positions.Aggregate("", (current, pos) => current + matrix.ReadValueAt(coord.X, pos + offset.Y));
            var c = horizontal.FirstOrDefault(o => vertical.Contains(o));
            if (c == default)
                c = '.';
            matrix.WriteValueAt(coord, c);
        }
    }
    
    private static void FillUnknowns(Matrix<char> matrix, MatrixAddress offset)
    {
        var coords = GetLocalCoords(offset);
        var positions = Enumerable.Range(0, 8).ToArray();
        foreach (var coord in coords)
        {
            if (matrix.ReadValueAt(coord) != '.')
                continue;

            var horizontal = positions.Select(o => new MatrixAddress(o + offset.X, coord.Y));
            var vertical = positions.Select(o => new MatrixAddress(coord.X, o + offset.Y));
            var all = horizontal.Concat(vertical).Where(o => !o.Equals(coord)).ToList();
            var questionMarkCoords = all.Where(o => matrix.ReadValueAt(o) == '?').ToList();
            var allChars = all.Select(matrix.ReadValueAt);
            var charsWithOneOccurrence = allChars.Where(o => o != '.' && o != '?').GroupBy(o => o).Where(o => o.Count() == 1).Select(o => o.Key).ToList();
            if (charsWithOneOccurrence.Count == 1)
            {
                var c = charsWithOneOccurrence.First();
                matrix.WriteValueAt(coord, charsWithOneOccurrence.First());
                if(questionMarkCoords.Count == 1)
                    matrix.WriteValueAt(questionMarkCoords.First(), c);
            }
        }
    }
    
    private static IEnumerable<MatrixAddress> GetLocalCoords(MatrixAddress offset)
    {
        for (var y = 0; y < SegmentSize; y++)
        {
            for (var x = 0; x < SegmentSize; x++)
            {
                yield return new MatrixAddress(offset.X + x, offset.Y + y);
            }    
        }
    }
    
    private static IEnumerable<MatrixAddress> GetOffsets(Matrix<char> matrix, int space)
    {
        var x = matrix.XMin;
        var y = matrix.YMin;
        while (y <= matrix.YMax + space)
        {
            while (x <= matrix.XMax + space)
            {
                yield return new MatrixAddress(x, y);
                x += SegmentSize + space;
            }

            x = matrix.XMin;
            y += SegmentSize + space;
        }
    }
}