using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public static class PuzzleFactory
{
    public static PuzzleInstance CreateInstance(PuzzleDefinition definition)
    {
        var ctor = definition.Type.GetConstructors().First();

        if (ctor.Invoke([]) is not Puzzle puzzle)
            throw new Exception($"Could not create puzzle: {definition.Type}");
        
        var funcs = definition.Type.GetMethods()
            .Where(o => o is { IsPublic: true, IsStatic: false } && o.ReturnType == typeof(PuzzleResult))
            .OrderBy(o => o.Name)
            .Select(o => new PuzzleFunction(puzzle, o))
            .ToArray();

        return new PuzzleInstance(puzzle, funcs);
    }
}