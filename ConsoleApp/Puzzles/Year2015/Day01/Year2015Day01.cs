namespace ConsoleApp.Puzzles.Year2015.Day01
{
    public class Year2015Day01 : Year2015Day
    {
        public override int Day => 1;

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