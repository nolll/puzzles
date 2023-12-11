using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public static class PuzzleFactory
{
    public static Puzzle CreateInstance(PuzzleDefinition definition)
    {
        var ctor = definition.Type.GetConstructors().First();
        var args = GetArgs(definition, ctor);

        if (ctor?.Invoke(args) is not Puzzle puzzle)
            throw new Exception($"Could not create puzzle: {definition.Type}");

        return puzzle;
    }

    private static object[] GetArgs(PuzzleDefinition definition, MethodBase ctor)
    {
        var parameterCount = ctor.GetParameters().Length;
        return parameterCount switch
        {
            2 => [PuzzleFileReader.ReadInput(definition.Type), ReadAdditionalFile(definition)],
            1 => [PuzzleFileReader.ReadInput(definition.Type)],
            _ => []
        };
    }

    private static string ReadAdditionalFile(PuzzleDefinition definition)
    {
        if (definition.CommonFile is not null)
            return PuzzleFileReader.ReadCommon(definition.CommonFile);

        if (definition.LocalFile is not null)
            return PuzzleFileReader.ReadLocal(definition.Type, definition.LocalFile);

        return "";
    }
}