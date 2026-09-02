using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pzl.Common;

public class FileReader(string inputLocation)
{
    private static string[] PuzzlePathParts(Type t)
    {
        var parts = t.FullName!.Split('.').Skip(1).ToList();
        return parts.Count == 4 
            ? [parts[0], parts[2]] 
            : [parts[0], parts[2], parts[3]];
    }
    
    private static string[] CustomPathParts(Type t) => t.FullName!.Split('.').Skip(1).Take(1).ToArray();

    public string[] ReadInputs(PuzzleDefinition definition) => definition.HasUniqueInputsPerPart
        ? Enumerable.Range(0, definition.NumberOfParts)
            .Select(o => ReadPartInput(definition.Type, o + 1))
            .ToArray()
        : [ReadInput(definition.Type)];

    public string ReadAdditionalFile(Type t, MethodInfo method)
    {
        var commonFile = GetAdditionalCommonInputFile(method);
        return commonFile is not null 
            ? ReadCommon(t, commonFile) 
            : "";
    }
    
    private static string? GetAdditionalCommonInputFile(MethodInfo method) =>
        method.GetCustomAttribute<AdditionalInputFileAttribute>(false)?.FileName;
    
    private string ReadInput(Type t) => ReadInputFile(t, ".txt");
    private string ReadPartInput(Type t, int part) => ReadInputFile(t, $"-{part}.txt");

    public string ReadCommon(Type t, string fileName)
    {
        var filePath = Path.Combine([..CustomPathParts(t), fileName]);
        return ReadExternalTextFile(filePath);
    }
    
    private string ReadInputFile(Type t, string suffix)
    {
        var externalPath = $"{Path.Combine(PuzzlePathParts(t))}{suffix}";
        return ReadExternalTextFile(externalPath);
    }

    private string ReadExternalTextFile(string path)
    {
        var filePath = Path.Combine(
            inputLocation!,
            path);

        return File.Exists(filePath) 
            ? File.ReadAllText(filePath, Encoding.UTF8) 
            : "";
    }
}