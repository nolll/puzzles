using Core.PresentDelivery;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day03 : Day2015
    {
        public Day03() : base(3)
        {
        }

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