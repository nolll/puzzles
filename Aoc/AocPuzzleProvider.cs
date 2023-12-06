using Pzl.Common;

namespace Pzl.Aoc;

public class AocPuzzleProvider : IPuzzleProvider
{
    public List<Puzzle> GetPuzzles()
    {
        return PuzzleFactory.CreatePuzzles<AocPuzzle>();
    }
}