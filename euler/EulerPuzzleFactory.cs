using Common.Puzzles;

namespace Euler;

public class EulerPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() => CreatePuzzles<EulerPuzzle>();
}