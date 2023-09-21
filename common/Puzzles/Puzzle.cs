using System.Text;

namespace common.Puzzles;

public abstract class Puzzle
{
    protected string FileInput
    {
        get
        {
            var filePath = FilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    protected virtual string FilePath => GetFilePath(GetType());
    protected abstract string GetFilePath(Type t);
    protected string RootPath => AppDomain.CurrentDomain.BaseDirectory;
}