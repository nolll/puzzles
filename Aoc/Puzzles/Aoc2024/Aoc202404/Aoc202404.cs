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
        var matrix = MatrixBuilder.BuildCharMatrix(input);

        var xmasCount = 0;
        foreach (var coord in matrix.Coords)
        {
            var words = new List<string>();
            
            foreach (var dir in MatrixConstants.AllDirections)
            {
                matrix.MoveTo(coord);
                var word = ReadWord(matrix, dir);
                words.Add(word);
            }

            xmasCount += words.Count(o => o == "XMAS");
        }
        
        return new PuzzleResult(xmasCount, "31feb999cd31f07ccd5a86b42272d1d3");
    }
    
    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input, '.');

        var xmasCount = 0;
        foreach (var coord in matrix.Coords)
        {
            matrix.MoveTo(coord);
            xmasCount += IsX(matrix) ? 1 : 0;
        }
        
        return new PuzzleResult(xmasCount, "be01756ac17140a11342a320132dee7e");
    }

    private static string ReadWord(Matrix<char> matrix, (int x, int y) dir) => 
        string.Join("", ReadWordAsEnumerable(matrix, dir));

    private static IEnumerable<char> ReadWordAsEnumerable(Matrix<char> matrix, (int x, int y) dir)
    {
        yield return matrix.ReadValue();

        var i = 1;
        while (i < Part1WordLength)
        {
            if (!matrix.TryMoveTo(matrix.Address.X + dir.x, matrix.Address.Y + dir.y))
                break;

            yield return matrix.ReadValue();
            i++;
        }
    }
    
    private static bool IsX(Matrix<char> matrix)
    {
        var c = matrix.ReadValue();
        if (c != 'A')
            return false;

        var chars = MatrixConstants.DiagonalDirections
            .Select(o => matrix.ReadValueAt(matrix.Address.X + o.x, matrix.Address.Y - o.y)).ToArray();
        
        return IsMas($"{chars[0]}A{chars[2]}") && IsMas($"{chars[1]}A{chars[3]}");
    }

    private static bool IsMas(string word) => word is "MAS" or "SAM";
}