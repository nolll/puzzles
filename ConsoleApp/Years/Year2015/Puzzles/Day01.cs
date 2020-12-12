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

            return new PuzzleResult(
                $"Final floor: {navigator.DestinationFloor}", 
                navigator.DestinationFloor, 
                138);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new FloorNavigator(FileInput);
            
            return new PuzzleResult(
                $"First basement instruction: {navigator.FirstBasementInstruction}", 
                navigator.FirstBasementInstruction, 
                1771);
        }
    }
}