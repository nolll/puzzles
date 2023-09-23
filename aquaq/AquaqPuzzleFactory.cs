using Common.Puzzles;

namespace Aquaq;

public class AquaqPuzzleFactory : PuzzleFactory
{
    public override List<Puzzle> CreatePuzzles() => CreatePuzzles<AquaqPuzzle>();
}