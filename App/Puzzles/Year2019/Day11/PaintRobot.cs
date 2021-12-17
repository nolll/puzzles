using System.Collections.Generic;
using System.Linq;
using App.Common.Computers.IntCode;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2019.Day11;

public class PaintRobot
{
    private readonly string _program;
    private readonly int _shipWidth;
    private readonly int _shipHeight;
    private readonly Matrix<int> _panels;
    private readonly Matrix<int> _paintCounts;
    private PaintMode _mode;
    private ComputerInterface _computer;

    public PaintRobot(string program, int shipWidth = 100, int shipHeight = 100)
    {
        _program = program;
        _shipWidth = shipWidth;
        _shipHeight = shipHeight;
        _panels = new Matrix<int>(shipWidth, shipHeight);
        _paintCounts = new Matrix<int>(shipWidth, shipHeight);
    }

    public Result Paint(bool startOnWhitePanel)
    {
        var startX = _shipWidth / 2;
        var startY = _shipHeight / 2;
        _panels.MoveTo(startX, startY);
        _mode = PaintMode.Paint;

        if (startOnWhitePanel)
            PaintWhite();

        _computer = new ComputerInterface(_program, ReadInput, WriteOutput);
        _computer.Start();

        return new Result(PaintedPanelsCount, _panels.Address.X, _panels.Address.Y, _panels.Print(false, false));
    }

    private IList<int> PaintedPanels => _paintCounts.Values.Where(o => o > 0).ToList();
    private int PaintedPanelsCount => PaintedPanels.Count;

    private long ReadInput()
    {
        var value = _panels.ReadValue();
        return value;
    }

    private void Paint(int color)
    {
        _panels.WriteValue(color);
    }

    private void PaintWhite()
    {
        _panels.WriteValue(1);
    }

    private void WriteOutput(long output)
    {
        if (_mode == PaintMode.Paint)
        {
            Paint((int)output);
            _paintCounts.MoveTo(_panels.Address);
            _paintCounts.WriteValue(_paintCounts.ReadValue() + 1);
            _mode = PaintMode.Move;
        }
        else
        {
            if (output == 0)
                _panels.TurnLeft();
            if (output == 1)
                _panels.TurnRight();
            _panels.MoveForward();
            _mode = PaintMode.Paint;
        }
    }

    public class Result
    {
        public int PaintedPanelCount { get; }
        public int X { get; }
        public int Y { get; }
        public string Printout { get; }

        public Result(int paintedPanelCount, int x, int y, string printout)
        {
            PaintedPanelCount = paintedPanelCount;
            X = x;
            Y = y;
            Printout = printout;
        }
    }
}