using App.Platform;

namespace App.Puzzles.Year2018.Day20
{
    public class Year2018Day20 : Year2018Day
    {
        public override int Day => 20;

        public override PuzzleResult RunPart1()
        {
            var navigator = new RegularMapNavigator(FileInput);
            return new PuzzleResult(navigator.MostDoors, 4050);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new RegularMapNavigator(FileInput);
            return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, 8564);
        }
    }
}