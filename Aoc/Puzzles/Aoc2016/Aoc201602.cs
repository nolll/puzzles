using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Bathroom Security")]
public class Aoc201602 : AocPuzzle
{
    [Puzzle("bc6c7825d96d5406ad3776a37c342187")]
    public string Part1(string input) => FindPart1Code(input);
    

    [Puzzle("e0e405db166ec0ceae706cf925ff34a9")]
    public string Part2(string input) => FindPart2Code(input);
    
    public string FindPart1Code(string input)
    {
        var buttons = BuildPart1ButtonGrid();
        var commandLines = ParseCommands(input);
        var code = new StringBuilder();
        foreach (var commandLine in commandLines)
        {
            foreach (var command in commandLine) 
                MovePart1(buttons, command);

            code.Append(buttons.ReadValue());
        }
        return code.ToString();
    }

    private void MovePart1(Grid<char> buttons, char direction)
    {
        var dir = GetDirection(direction);
        buttons.TryMove(dir);
    }

    private static Grid<char> BuildPart1ButtonGrid()
    {
        const string input = """
                             123
                             456
                             789
                             """;

        var grid = GridBuilder.BuildCharGrid(input);
        grid.MoveTo(1, 1);
        return grid;
    }

    private static IList<char[]> ParseCommands(string input) => 
        input.Split(LineBreaks.Single).Select(o => o.ToCharArray()).ToList();
    
    public string FindPart2Code(string input)
    {
        var buttons = BuildPart2ButtonGrid();
        var commandLines = ParseCommands(input);
        var code = new StringBuilder();
        foreach (var commandLine in commandLines)
        {
            foreach (var command in commandLine) 
                MovePart2(buttons, command);

            code.Append(buttons.ReadValue());
        }
        
        return code.ToString();
    }

    private static void MovePart2(Grid<char> buttons, char direction)
    {
        var dir = GetDirection(direction);
        buttons.TryMove(dir);
        if (buttons.ReadValue() == '.')
            buttons.Move(dir.Opposite);
    }

    private static Grid<char> BuildPart2ButtonGrid()
    {
        const string input = """
                             ..1..
                             .234.
                             56789
                             .ABC.
                             ..D..
                             """;

        var grid = GridBuilder.BuildCharGrid(input);
        grid.MoveTo(0, 2);
        return grid;
    }

    private static GridDirection GetDirection(char direction) => direction switch
    {
        'U' => GridDirection.Up,
        'R' => GridDirection.Right,
        'D' => GridDirection.Down,
        _ => GridDirection.Left
    };
}