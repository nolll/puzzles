using Puzzles.common.Computers.IntCode;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201919;

public enum TractorBeamInputMode
{
    X,
    Y
}

public class TractorBeamComputer1
{
    private readonly int _width;
    private readonly int _height;
    private readonly IntCodeComputer _computer;
    private int _x = 0;
    private int _y = 0;
    private int _count = 0;
    private TractorBeamInputMode _mode = TractorBeamInputMode.X;

    public TractorBeamComputer1(string program, int width, int height)
    {
        _width = width;
        _height = height;
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
    }

    public int GetPullCount()
    {
        while (_x < _width && _y < _height)
        {
            _computer.Start();
        }

        return _count;
    }

    private long ReadInput()
    {
        if (_mode == TractorBeamInputMode.X)
        {
            var returnValue = _x;
            _mode = TractorBeamInputMode.Y;
            _x += 1;
            if (_x > _width - 1)
            {
                _x = 0;
                _y += 1;
            }
            return returnValue;
        }
        else
        {
            var returnValue = _y;
            _mode = TractorBeamInputMode.X;

            return returnValue;
        }
    }

    private bool WriteOutput(long output)
    {
        if (output == 1)
            _count += 1;

        return true;
    }
}