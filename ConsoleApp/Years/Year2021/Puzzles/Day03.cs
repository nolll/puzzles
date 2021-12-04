using Core.SubmarineDiagnostics;

namespace ConsoleApp.Years.Year2021.Puzzles
{
    public class Day03 : Day2021
    {
        public Day03() : base(3)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var diagnostics = new BinaryDiagnostics();
            var result = diagnostics.GetFuelConsumption(FileInput);
            
            return new PuzzleResult(result, 845186);
        }

        public override PuzzleResult RunPart2()
        {
            var diagnostics = new BinaryDiagnostics();
            var result = diagnostics.GetLifeSupportRating(FileInput);

            return new PuzzleResult(result, 4636702);
        }
    }
}