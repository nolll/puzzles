using Pzl.Common;
using Pzl.Tools.CoordinateSystems;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202404;

[Name("Ceres Search")]
public class Aoc202404 : AocPuzzle
{
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
            xmasCount += ReadX(matrix);
        }
        
        return new PuzzleResult(xmasCount, "be01756ac17140a11342a320132dee7e");
    }

    private string ReadWord(Matrix<char> matrix, (int x, int y) dir)
    {
        var word = "";
        word += matrix.ReadValue();
        for (var i = 0; i < 3; i++)
        {
            if (!matrix.TryMoveTo(matrix.Address.X + dir.x, matrix.Address.Y + dir.y))
                break;
            
            word += matrix.ReadValue();
        }

        return word;
    }
    
    private int ReadX(Matrix<char> matrix)
    {
        var c = matrix.ReadValue();
        if (c != 'A')
            return 0;
        
        var tr = matrix.ReadValueAt(matrix.Address.X + 1, matrix.Address.Y - 1);
        var br = matrix.ReadValueAt(matrix.Address.X + 1, matrix.Address.Y + 1);
        var bl = matrix.ReadValueAt(matrix.Address.X - 1, matrix.Address.Y + 1);
        var tl = matrix.ReadValueAt(matrix.Address.X - 1, matrix.Address.Y - 1);

        var words = new List<string>();
        var word1 = $"{tl}A{br}"; 
        var word2 = $"{tr}A{bl}"; 
        words.Add(word1);
        words.Add(word1.ReverseString());
        words.Add(word2);
        words.Add(word2.ReverseString());

        return words.Count(o => o == "MAS") == 2 ? 1 : 0;
    }
}