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
            PuzzleResult o => PuzzleResult.Create(o.Type, o.Answer, hash ?? o.Hash),
            string o => PuzzleResult.Create(o, hash),
            int o => PuzzleResult.Create(o, hash),
            long o => PuzzleResult.Create(o, hash),
            BigInteger o => PuzzleResult.Create(o, hash),
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