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

    public string[] ReadInputs(PuzzleDefinition definition)
    {
        if(definition.HasUniqueInputsPerPart)
        {
            return Enumerable.Range(0, definition.NumberOfParts)
                .Select(o => ReadPartInput(definition.Type, o + 1))
                .ToArray();
        }
        
        return [ReadInput(definition.Type)];
    }
    
    public string ReadAdditionalFile(Type t, MethodInfo method)
    {
        var commonFile = GetAdditionalCommonInputFile(method);
        if (commonFile is not null)
            return ReadCommon(commonFile);

        var localFile = GetAdditionalLocalInputFile(method);
        if (localFile is not null)
            return ReadLocal(t, localFile);

        return "";
    }
    
    private static string? GetAdditionalCommonInputFile(MethodInfo method) =>
        method.GetCustomAttribute<AdditionalCommonInputFileAttribute>(false)?.FileName;
    
    private static string? GetAdditionalLocalInputFile(MethodInfo method) =>
        method.GetCustomAttribute<AdditionalLocalInputFileAttribute>(false)?.FileName;

    private static string ReadInput(Type t)
    {
        var path  = Path.Combine(PuzzlePathParts(t));
        var inputFilePath = $"{path}.txt";
        var s = ReadTextFile(inputFilePath);

        return s;
    }

    private static string ReadPartInput(Type t, int part)
    {
        var path  = Path.Combine(PuzzlePathParts(t));
        var inputFilePath = $"{path}-{part}.txt";
        var s = ReadTextFile(inputFilePath);

        return s;
    }

    public string ReadCommon(string fileName)
    {
        var parts = new List<string>
        {
            "CommonInputFiles",
            fileName
        };
        var filePath = Path.Combine(parts.ToArray());
        return ReadTextFile(filePath);
    }

    public string ReadLocal(Type t, string fileName)
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