using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFactory(FileReader fileReader)
{
    public PuzzleFunction[] GetFunctions(PuzzleDefinition definition)
    {
        var methods = GetPuzzleFuncs(definition);
        var inputs = fileReader.ReadInputs(definition);

        var funcs = new List<PuzzleFunction>();
        for (var i = 0; i < methods.Length; i++)
        {
            var method = methods[i];
            var input = definition.HasUniqueInputsPerPart
                ? inputs[i]
                : inputs[0];
            
            object[] parameters = [input];
            if (method.GetParameters().Length > 1)
            {
                var additionalInput = fileReader.ReadAdditionalFile(definition.Type, method);
                if(!string.IsNullOrEmpty(additionalInput))
                    parameters = [.. inputs, additionalInput];
            }

            var func = new PuzzleFunction(method, parameters, GetHash(method));
            funcs.Add(func);
        }

        return funcs.ToArray();
    }
    
    public Puzzle CreateInstance(PuzzleDefinition definition) => 
        definition.Type.GetConstructors().First().Invoke([]) as Puzzle ?? throw new Exception($"Could not create puzzle: {definition.Type}");

    public static MethodInfo[] GetPuzzleFuncs(PuzzleDefinition definition) => definition.Type.GetMethods()
        .Where(IsPuzzleFunc)
        .OrderBy(o => o.Name)
        .ToArray();

    private static string? GetHash(MethodInfo method) =>
        method.GetCustomAttribute<PuzzleAttribute>(false)?.Hash;

    private static bool IsPuzzleFunc(MethodInfo method) =>
        method is { IsPublic: true, IsStatic: false } &&
        method.GetCustomAttribute<PuzzleAttribute>(false) is not null;
}