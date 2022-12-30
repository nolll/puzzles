using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Ocr;
using Core.Common.Strings;

namespace Core.Puzzles.Year2016.Day08;

public class ScreenSimulator
{
    private readonly IMatrix<char> _screen;

    public ScreenSimulator(int width, int height)
    {
        _screen = new QuickMatrix<char>(width, height, '.');
    }

    public ScreenSimulatorResult Run(string input)
    {
        var instructions = PuzzleInputReader.ReadLines(input).Select(CreateInstruction).ToList();
        foreach (var instruction in instructions)
        {
            instruction.Execute();
        }

        var pixelCount = _screen.Values.Count(o => o == '#');
        var printOut = _screen.Print();
        var letters = OcrReader.ReadString(printOut);
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