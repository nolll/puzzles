using System.Reflection;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleFactory(FileReader fileReader)
{
    public PuzzleInstance CreateInstance(PuzzleDefinition definition)
    {
        var ctor = definition.Type.GetConstructors().First();

        if (ctor.Invoke([]) is not Puzzle puzzle)
            throw new Exception($"Could not create puzzle: {definition.Type}");
        
        var methods = definition.Type.GetMethods()
            .Where(IsPuzzleFunc)
            .OrderBy(o => o.Name)
            .ToArray();
        
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

            var func = new PuzzleFunction(puzzle, method, parameters, GetHash(method));
            funcs.Add(func);
        }

        return new PuzzleInstance(puzzle, funcs.ToArray());
    }
    
    private static string? GetHash(MethodInfo method) =>
        method.GetCustomAttribute<PuzzleAttribute>(false)?.Hash;
    
    private static bool IsPuzzleFunc(MethodInfo method) =>
        method is { IsPublic: true, IsStatic: false } &&
        (method.GetCustomAttribute<PuzzleAttribute>(false) is not null || method.ReturnType == typeof(PuzzleResult));
}