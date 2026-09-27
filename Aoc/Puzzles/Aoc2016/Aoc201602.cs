using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Bathroom Security")]
public class Aoc201602 : AocPuzzle
{
    [Puzzle("bc6c7825d96d5406ad3776a37c342187")]
    public string Part1(string input) => new SquareKeyCodeFinder().Find(input);
    

    [Puzzle("e0e405db166ec0ceae706cf925ff34a9")]
    public string Part2(string input) => new DiamondKeyCodeFinder().Find(input);
    
    public class SquareKeyCodeFinder
    {
        private readonly Grid<char> _buttons = BuildButtonGrid();

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
        }

        private static Grid<char> BuildButtonGrid()
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
    }
    
    public class DiamondKeyCodeFinder
    {
        private readonly Grid<char> _buttons = BuildButtonGrid();

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

        private static Grid<char> BuildButtonGrid()
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

        private static IList<char[]> ParseCommands(string input) => 
            input.Split(LineBreaks.Single).Select(o => o.ToCharArray()).ToList();
    }

    public static class DirectionConverter
    {
        public static GridDirection GetDirection(char direction) => direction switch
        {
            'U' => GridDirection.Up,
            'R' => GridDirection.Right,
            'D' => GridDirection.Down,
            _ => GridDirection.Left
        };
    }
}