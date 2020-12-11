using Core.Floors;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day01 : Day2015
    {
        public Day01() : base(1)
        {
            
        }

        public override PuzzleResult RunPart1()
        {
            var navigator = new FloorNavigator(FileInput);
            var message = $"Final floor: {navigator.DestinationFloor}";
            return new PuzzleResult(message);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new FloorNavigator(FileInput);
            var message = $"First basement instruction: {navigator.FirstBasementInstruction}";
            return new PuzzleResult(message);
        }
    }
}