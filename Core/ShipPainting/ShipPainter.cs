using Core.Computer;
using Core.Tools;

namespace Core.ShipPainting
{
    public class ShipPainter
    {
        private readonly string _program;
        private int _lastOutput;
        private readonly Matrix _panels;
        private PaintMode _mode;

        public ShipPainter(string program, int shipSize = 100)
        {
            _program = program;
            var startPoint = shipSize / 2 - 1;
            _panels = new Matrix(shipSize);
            _panels.MoveTo(startPoint, startPoint);
            _mode = PaintMode.Paint;
        }

        public Result Paint()
        {
            var computer = new ComputerInterface(_program, ReadInput, WriteOutput);
            computer.Start();

            return new Result(_lastOutput);
        }

        private long ReadInput()
        {
            return _panels.ReadValue();;
        }

        private void WriteOutput(long output)
        {
            if (_mode == PaintMode.Paint)
            {
                _panels.WriteValue((int)output);
                _mode = PaintMode.Move;
            }
            else
            {
                if (output == 0)
                    _panels.TurnLeft();
                if (output == 1)
                    _panels.TurnRight();
                _panels.MoveForward();
            }
        }

        public class Result
        {
            public int PaintedPanels { get; }

            public Result(int paintedPanels)
            {
                PaintedPanels = paintedPanels;
            }
        }
    }
}