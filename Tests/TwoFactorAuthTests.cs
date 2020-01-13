using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class TwoFactorAuthTests
    {
        [Test]
        public void PixelCount()
        {
            const string input = @"
rect 3x2
rotate column x=1 by 1
rotate row y=0 by 4
rotate column x=1 by 1
";

            var simulator = new ScreenSimulator(7, 3);
            var result = simulator.Run(input);

            Assert.That(result.PixelCount, Is.EqualTo(6));
        }
    }

    public class ScreenSimulator
    {
        private readonly Matrix<char> _screen;

        public ScreenSimulator(int width, int height)
        {
            _screen = new Matrix<char>(width, height, ' ');
        }

        public ScreenSimulatorResult Run(string input)
        {
            var instructions = PuzzleInputReader.Read(input).Select(CreateInstruction).ToList();
            return new ScreenSimulatorResult(0);
        }

        private IScreenSimulatorInstruction CreateInstruction(string s)
        {
            var parts = s.Split(' ');
            if (parts[0] == "rect")
            {
                return new ScreenSimulatorRectInstruction(_screen, 0, 0);
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

    public class ScreenSimulatorRotateRowInstruction : IScreenSimulatorInstruction
    {
        private readonly Matrix<char> _matrix;
        private readonly int _row;
        private readonly int _steps;

        public ScreenSimulatorRotateRowInstruction(Matrix<char> matrix, int row, int steps)
        {
            _matrix = matrix;
            _row = row;
            _steps = steps;
        }

        public void Execute()
        {

        }
    }

    public class ScreenSimulatorRotateColumnInstruction : IScreenSimulatorInstruction
    {
        private readonly Matrix<char> _matrix;
        private readonly int _column;
        private readonly int _steps;

        public ScreenSimulatorRotateColumnInstruction(Matrix<char> matrix, int column, int steps)
        {
            _matrix = matrix;
            _column = column;
            _steps = steps;
        }

        public void Execute()
        {

        }
    }

    public class ScreenSimulatorRectInstruction : IScreenSimulatorInstruction
    {
        private readonly Matrix<char> _matrix;
        private readonly int _width;
        private readonly int _height;

        public ScreenSimulatorRectInstruction(Matrix<char> matrix, int width, int height)
        {
            _matrix = matrix;
            _width = width;
            _height = height;
        }

        public void Execute()
        {
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _matrix.MoveTo(x, y);
                    _matrix.WriteValue('#');
                }
            }
        }
    }

    public class ScreenSimulatorVoidInstruction : IScreenSimulatorInstruction
    {
        public void Execute()
        {
        }
    }

    public interface IScreenSimulatorInstruction
    {
        void Execute();
    }

    public class ScreenSimulatorResult
    {
        public int PixelCount { get; }

        public ScreenSimulatorResult(int pixelCount)
        {
            PixelCount = pixelCount;
        }
    }
}