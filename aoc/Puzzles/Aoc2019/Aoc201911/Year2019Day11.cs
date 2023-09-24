using System.Collections.Generic;
using System.Linq;
using Common.Ocr;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201911;

public class Year2019Day11 : AocPuzzle
{
    public override string Name => "Space Police";

    protected override PuzzleResult RunPart1()
    {
        var robot1 = new PaintRobot(InputFile);
        var result1 = robot1.Paint(false);

        return new PuzzleResult(result1.PaintedPanelCount, 1732);
    }

    protected override PuzzleResult RunPart2()
    {
        var robot2 = new PaintRobot(InputFile);
        var result2 = robot2.Paint(true);
        var printout = CleanPrintout(result2.Printout);
        var letters = OcrSmallFont.ReadString(printout);

        return new PuzzleResult(letters, "ABCLFUHJ");
    }

    private string CleanPrintout(string s)
    {
        var rows = s.Split("\r\n").ToList();
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
        return string.Join("\r\n", printoutRows).Replace('0', '.').Replace('1', '#');
    }
}