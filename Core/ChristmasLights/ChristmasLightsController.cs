using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ChristmasLights
{
    public class ChristmasLightsController
    {
        private readonly Matrix<int> _matrix;

        public int LitCount => _matrix.Values.Count(o => o == 1);

        public ChristmasLightsController(int size = 1000)
        {
            _matrix = new Matrix<int>(size, size);
        }

        public void RunCommands(string input)
        {
            var commands = ParseCommands(input);
            foreach (var command in commands)
            {
                command.Move(_matrix);
            }
        }

        private IList<Command> ParseCommands(string input)
        {
            var strings = input.Split('\n').Select(o => o.Trim());
            return strings.Select(CreateCommand).ToList();
        }

        private Command CreateCommand(string s)
        {
            if (s.StartsWith("turn on"))
                return new TurnOnCommand(s);
            if (s.StartsWith("turn off"))
                return new TurnOffCommand(s);
            if (s.StartsWith("toggle"))
                return new ToggleCommand(s);
            return new VoidCommand();
        }

        private abstract class Command
        {
            private readonly int _xa;
            private readonly int _ya;
            private readonly int _xb;
            private readonly int _yb;

            protected Command(string s)
            {
                var strCoords = s.Trim().Split(" through ");
                var a = strCoords[0].Split(',');
                var b = strCoords[1].Split(',');
                _xa = int.Parse(a[0]);
                _ya = int.Parse(a[1]);
                _xb = int.Parse(b[0]);
                _yb = int.Parse(b[1]);
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

            protected override void Change(Matrix<int> matrix, int x, int y)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(1);
            }
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

            protected override void Change(Matrix<int> matrix, int x, int y)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(0);
            }
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
                matrix.MoveTo(x, y);
                var currentValue = matrix.ReadValue();
                var newValue = currentValue == 0 ? 1 : 0;
                matrix.WriteValue(newValue);
            }
        }

        private class VoidCommand : Command
        {
            public VoidCommand()
                : base(0, 0, 0, 0)
            {
            }

            protected override void Change(Matrix<int> matrix, int x, int y)
            {
            }
        }

        public void TurnOn(int xa, int ya, int xb, int yb)
        {
            new TurnOnCommand(xa, ya, xb, yb).Move(_matrix);
        }

        public void TurnOff(int xa, int ya, int xb, int yb)
        {
            new TurnOffCommand(xa, ya, xb, yb).Move(_matrix);
        }

        public void Toggle(int xa, int ya, int xb, int yb)
        {
            new ToggleCommand(xa, ya, xb, yb).Move(_matrix);
        }
    }
}