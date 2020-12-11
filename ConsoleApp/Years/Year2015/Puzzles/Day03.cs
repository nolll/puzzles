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
            var grid1 = new DeliveryGrid();
            grid1.DeliverBySanta(FileInput);
            return new PuzzleResult($"Presents delivered to {grid1.SantaDeliveryCount} houses by Santa");
        }

        public override PuzzleResult RunPart2()
        {
            var grid2 = new DeliveryGrid();
            grid2.DeliverBySantaAndRobot(FileInput);
            return new PuzzleResult($"Presents delivered to {grid2.SantaDeliveryCount} houses by Santa and robot");
        }
    }
}