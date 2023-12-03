using System.Text;
using Puzzles.common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201602;

public class SquareKeyCodeFinder
{
    private readonly Matrix<char> _buttons;

    public SquareKeyCodeFinder()
    {
        _buttons = BuildButtonMatrix();
    }

    public string Find(string input)
    {
        var commandLines = ParseCommands(input);
        var code = new StringBuilder();
        foreach (var commandLine in commandLines)
        {
            foreach (var command in commandLine)
            {
                Move(command);
            }

            code.Append(_buttons.ReadValue());
        }
        return code.ToString();
    }

    private void Move(char direction)
    {
        if (direction == 'U')
            _buttons.TryMoveUp();
        if (direction == 'R')
            _buttons.TryMoveRight();
        if (direction == 'D')
            _buttons.TryMoveDown();
        if (direction == 'L')
            _buttons.TryMoveLeft();
    }

    private static Matrix<char> BuildButtonMatrix()
    {
        const string input = """
123
456
789
""";

        var matrix = MatrixBuilder.BuildCharMatrix(input);
        matrix.MoveTo(1, 1);
        return matrix;
    }

    private static IList<char[]> ParseCommands(string input)
    {
        return StringReader.ReadLines(input).Select(o => o.ToCharArray()).ToList();
    }
}