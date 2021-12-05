namespace ConsoleApp.Puzzles.Year2016.Day08
{
    public class ScreenSimulatorResult
    {
        public int PixelCount { get; }
        public string PrintOut { get; }

        public ScreenSimulatorResult(int pixelCount, string printOut)
        {
            PixelCount = pixelCount;
            PrintOut = printOut;
        }
    }
}