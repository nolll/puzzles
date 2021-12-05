using Core.PresentDelivery;

namespace ConsoleApp.Puzzles.Year2015.Puzzles
{
    public class Year2015Day03 : Year2015Day
    {
        public override int Day => 3;

        public override PuzzleResult RunPart1()
        {
            var grid = new DeliveryGrid();
            grid.DeliverBySanta(FileInput);
            
            return new PuzzleResult(grid.SantaDeliveryCount, 2592);
        }

        public override PuzzleResult RunPart2()
        {
            var grid = new DeliveryGrid();
            grid.DeliverBySantaAndRobot(FileInput);
            
            return new PuzzleResult(grid.SantaDeliveryCount, 2360);
        }
    }
}