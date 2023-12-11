using System.IO;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public static class PuzzleFileReader
{
    private static string[] PuzzlePathParts(Type t) => t.FullName!.Split('.').Skip(2).ToArray();

    public static string ReadInput(Type t)
    {
        var path  = Path.Combine(PuzzlePathParts(t));
        var inputFilePath = $"{path}.txt";
        var s = FileReader.ReadTextFile(inputFilePath);

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
        return FileReader.ReadTextFile(filePath);
    }

    public static string ReadLocal(Type t, string fileName)
    {
        var parts = PuzzlePathParts(t).SkipLast(1).ToList();
        parts.Add(fileName);
        var filePath = Path.Combine(parts.ToArray());
        return FileReader.ReadTextFile(filePath);
    }
}