using Pzl.Common;

namespace Pzl.Euler;

public class EulerPuzzleProvider : IPuzzleProvider
{
    public List<Puzzle> GetPuzzles()
    {
        return PuzzleFactory.CreatePuzzles<EulerPuzzle>();
    }
}