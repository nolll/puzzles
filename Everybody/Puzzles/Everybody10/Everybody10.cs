using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody10;

[Name("Shrine Needs to Shine")]
public class Everybody10 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var word = GetWord(matrix);
        
        return new PuzzleResult(word, "b62fc815678f7269aae352e26d1c3600");
    }
    
    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);

        const int sliceSize = 8;
        const int stepSize = sliceSize + 1;
        var x = 0;
        var y = 0;
        var matrices = new List<Matrix<char>>();
        while (y <= matrix.YMax)
        {
            while (x <= matrix.XMax)
            {
                var from = new MatrixAddress(x, y);
                matrices.Add(matrix.Slice(from, sliceSize, sliceSize));
                x += stepSize;
            }

            x = 0;
            y += stepSize;
        }

        var result = matrices.Select(GetWord).Sum(GetScore);
        return new PuzzleResult(result, "ca8e2900fb3be19c6e0fbea1fa76eff6");
    }

    public long GetScore(string word)
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

    private string GetWord(Matrix<char> matrix)
    {
        var chars = new List<char>();
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) != '.')
                continue;

            int[] positions = [0, 1, 6, 7];
            var horizontal = positions.Aggregate("", (current, pos) => current + matrix.ReadValueAt(pos, coord.Y));
            var vertical = positions.Aggregate("", (current, pos) => current + matrix.ReadValueAt(coord.X, pos));
            chars.Add((char?)horizontal.FirstOrDefault(o => vertical.Contains(o)) ?? '?');
        }

        return string.Join("", chars);
    }
}