using Core.Tools;

namespace ConsoleApp.Years.Year2016.Puzzles.Day08
{
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
}