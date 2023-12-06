using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202102;

public class SubmarineControl
{
    private readonly bool _useAim;
    private readonly IList<string> _lines;
    private long _x;
    private long _y;
    private long _aim;
    public long Result { get; private set; }

    public SubmarineControl(string input, bool useAim)
    {
        _useAim = useAim;
        _lines = StringReader.ReadLines(input);

        _x = 0;
        _y = 0;
        _aim = 0;
        Result = 0;
    }

    public void Move()
    {
        foreach (var line in _lines)
        {
            var parts = line.Split(' ');
            var action = parts[0];
            var value = long.Parse(parts[1]);

            if (_useAim)
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