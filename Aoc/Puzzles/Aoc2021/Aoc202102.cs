using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Dive!")]
public class Aoc202102 : AocPuzzle
{
    [Puzzle("9d9dec9baf0fe61bbb7a9e95cc1ae2de")]
    public long Part1(string input)
    {
        var control = new SubmarineControl(input, false);
        control.Move();
            
        return control.Result;
    }

    [Puzzle("6b29326368c507ef0dbbe41523850cd2")]
    public long Part2(string input)
    {
        var control = new SubmarineControl(input, true);
        control.Move();

        return control.Result;
    }
    
    public class SubmarineControl(string input, bool useAim)
    {
        private readonly IList<string> _lines = input.Split(LineBreaks.Single);
        private long _x;
        private long _y;
        private long _aim;
        public long Result { get; private set; }

        public void Move()
        {
            foreach (var line in _lines)
            {
                var parts = line.Split(' ');
                var action = parts[0];
                var value = long.Parse(parts[1]);

                if (useAim)
                    MoveWithAim(action, value);
                else
                    MoveWithoutAim(action, value);
            }

            Result = _x * _y;
        }

        private void MoveWithoutAim(string action, long value)
        {
            if (action == "forward")
                _x += value;

            if (action == "down")
                _y += value;

            if (action == "up")
                _y -= value;
        }

        private void MoveWithAim(string action, long value)
        {
            if (action == "forward")
            {
                _x += value;
                _y += _aim * value;
            }

            if (action == "down")
                _aim += value;

            if (action == "up")
                _aim -= value;
        }
    }
}