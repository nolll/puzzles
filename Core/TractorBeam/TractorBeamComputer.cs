using System;
using System.Collections.Generic;
using Core.Computer;
using Core.Tools;

namespace Core.TractorBeam
{
    public enum TractorBeamInputMode
    {
        X,
        Y
    }

    public class TractorBeamComputer
    {
        private readonly int _width;
        private readonly int _height;
        private readonly ComputerInterface _computer;
        private readonly Matrix<char> _matrix;
        private int _x = 0;
        private int _y = 0;
        private int _count = 0;
        private TractorBeamInputMode _mode = TractorBeamInputMode.X;

        public TractorBeamComputer(string program, int width, int height)
        {
            _width = width;
            _height = height;
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
            _matrix = new Matrix<char>();
        }

        public Result Run()
        {
            while (_x < _width && _y < _height)
            {
                _computer.Start();
            }
            Console.WriteLine(_matrix.Print(false, false));
            var squareSize = 0;//GetSquareSize();
            return new Result(_count, squareSize);
        }

        private int GetSquareSize()
        {
            var x = _width - 1;
            var y = _height - 1;
            var v = '#';
            var width = 0;
            var height = 0;
            while (v == '#')
            {
                _matrix.MoveTo(x, y);
                v = _matrix.ReadValue();
                if (v == '#')
                    height++;
                y -= 1;
            }

            x = _x;
            y = _y;
            while (v == '#')
            {
                _matrix.MoveTo(x, y);
                v = _matrix.ReadValue();
                if (v == '#')
                    width++;
                x -= 1;
            }
            return Math.Min(width, height);
        }

        public class Result
        {
            public int Count { get; }
            public int SquareSize { get; }

            public Result(int count, int squareSize)
            {
                Count = count;
                SquareSize = squareSize;
            }
        }

        private long ReadInput()
        {
            _matrix.MoveTo(_x, _y);
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

        private void WriteOutput(long output)
        {
            if (output == 1)
                _count += 1;
            var c = output == 1 ? '#' : '.';
            _matrix.WriteValue(c);
        }
    }
}