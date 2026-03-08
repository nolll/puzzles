using System.Numerics;
using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFunction(Puzzle puzzle, MethodInfo method, object[] passedParams, string? hash)
{
    public PuzzleResult Invoke()
    {
        var parameters = AddOptionalParameters(method, passedParams);
        var result = method.Invoke(puzzle, parameters);
        
        return result switch
        {
            null => PuzzleResult.Empty,
            PuzzleResult puzzleResult => puzzleResult,
            string stringResult => new PuzzleResult(stringResult, hash),
            int intResult => new PuzzleResult(intResult, hash),
            long longResult => new PuzzleResult(longResult, hash),
            BigInteger bigIntegerResult => new PuzzleResult(bigIntegerResult, hash),
            _ => throw new Exception("Result is not of type PuzzleResult or a valid base type")
        };
    }

    private static object[] AddOptionalParameters(MethodInfo methodInfo, object[] passedParams)
    {
        var methodParamCount = methodInfo.GetParameters().Length;
        if (methodParamCount == 0)
            return [];
        
        if (passedParams.Length == methodParamCount)
            return passedParams;

        var optionalCount = methodParamCount - passedParams.Length;
        var extraParams = Enumerable.Range(0, optionalCount).Select(_ => Type.Missing);
        return [..passedParams, ..extraParams];
    }
}