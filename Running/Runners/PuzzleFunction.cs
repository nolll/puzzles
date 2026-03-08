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
            PuzzleResult o => new PuzzleResult(o.Type, o.Answer, hash ?? o.Hash),
            string o => new PuzzleResult(o, hash),
            int o => new PuzzleResult(o, hash),
            long o => new PuzzleResult(o, hash),
            BigInteger o => new PuzzleResult(o, hash),
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