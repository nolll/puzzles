using Core.Platform;

namespace Core.Puzzles.Year2015.Day06
{
    public class Year2015Day06 : Year2015Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var controller = new ChristmasLightsController();
            controller.RunCommands(FileInput, false);
            return new PuzzleResult(controller.LitCount, 377_891);
        }

        public override PuzzleResult RunPart2()
        {
            var controller = new ChristmasLightsController();
            controller.RunCommands(FileInput, true);
            return new PuzzleResult(controller.TotalBrightness, 14_110_788);
        }
    }
}