using Pzl.Common;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201911;

[Name("Space Police")]
public class Aoc201911 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var robot1 = new PaintRobot(input);
        var result1 = robot1.Paint(false);

        return new PuzzleResult(result1.PaintedPanelCount, "450a7268b37892570104286b9fd8e5f2");
    }

    public PuzzleResult RunPart2(string input)
    {
        var robot2 = new PaintRobot(input);
        var result2 = robot2.Paint(true);
        var printout = CleanPrintout(result2.Printout);
        var letters = OcrSmallFont.ReadString(printout);

        return new PuzzleResult(letters, "f5a3ea8d16e26ffd7e4c01382dfcd31c");
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
}