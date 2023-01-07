using System;
using System.IO;
using System.Text;

namespace Core.Platform;

public abstract class Puzzle
{
    public abstract string Title { get; }
    public virtual string Comment => "";
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public virtual PuzzleResult RunPart1()
    {
        return null;
    }

    public virtual PuzzleResult RunPart2()
    {
        return null;
    }

    protected string FileInput
    {
        get
        {
            var filePath = FilePath;
            if(!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    private string FilePath
    {
        get
        {
            var type = GetType();
            var (year, day) = PuzzleParser.ParseType(type);
            var paddedDay = day.ToString().PadLeft(2, '0');
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Puzzles",
                $"Year{year}",
                $"Day{paddedDay}",
                $"Year{year}Day{paddedDay}.txt");
        }
    }
}