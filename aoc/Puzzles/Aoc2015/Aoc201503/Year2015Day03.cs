using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Day03;

public class Year2015Day03 : AocPuzzle
{
    public override string Name => "Perfectly Spherical Houses in a Vacuum";

    protected override PuzzleResult RunPart1()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(InputFile);
            
        return new PuzzleResult(grid.SantaDeliveryCount, 2592);
    }

    protected override PuzzleResult RunPart2()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(InputFile);
            
        return new PuzzleResult(grid.SantaDeliveryCount, 2360);
    }
}