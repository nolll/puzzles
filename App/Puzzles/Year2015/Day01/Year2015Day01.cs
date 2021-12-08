using App.Platform;

namespace App.Puzzles.Year2015.Day01
{
    public class Year2015Day01 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var navigator = new FloorNavigator(FileInput);

            return new PuzzleResult(navigator.DestinationFloor, 138);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new FloorNavigator(FileInput);
            
            return new PuzzleResult(navigator.FirstBasementInstruction, 1771);
        }
    }
}