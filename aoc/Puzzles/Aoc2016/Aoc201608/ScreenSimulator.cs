using Puzzles.common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.common.Ocr;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201608;

public class ScreenSimulator
{
    private readonly Matrix<char> _screen;

    public ScreenSimulator(int width, int height)
    {
        _screen = new Matrix<char>(width, height, '.');
    }

    public ScreenSimulatorResult Run(string input)
    {
        var instructions = StringReader.ReadLines(input).Select(CreateInstruction).ToList();
        foreach (var instruction in instructions)
        {
            instruction.Execute();
        }

        var pixelCount = _screen.Values.Count(o => o == '#');
        var printOut = _screen.Print();
        var letters = OcrSmallFont.ReadString(printOut);
        return new ScreenSimulatorResult(pixelCount, printOut, letters);
    }

    private IScreenSimulatorInstruction CreateInstruction(string s)
    {
        var parts = s.Split(' ');
        if (parts[0] == "rect")
        {
            var sizeParts = parts[1].Split('x');
            var w = int.Parse(sizeParts[0]);
            var h = int.Parse(sizeParts[1]);
            return new ScreenSimulatorRectInstruction(_screen, w, h);
        }

        if (parts[0] == "rotate")
        {
            var steps = int.Parse(parts[4]);
            if (parts[1] == "row")
            {
                var row = int.Parse(parts[2].Split('=')[1]);
                return new ScreenSimulatorRotateRowInstruction(_screen, row, steps);
            }

            if (parts[1] == "column")
            {
                var col = int.Parse(parts[2].Split('=')[1]);
                return new ScreenSimulatorRotateColumnInstruction(_screen, col, steps);
            }
        }

        return new ScreenSimulatorVoidInstruction();
    }
}