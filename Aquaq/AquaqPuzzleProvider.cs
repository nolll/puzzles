using Pzl.Common;

namespace Pzl.Aquaq;

public class AquaqPuzzleProvider : IPuzzleProvider
{
    public List<Puzzle> GetPuzzles()
    {
        return PuzzleFactory.CreatePuzzles<AquaqPuzzle>();
    }
}