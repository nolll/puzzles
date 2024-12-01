using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

[Name("Perfectly Spherical Houses in a Vacuum")]
public class Aoc201503 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(input);
            
        return new PuzzleResult(grid.SantaDeliveryCount, "68e2d15877e8590fe0285bff9141a8cf");
    }

    public PuzzleResult RunPart2(string input)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(input);
            
        return new PuzzleResult(grid.SantaDeliveryCount, "7d063c75c9ee4f2a8fe2d97228a36f79");
    }
}