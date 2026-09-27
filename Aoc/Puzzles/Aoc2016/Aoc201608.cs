using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Two-Factor Authentication")]
public class Aoc201608 : AocPuzzle
{
    [Puzzle("40e526702a7945ea86fbcec32dd72a4d")]
    public int Part1(string input) => new ScreenSimulator(50, 6).Run(input).PixelCount;

    [Puzzle("5eb2504556c7376b34258205d7ef40f2")]
    public string Part2(string input) => new ScreenSimulator(50, 6).Run(input).Letters;
    
    public interface IScreenSimulatorInstruction
    {
        void Execute();
    }
    
    public class ScreenSimulator
    {
        private readonly Grid<char> _screen;

        public ScreenSimulator(int width, int height)
        {
            _screen = new Grid<char>(width, height, '.');
        }

        public ScreenSimulatorResult Run(string input)
        {
            var instructions = input.Split(LineBreaks.Single).Select(CreateInstruction).ToList();
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
    
    public class ScreenSimulatorRectInstruction : IScreenSimulatorInstruction
    {
        private readonly Grid<char> _grid;
        private readonly int _width;
        private readonly int _height;

        public ScreenSimulatorRectInstruction(Grid<char> grid, int width, int height)
        {
            _grid = grid;
            _width = width;
            _height = height;
        }

        public void Execute()
        {
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _grid.WriteValueAt(x, y, '#');
                }
            }
        }
    }
    
    public class ScreenSimulatorResult
    {
        public int PixelCount { get; }
        public string PrintOut { get; }
        public string Letters { get; }

        public ScreenSimulatorResult(int pixelCount, string printOut, string letters)
        {
            PixelCount = pixelCount;
            PrintOut = printOut;
            Letters = letters;
        }
    }
    
    public class ScreenSimulatorRotateColumnInstruction : IScreenSimulatorInstruction
    {
        private readonly Grid<char> _grid;
        private readonly int _column;
        private readonly int _steps;

        public ScreenSimulatorRotateColumnInstruction(Grid<char> grid, int column, int steps)
        {
            _grid = grid;
            _column = column;
            _steps = steps;
        }

        public void Execute()
        {
            var x = _column;
            var newCol = new char[_grid.Height];
            for (var y = 0; y < _grid.Height; y++)
            {
                var newy = y + _steps;
                if (newy < 0)
                    newy += _grid.Height;

                if (newy >= _grid.Height)
                    newy -= _grid.Height;

                newCol[newy] = _grid.ReadValueAt(x, y);
            }

            for (var y = 0; y < _grid.Height; y++)
            {
                _grid.WriteValueAt(x, y, newCol[y]);
            }
        }
    }
    
    public class ScreenSimulatorRotateRowInstruction : IScreenSimulatorInstruction
    {
        private readonly Grid<char> _grid;
        private readonly int _row;
        private readonly int _steps;

        public ScreenSimulatorRotateRowInstruction(Grid<char> grid, int row, int steps)
        {
            _grid = grid;
            _row = row;
            _steps = steps;
        }

        public void Execute()
        {
            var y = _row;
            var newRow = new char[_grid.Width];
            for (var x = 0; x < _grid.Width; x++)
            {
                var newX = x + _steps;
                if (newX < 0)
                    newX += _grid.Width;

                if (newX >= _grid.Width)
                    newX -= _grid.Width;

                newRow[newX] = _grid.ReadValueAt(x, y);
            }

            for (var x = 0; x < _grid.Width; x++)
            {
                _grid.WriteValueAt(x, y, newRow[x]);
            }
        }
    }
    
    public class ScreenSimulatorVoidInstruction : IScreenSimulatorInstruction
    {
        public void Execute()
        {
        }
    }
}