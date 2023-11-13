using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201813;

public class Aoc201813 : AocPuzzle
{
    public override string Name => "Mine Cart Madness";

    protected override PuzzleResult RunPart1()
    {
        var detector = new CollisionDetector(InputFile);
        detector.RunCarts();
        var firstCollisionCoords = detector.LocationOfFirstCollision;
        var firstCollition = $"{firstCollisionCoords!.X},{firstCollisionCoords.Y}";
        return new PuzzleResult(firstCollition, "289dd4c6742ccddf660417b3b45acad3");
    }

    protected override PuzzleResult RunPart2()
    {
        var detector = new CollisionDetector(InputFile);
        detector.RunCarts();
        var lastCartCoords = detector.LocationOfLastCart;
        var lastCart = $"{lastCartCoords!.X},{lastCartCoords.Y}";
        return new PuzzleResult(lastCart, "b4f2a42936a725f796e9f00399495d54");
    }
}