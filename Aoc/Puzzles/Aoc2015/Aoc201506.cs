using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Probably a Fire Hazard")]
public class Aoc201506 : AocPuzzle
{
    private const int Size = 1000;

    [Puzzle("8cde00a802ab8a80c8939584c4fede8a")]
    public int Part1(string input)
    {
        var grid = new Grid<int>(Size, Size);
        RunCommands(grid, input, false);
        return LitCount(grid);
    }

    [Puzzle("d8489f6672714633835714401c5d3116")]
    public int Part2(string input)
    {
        var grid = new Grid<int>(Size, Size);
        RunCommands(grid, input, true);
        return Brightness(grid);
    }
    
    public static int LitCount(Grid<int> grid) => grid.Values.Count(o => o > 0);
    public static int Brightness(Grid<int> grid) => grid.Values.Sum();

    public static void RunCommands(Grid<int> grid, string input, bool useBrightness)
    {
        var commands = ParseCommands(input, useBrightness);
        foreach (var command in commands)
        {
            command.Move(grid);
        }
    }

    private static IEnumerable<Command> ParseCommands(string input, bool useBrightness) =>
        input.Split(LineBreaks.Single).Select(o => CreateCommand(o, useBrightness)).ToList();

    private static Command CreateCommand(string s, bool useBrightness)
    {
        var paramString = s.Replace("turn on", "").Replace("turn off", "").Replace("toggle", "");
        if (s.StartsWith("turn on"))
            return useBrightness
                ? new IncreaseCommand(paramString, 1)
                : new TurnOnCommand(paramString);

        if (s.StartsWith("turn off"))
            return useBrightness
                ? new IncreaseCommand(paramString, -1)
                : new TurnOffCommand(s);

        if (s.StartsWith("toggle"))
            return useBrightness
                ? new IncreaseCommand(paramString, 2)
                : new ToggleCommand(s);

        return new VoidCommand();
    }

    public class TurnOnCommand : Command
    {
        public TurnOnCommand(string s) : base(s.Replace("turn on", ""))
        {
        }

        public TurnOnCommand(int xa, int ya, int xb, int yb) : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Grid<int> grid, int x, int y) => grid.WriteValueAt(x, y, 1);
    }

    public class TurnOffCommand : Command
    {
        public TurnOffCommand(string s) : base(s.Replace("turn off", ""))
        {
        }

        public TurnOffCommand(int xa, int ya, int xb, int yb) : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Grid<int> grid, int x, int y) => grid.WriteValueAt(x, y, 0);
    }

    public class ToggleCommand : Command
    {
        public ToggleCommand(string s) : base(s.Replace("toggle", ""))
        {
        }

        public ToggleCommand(int xa, int ya, int xb, int yb) : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Grid<int> grid, int x, int y)
        {
            var newValue = grid.ReadValueAt(x, y) == 0 ? 1 : 0;
            grid.WriteValueAt(x, y, newValue);
        }
    }

    private class IncreaseCommand(string s, int increment) : Command(s)
    {
        protected override void Change(Grid<int> grid, int x, int y)
        {
            var currentValue = grid.ReadValueAt(x, y);
            var newValue = currentValue + increment;
            if (newValue < 0)
                newValue = 0;
            grid.WriteValueAt(x, y, newValue);
        }
    }

    private class VoidCommand() : Command(0, 0, 0, 0)
    {
        protected override void Change(Grid<int> grid, int x, int y)
        {
        }
    }

    public abstract class Command
    {
        private readonly int _xa;
        private readonly int _ya;
        private readonly int _xb;
        private readonly int _yb;

        protected Command(string s) => (_xa, _ya, _xb, _yb) = Numbers.IntsFromString(s);

        protected Command(int xa, int ya, int xb, int yb)
        {
            _xa = xa;
            _ya = ya;
            _xb = xb;
            _yb = yb;
        }

        public void Move(Grid<int> grid)
        {
            for (var x = _xa; x <= _xb; x++)
            {
                for (var y = _ya; y <= _yb; y++)
                {
                    Change(grid, x, y);
                }
            }
        }

        protected abstract void Change(Grid<int> grid, int x, int y);
    }
}