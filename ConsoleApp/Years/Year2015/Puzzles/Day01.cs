using Core.Floors;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day01 : Day2015
    {
        private readonly FloorNavigator _navigator;

        public Day01() : base(1)
        {
            _navigator = new FloorNavigator(FileInput);
        }

        protected override void RunDay()
        {
        }

        public override PuzzleResult RunPart1()
        {
            var message = $"Final floor: {_navigator.DestinationFloor}";
            return new PuzzleResult(message);
        }

        public override PuzzleResult RunPart2()
        {
            var message = $"First basement instruction: {_navigator.FirstBasementInstruction}";
            return new PuzzleResult(message);
        }
    }
}