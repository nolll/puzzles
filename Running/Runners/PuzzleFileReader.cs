using System.IO;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public static class PuzzleFileReader
{
    public static string ReadInput(Type t)
    {
        var pathParts = t.FullName!.Split('.').Skip(2).ToArray();
        var path  = Path.Combine(pathParts);
        var inputFilePath = $"{path}.txt";
        var s = FileReader.ReadTextFile(inputFilePath);

        return s;
    }
}