using System.Text;
using System.IO;

namespace Puzzles.Common.Files;

public static class FileReader
{
    public static string ReadTextFile(string path)
    {
        var filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            path);

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        return File.ReadAllText(filePath, Encoding.UTF8);
    }
}