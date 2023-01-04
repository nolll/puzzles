using System.Collections.Generic;
using System.Linq;
using Core.Common.Computers.IntCode;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day11;

public class PaintRobot
{
    private readonly string _program;
    private readonly IMatrix<int> _panels;
    private readonly IMatrix<int> _paintCounts;
    private PaintMode _mode;
    private ComputerInterface _computer;

    public PaintRobot(string program, int shipWidth = 100, int shipHeight = 100)
    {
        _program = program;
        _panels = new QuickMatrix<int>(shipWidth, shipHeight);
        _paintCounts = new QuickMatrix<int>(shipWidth, shipHeight);
    }

    public Result Paint(bool startOnWhitePanel)
    {
        _mode = PaintMode.Paint;

        if (startOnWhitePanel)
            PaintWhite();

        _computer = new ComputerInterface(_program, ReadInput, WriteOutput);
        _computer.Start();

        return new Result(PaintedPanelsCount, _panels.Print());
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
            _paintCounts.WriteValueAt(_panels.Address, _paintCounts.ReadValue() + 1);
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
        public string Printout { get; }

        public Result(int paintedPanelCount, string printout)
        {
            PaintedPanelCount = paintedPanelCount;
            Printout = printout;
        }
    }
}