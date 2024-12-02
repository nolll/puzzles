using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFunction(Puzzle puzzle, MethodInfo method)
{
    public Puzzle Puzzle { get; } = puzzle;
    public MethodInfo Method { get; } = method;
    public int ParameterCount { get; } = method.GetParameters().Length;

    public PuzzleResult Invoke(object[] args)
    {
        var result = Method.Invoke(Puzzle, args);
        if (result is not PuzzleResult puzzleResult)
            throw new Exception("Result is not of type PuzzleResult");

        return puzzleResult;
    }
}