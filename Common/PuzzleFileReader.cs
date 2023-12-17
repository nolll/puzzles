using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pzl.Common;

public static class FileReader
{
    private static string[] PuzzlePathParts(Type t) => t.FullName!.Split('.').Skip(2).ToArray();

    public static string ReadInput(Type t)
    {
        var path  = Path.Combine(PuzzlePathParts(t));
        var inputFilePath = $"{path}.txt";
        var s = ReadTextFile(inputFilePath);

        return s;
    }

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

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        return File.ReadAllText(filePath, Encoding.UTF8);
    }
}