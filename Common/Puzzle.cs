using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pzl.Common;

public abstract class Puzzle(string? input = null)
{
    protected string InjectedInput { get; } = input ?? string.Empty;
    protected string InputFile => !string.IsNullOrEmpty(InjectedInput) 
        ? InjectedInput
        : FileReader.ReadTextFile(InputFilePath);
    protected string TextFile(string fileName) => ReadLocalFile(fileName);
    protected string CommonTextFile(string fileName) => ReadCommonFile(fileName);

    protected string PuzzlePath => Path.Combine(PuzzlePathParts);

    private string ReadLocalFile(string fileName)
    {
        var parts = PuzzlePathParts.SkipLast(1).ToList();
        parts.Add(fileName);
        var filePath = Path.Combine(parts.ToArray());
        return FileReader.ReadTextFile(filePath);
    }

    private string ReadCommonFile(string fileName)
    {
        var parts = new List<string>
        {
            "CommonInputFiles",
            fileName
        };
        var filePath = Path.Combine(parts.ToArray());
        return FileReader.ReadTextFile(filePath);
    }

    private string[] PuzzlePathParts => GetType()
        .FullName!
        .Split('.')
        .Skip(2)
        .ToArray();

    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }

    private string InputFilePath => $"{PuzzlePath}.txt";
}