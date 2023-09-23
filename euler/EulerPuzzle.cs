using System;
using System.IO;
using Common.Puzzles;

namespace Euler;

public abstract class EulerPuzzle : OnePartPuzzle
{
    protected sealed override string GetRelativeFilePath(Type t)
    {
        var id = EulerPuzzleParser.GetPuzzleId(t);
        var paddedId = id.ToString().PadLeft(3, '0');
        return Path.Combine(
            "Problems",
            $"Problem{paddedId}",
            $"Problem{paddedId}.txt");
    }
}