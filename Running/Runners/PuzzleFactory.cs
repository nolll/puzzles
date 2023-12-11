using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public static class PuzzleFactory
{
    public static Puzzle CreateInstance(Type t)
    {
        var ctor = t.GetConstructors().First();

        var parameters = ctor.GetParameters();
        object[] args = parameters.Length == 1
            ? [PuzzleFileReader.ReadInput(t)]
            : [];

        if (ctor?.Invoke(args) is not Puzzle puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }
}