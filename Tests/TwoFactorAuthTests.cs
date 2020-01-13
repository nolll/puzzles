using System.Linq;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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
        private Matrix<char> _screen;

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
            return null;
        }
    }

    public interface IScreenSimulatorInstruction
    {
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