using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFunction(Puzzle puzzle, MethodInfo method, object[] parameters)
{
    public PuzzleResult Invoke()
    {
        var result = method.Invoke(puzzle, parameters);
        if (result is not PuzzleResult puzzleResult)
            throw new Exception("Result is not of type PuzzleResult");

        return puzzleResult;
    }
}