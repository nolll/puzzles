using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

[Name("Perfectly Spherical Houses in a Vacuum")]
public class Aoc201503 : AocPuzzle
{
    [Puzzle("68e2d15877e8590fe0285bff9141a8cf")]
    public int Part1(string input)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(input);
            
        return grid.SantaDeliveryCount;
    }

    [Puzzle("7d063c75c9ee4f2a8fe2d97228a36f79")]
    public int Part2(string input)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(input);
            
        return grid.SantaDeliveryCount;
    }
}