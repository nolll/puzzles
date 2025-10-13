using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201506;

public class ChristmasLightsController(int size = 1000)
{
    private readonly Matrix<int> _matrix = new(size, size);

    public int LitCount => _matrix.Values.Count(o => o > 0);
    public int TotalBrightness => _matrix.Values.Sum();

    public void RunCommands(string input, bool useBrightness)
    {
        var commands = ParseCommands(input, useBrightness);
        foreach (var command in commands)
        {
            command.Move(_matrix);
        }
    }

    private static IEnumerable<Command> ParseCommands(string input, bool useBrightness) => 
        StringReader.ReadLines(input).Select(o => CreateCommand(o, useBrightness)).ToList();

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

    private class TurnOnCommand : Command
    {
        public TurnOnCommand(string s)
            : base(s.Replace("turn on", ""))
        {
        }

        public TurnOnCommand(int xa, int ya, int xb, int yb)
            : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Matrix<int> matrix, int x, int y) => matrix.WriteValueAt(x, y, 1);
    }

    private class TurnOffCommand : Command
    {
        public TurnOffCommand(string s)
            : base(s.Replace("turn off", ""))
        {
        }

        public TurnOffCommand(int xa, int ya, int xb, int yb)
            : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Matrix<int> matrix, int x, int y) => matrix.WriteValueAt(x, y, 0);
    }

    private class ToggleCommand : Command
    {
        public ToggleCommand(string s)
            : base(s.Replace("toggle", ""))
        {
        }

        public ToggleCommand(int xa, int ya, int xb, int yb)
            : base(xa, ya, xb, yb)
        {
        }

        protected override void Change(Matrix<int> matrix, int x, int y)
        {
            var newValue = matrix.ReadValueAt(x, y) == 0 ? 1 : 0;
            matrix.WriteValueAt(x, y, newValue);
        }
    }

    private class IncreaseCommand(string s, int increment) : Command(s)
    {
        protected override void Change(Matrix<int> matrix, int x, int y)
        {
            var currentValue = matrix.ReadValueAt(x, y);
            var newValue = currentValue + increment;
            if (newValue < 0)
                newValue = 0;
            matrix.WriteValueAt(x, y, newValue);
        }
    }

    private class VoidCommand() : Command(0, 0, 0, 0)
    {
        protected override void Change(Matrix<int> matrix, int x, int y) {}
    }
    
    private abstract class Command
    {
        private readonly int _xa;
        private readonly int _ya;
        private readonly int _xb;
        private readonly int _yb;

        protected Command(string s)
        {
            var ints = Numbers.IntsFromString(s);
            _xa = ints[0];
            _ya = ints[1];
            _xb = ints[2];
            _yb = ints[3];
        }

        protected Command(int xa, int ya, int xb, int yb)
        {
            _xa = xa;
            _ya = ya;
            _xb = xb;
            _yb = yb;
        }

        public void Move(Matrix<int> matrix)
        {
            for (var x = _xa; x <= _xb; x++)
            {
                for (var y = _ya; y <= _yb; y++)
                {
                    Change(matrix, x, y);
                }
            }
        }

        protected abstract void Change(Matrix<int> matrix, int x, int y);
    }

    public void TurnOn(int xa, int ya, int xb, int yb) => new TurnOnCommand(xa, ya, xb, yb).Move(_matrix);
    public void TurnOff(int xa, int ya, int xb, int yb) => new TurnOffCommand(xa, ya, xb, yb).Move(_matrix);
    public void Toggle(int xa, int ya, int xb, int yb) => new ToggleCommand(xa, ya, xb, yb).Move(_matrix);
}