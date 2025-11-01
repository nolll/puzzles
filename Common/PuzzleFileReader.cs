using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pzl.Common;

public class FileReader
{
    private static string[] PuzzlePathParts(Type t) => t.FullName!.Split('.').Skip(2).ToArray();

    public string[] ReadInputs(PuzzleDefinition definition) => definition.HasUniqueInputsPerPart
        ? Enumerable.Range(0, definition.NumberOfParts)
            .Select(o => ReadPartInput(definition.Type, o + 1))
            .ToArray()
        : [ReadInput(definition.Type)];

    public string ReadAdditionalFile(Type t, MethodInfo method)
    {
        var commonFile = GetAdditionalCommonInputFile(method);
        if (commonFile is not null)
            return ReadCommon(commonFile);

        var localFile = GetAdditionalLocalInputFile(method);
        
        return localFile is not null 
            ? ReadLocal(t, localFile) 
            : "";
    }
    
    private static string? GetAdditionalCommonInputFile(MethodInfo method) =>
        method.GetCustomAttribute<AdditionalCommonInputFileAttribute>(false)?.FileName;
    
    private static string? GetAdditionalLocalInputFile(MethodInfo method) =>
        method.GetCustomAttribute<AdditionalLocalInputFileAttribute>(false)?.FileName;

    private static string ReadInput(Type t) => ReadTextFile($"{Path.Combine(PuzzlePathParts(t))}.txt");
    private static string ReadPartInput(Type t, int part) => ReadTextFile($"{Path.Combine(PuzzlePathParts(t))}-{part}.txt");

    public static string ReadCommon(string fileName)
    {
        var parts = new List<string>
        {
            "CommonInputFiles",
            fileName
        };
        var filePath = Path.Combine(parts.ToArray());
        return ReadTextFile(filePath);
    }

    public static string ReadLocal(Type t, string fileName)
    {
        var parts = PuzzlePathParts(t).SkipLast(1).ToList();
        parts.Add(fileName);
        var filePath = Path.Combine(parts.ToArray());
        return ReadTextFile(filePath);
    }

    private static string ReadTextFile(string path)
    {
        var filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            path);

        return File.Exists(filePath) 
            ? File.ReadAllText(filePath, Encoding.UTF8) 
            : "";
    }
}