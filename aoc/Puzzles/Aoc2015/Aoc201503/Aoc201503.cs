using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201503;

public class Aoc201503 : AocPuzzle
{
    public override string Name => "Perfectly Spherical Houses in a Vacuum";

    protected override PuzzleResult RunPart1()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(InputFile);
            
        return new PuzzleResult(grid.SantaDeliveryCount, "68e2d15877e8590fe0285bff9141a8cf");
    }

    protected override PuzzleResult RunPart2()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(InputFile);
            
        return new PuzzleResult(grid.SantaDeliveryCount, "7d063c75c9ee4f2a8fe2d97228a36f79");
    }
}