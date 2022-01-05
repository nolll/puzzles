using App.Platform;

namespace App.Puzzles.Year2015.Day03;

public class Year2015Day03 : Puzzle
{
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