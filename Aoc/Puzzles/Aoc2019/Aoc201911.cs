using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Space Police")]
public class Aoc201911 : AocPuzzle
{
    [Puzzle("450a7268b37892570104286b9fd8e5f2")]
    public int Part1(string input) => new PaintRobot(input).Paint(false).PaintedPanelCount;

    [Puzzle("f5a3ea8d16e26ffd7e4c01382dfcd31c")]
    public string Part2(string input)
    {
        var robot2 = new PaintRobot(input);
        var result2 = robot2.Paint(true);
        var printout = CleanPrintout(result2.Printout);
        return OcrSmallFont.ReadString(printout);
    }
    
    public class PaintRobot
    {
        private readonly string _program;
        private readonly Grid<int> _panels;
        private readonly Grid<int> _paintCounts;
        private PaintMode _mode;
        private IntCodeComputer? _computer;

        public PaintRobot(string program, int shipWidth = 100, int shipHeight = 100)
        {
            _program = program;
            _panels = new Grid<int>(shipWidth, shipHeight);
            _paintCounts = new Grid<int>(shipWidth, shipHeight);
        }

        public Result Paint(bool startOnWhitePanel)
        {
            _mode = PaintMode.Paint;

            if (startOnWhitePanel)
                PaintWhite();

            _computer = new IntCodeComputer(_program, ReadInput, WriteOutput);
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

        private bool WriteOutput(long output)
        {
            if (_mode == PaintMode.Paint)
            {
                Paint((int)output);
                _paintCounts.WriteValueAt(_panels.Coord, _paintCounts.ReadValue() + 1);
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

            return true;
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

    private string CleanPrintout(string s)
    {
        var rows = s.Split(LineBreaks.Single).ToList();
        var rowsWithOutput = new List<string>();

        foreach(var row in rows)
        {
            var chars = row.Trim().ToCharArray();
            if(chars.Any(o => o != '0'))
            {
                rowsWithOutput.Add(row);
            }
        }

        var firstCharPos = rowsWithOutput.Min(o => o.IndexOf('1'));
        var lastCharPos = rowsWithOutput.Max(o => o.LastIndexOf('1'));
        var length = lastCharPos - firstCharPos + 1;
        var printoutRows = rowsWithOutput.Select(o => o.Substring(firstCharPos, length));
        return string.Join(LineBreaks.Single, printoutRows).Replace('0', '.').Replace('1', '#');
    }
    
    public enum PaintMode
    {
        Paint,
        Move
    }
}