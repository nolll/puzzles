using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2019.Day06
{
    public class Year2019Day06 : Year2019Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var calculator = new OrbitCalculator(FileInput);
            var orbitCount = calculator.GetOrbitCount();
            return new PuzzleResult(orbitCount, 278_744);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new OrbitCalculator(FileInput);
            var distance = calculator.GetSantaDistance();
            return new PuzzleResult(distance, 475);
        }
    }
}