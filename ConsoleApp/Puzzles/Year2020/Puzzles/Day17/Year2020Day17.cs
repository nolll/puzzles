using Core.ExperimentalEnergySource;

namespace ConsoleApp.Puzzles.Year2020.Puzzles.Day17
{
    public class Year2020Day17 : Year2020Day
    {
        public override int Day => 17;

        public override PuzzleResult RunPart1()
        {
            var cube = new ConwayCube();
            var result = cube.Boot3D(FileInput, 6);
            return new PuzzleResult(result, 382);
        }

        public override PuzzleResult RunPart2()
        {
            var cube = new ConwayCube();
            var result = cube.Boot4D(FileInput, 6);
            return new PuzzleResult(result, 2552);
        }
    }
}