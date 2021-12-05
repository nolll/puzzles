namespace ConsoleApp.Puzzles.Year2021.Puzzles.Day03
{
    public class Year2021Day03 : Year2021Day
    {
        public override int Day => 3;

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