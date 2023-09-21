using Aoc.Common.Computers.IntCode;

namespace Aoc.Puzzles.Year2019.Day19;

public class TractorBeamComputer2
{
    private readonly IntCodeComputer _computer;
    private int _x = 0;
    private int _y = 0;
    private int _tempX = 0;
    private int _tempY = 0;
    private int _output = 0;
    private TractorBeamInputMode _mode = TractorBeamInputMode.X;

    public TractorBeamComputer2(string program, int width, int height)
    {
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
    }

    public Result Find100By100Square()
    {
        _x = 0;
        _y = 100;
        while (true)
        {
            _tempX = _x;
            _tempY = _y;
            _computer.Start();
            if (_output == 1)
            {
                _tempX = _x + 99;
                _tempY = _y - 99;
                _computer.Start();
                if (_output == 1)
                {
                    break;
                }

                _y += 1;
            }

            _x += 1;
        }
        return new Result(_x, _y - 99);
    }

    public class Result
    {
        public int Checksum { get; }

        public Result(int x, int y)
        {
            Checksum = x * 10000 + y;
        }
    }

    private long ReadInput()
    {
        if (_mode == TractorBeamInputMode.X)
        {
            _mode = TractorBeamInputMode.Y;
            return _tempX;
        }
        else
        {
            _mode = TractorBeamInputMode.X;
            return _tempY;
        }
    }

    private bool WriteOutput(long output)
    {
        _output = (int)output;
        return true;
    }
}