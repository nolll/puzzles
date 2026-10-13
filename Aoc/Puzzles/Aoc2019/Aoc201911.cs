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
    public int Part1(string input)
    {
        var (paintCounts, _) = Paint(input, false);
        return paintCounts.Values.Count(o => o > 0);
    }

    [Puzzle("f5a3ea8d16e26ffd7e4c01382dfcd31c")]
    public string Part2(string input)
    {
        var (_, panels) = Paint(input, true);
        var printout = CleanPrintout(panels.Print());
        return OcrSmallFont.ReadString(printout);
    }

    private static (Grid<int> paintCounts, Grid<int> panels) Paint(string program, bool startOnWhitePanel, int shipWidth = 100, int shipHeight = 100)
    {
        var mode = PaintMode.Paint;
        var panels = new Grid<int>(shipWidth, shipHeight);
        var paintCounts = new Grid<int>(shipWidth, shipHeight);

        if (startOnWhitePanel)
            PaintWhite(panels);

        var computer = new IntCodeComputer(program, () => panels.ReadValue(), output =>
        {
            if (mode == PaintMode.Paint)
            {
                Paint(panels, (int)output);
                paintCounts.WriteValueAt(panels.Coord, paintCounts.ReadValue() + 1);
                mode = PaintMode.Move;
            }
            else
            {
                if (output == 0)
                    panels.TurnLeft();
                if (output == 1)
                    panels.TurnRight();
                panels.MoveForward();
                mode = PaintMode.Paint;
            }

            return true;
        });

        computer.Start();

        return (paintCounts, panels);
    }

    private static void Paint(Grid<int> panels, int color) => panels.WriteValue(color);
    private static void PaintWhite(Grid<int> panels) => panels.WriteValue(1);

    private static string CleanPrintout(string s)
    {
        var rows = s.Split(LineBreaks.Single).ToList();
        var rowsWithOutput = rows.Where(row => row.ToCharArray().Any(o => o != '0')).ToList();
        var firstCharPos = rowsWithOutput.Min(o => o.IndexOf('1'));
        var lastCharPos = rowsWithOutput.Max(o => o.LastIndexOf('1'));
        var length = lastCharPos - firstCharPos + 1;
        var printoutRows = rowsWithOutput.Select(o => o.Substring(firstCharPos, length));
        return string.Join(LineBreaks.Single, printoutRows).Replace('0', '.').Replace('1', '#');
    }

    private enum PaintMode
    {
        Paint,
        Move
    }
}