using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day03;

public class Year2015Day03 : AocPuzzle
{
    public override string Name => "Perfectly Spherical Houses in a Vacuum";

    protected override PuzzleResult RunPart1()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(FileInput);
            
        return new PuzzleResult(grid.SantaDeliveryCount, 2592);
    }

    protected override PuzzleResult RunPart2()
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(FileInput);
            
        return new PuzzleResult(grid.SantaDeliveryCount, 2360);
    }
}