using Core.SeriesOfTubes;

namespace ConsoleApp.Puzzles.Year2017.Puzzles
{
    public class Year2017Day19 : Year2017Day
    {
        public override int Day => 19;

        public override PuzzleResult RunPart1()
        {
            var finder = new TubeRouteFinder(FileInput);
            finder.FindRoute();
            return new PuzzleResult(finder.Route, "PVBSCMEQHY");
        }

        public override PuzzleResult RunPart2()
        {
            var finder = new TubeRouteFinder(FileInput);
            finder.FindRoute();
            return new PuzzleResult(finder.StepCount, 17_736);
        }
    }
}