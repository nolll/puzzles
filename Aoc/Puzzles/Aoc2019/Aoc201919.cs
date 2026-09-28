using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Tractor Beam")]
public class Aoc201919 : AocPuzzle
{
    [Puzzle("984c01d5977631fa8cd48a8fbd689c1c")]
    public int Part1(string input) => new TractorBeamComputer1(input, 50, 50).GetPullCount();

    [Puzzle("c22eb8f92f96b6e515142cffa3b161c0")]
    public int Part2(string input) => new TractorBeamComputer2(input, 50, 50).Find100By100Square().Checksum;
    
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
    
    public enum TractorBeamInputMode
    {
        X,
        Y
    }
}