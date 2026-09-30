using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Two-Factor Authentication")]
public class Aoc201608 : AocPuzzle
{
    private const int Width = 50;
    private const int Height = 6;
    
    [Puzzle("40e526702a7945ea86fbcec32dd72a4d")]
    public int Part1(string input) => SolvePart1(input, Width, Height);

    [Puzzle("5eb2504556c7376b34258205d7ef40f2")]
    public string Part2(string input) => SolvePart2(input, Width, Height);

    public int SolvePart1(string input, int width, int height) => 
        GetScreen(input, width, height).Values.Count(o => o == '#');

    private string SolvePart2(string input, int width, int height) => 
        OcrSmallFont.ReadString(GetScreen(input, width, height).Print());

    private static Grid<char> GetScreen(string input, int width, int height)
    {
        var screen = new Grid<char>(width, height, '.');
        var instructions = input.Split(LineBreaks.Single).Select(o => CreateInstruction(o, screen)).ToList();
        foreach (var instruction in instructions)
        {
            instruction.Execute();
        }

        return screen;
    }

    private static IScreenSimulatorInstruction CreateInstruction(string s, Grid<char> screen)
    {
        var parts = s.Split(' ');
        if (parts[0] == "rect")
        {
            var (sw, sh) = parts[1].Split('x');
            var w = int.Parse(sw);
            var h = int.Parse(sh);
            return new ScreenSimulatorRectInstruction(screen, w, h);
        }

        if (parts[0] == "rotate")
        {
            var steps = int.Parse(parts[4]);
            if (parts[1] == "row")
            {
                var row = int.Parse(parts[2].Split('=')[1]);
                return new ScreenSimulatorRotateRowInstruction(screen, row, steps);
            }

            if (parts[1] == "column")
            {
                var col = int.Parse(parts[2].Split('=')[1]);
                return new ScreenSimulatorRotateColumnInstruction(screen, col, steps);
            }
        }

        return new ScreenSimulatorVoidInstruction();
    }

    private interface IScreenSimulatorInstruction
    {
        void Execute();
    }

    private class ScreenSimulatorRectInstruction(Grid<char> grid, int width, int height) : IScreenSimulatorInstruction
    {
        public void Execute()
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    grid.WriteValueAt(x, y, '#');
                }
            }
        }
    }

    private class ScreenSimulatorRotateColumnInstruction(Grid<char> grid, int column, int steps) : IScreenSimulatorInstruction
    {
        public void Execute()
        {
            var x = column;
            var newCol = new char[grid.Height];
            for (var y = 0; y < grid.Height; y++)
            {
                var newy = y + steps;
                if (newy < 0)
                    newy += grid.Height;

                if (newy >= grid.Height)
                    newy -= grid.Height;

                newCol[newy] = grid.ReadValueAt(x, y);
            }

            for (var y = 0; y < grid.Height; y++)
            {
                grid.WriteValueAt(x, y, newCol[y]);
            }
        }
    }

    private class ScreenSimulatorRotateRowInstruction(Grid<char> grid, int row, int steps) : IScreenSimulatorInstruction
    {
        public void Execute()
        {
            var y = row;
            var newRow = new char[grid.Width];
            for (var x = 0; x < grid.Width; x++)
            {
                var newX = x + steps;
                if (newX < 0)
                    newX += grid.Width;

                if (newX >= grid.Width)
                    newX -= grid.Width;

                newRow[newX] = grid.ReadValueAt(x, y);
            }

            for (var x = 0; x < grid.Width; x++)
            {
                grid.WriteValueAt(x, y, newRow[x]);
            }
        }
    }

    private class ScreenSimulatorVoidInstruction : IScreenSimulatorInstruction
    {
        public void Execute()
        {
        }
    }
}