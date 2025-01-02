using System.Text;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201602;

public class DiamondKeyCodeFinder
{
    private readonly Matrix<char> _buttons = BuildButtonMatrix();

    public string Find(string input)
    {
        var commandLines = ParseCommands(input);
        var code = new StringBuilder();
        foreach (var commandLine in commandLines)
        {
            foreach (var command in commandLine) 
                Move(command);

            code.Append(_buttons.ReadValue());
        }
        
        return code.ToString();
    }

    private void Move(char direction)
    {
        var dir = DirectionConverter.GetDirection(direction);
        _buttons.TryMove(dir);
        if (_buttons.ReadValue() == '.')
            _buttons.Move(dir.Opposite);
    }

    private static Matrix<char> BuildButtonMatrix()
    {
        const string input = """
                             ..1..
                             .234.
                             56789
                             .ABC.
                             ..D..
                             """;

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        matrix.MoveTo(0, 2);
        return matrix;
    }

    private static IList<char[]> ParseCommands(string input) => 
        StringReader.ReadLines(input).Select(o => o.ToCharArray()).ToList();
}

public static class DirectionConverter
{
    public static MatrixDirection GetDirection(char direction) => direction switch
    {
        'U' => MatrixDirection.Up,
        'R' => MatrixDirection.Right,
        'D' => MatrixDirection.Down,
        _ => MatrixDirection.Left
    };
}