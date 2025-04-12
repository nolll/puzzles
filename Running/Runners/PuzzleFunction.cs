using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFunction(Puzzle puzzle, MethodInfo method, object[] passedParams)
{
    public PuzzleResult Invoke()
    {
        var parameters = AddOptionalParameters(method, passedParams);
        var result = method.Invoke(puzzle, parameters);
        if (result is not PuzzleResult puzzleResult)
            throw new Exception("Result is not of type PuzzleResult");

        return puzzleResult;
    }

    private static object[] AddOptionalParameters(MethodInfo methodInfo, object[] passedParams)
    {
        var methodParamCount = methodInfo.GetParameters().Length;
        if (passedParams.Length == methodParamCount)
            return passedParams;

        var optionalCount = methodParamCount - passedParams.Length;
        var extraParams = Enumerable.Range(0, optionalCount).Select(_ => Type.Missing);
        return [..passedParams, ..extraParams];
    }
}