using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pzl.Common;

public class FileReader(string? inputLocation = null)
{
    private static string[] InternalPuzzlePathParts(Type t) => t.FullName!.Split('.').Skip(2).ToArray();
    private static string[] ExternalPuzzlePathParts(Type t)
    {
        var parts = t.FullName!.Split('.').Skip(1).ToList();
        return parts.Count == 4 
            ? [parts[0], parts[2]] 
            : [parts[0], parts[2], parts[3]];
    }

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

    private string ReadInput(Type t) => ReadInputFile(t, ".txt");
    private string ReadPartInput(Type t, int part) => ReadInputFile(t, $"-{part}.txt");

    public string ReadCommon(string fileName)
    {
        var parts = new List<string>
        {
            "CommonInputFiles",
            fileName
        };
        var filePath = Path.Combine(parts.ToArray());
        return ReadInternalTextFile(filePath);
    }

    public string ReadLocal(Type t, string fileName)
    {
        var parts = InternalPuzzlePathParts(t).SkipLast(1).ToList();
        parts.Add(fileName);
        var filePath = Path.Combine(parts.ToArray());
        return ReadInternalTextFile(filePath);
    }
    
    private string ReadInputFile(Type t, string suffix)
    {
        if (inputLocation is not null)
        {
            var externalPath = $"{Path.Combine(ExternalPuzzlePathParts(t))}{suffix}";
            var content = ReadExternalTextFile(externalPath);
            if(content != "")
                return content;
        }

        var internalPath = $"{Path.Combine(InternalPuzzlePathParts(t))}{suffix}";
        return ReadInternalTextFile(internalPath);
    }

    private string ReadInternalTextFile(string path)
    {
        var filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            path);

        return File.Exists(filePath) 
            ? File.ReadAllText(filePath, Encoding.UTF8) 
            : "";
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