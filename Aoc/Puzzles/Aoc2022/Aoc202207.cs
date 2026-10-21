using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("No Space Left On Device")]
public class Aoc202207 : AocPuzzle
{
    private const int FileSystemSize = 70_000_000;
    private const int SpaceNeededForUpdate = 30_000_000;

    [Puzzle("4f30884d94a8463608dcc378747e00f7")]
    public long Part1(string input) => FindDirectories(ParseFileSystem(input), 100_000).Sum(o => o.Size);

    [Puzzle("e619d2b3e6e0cf1c93c956785cb6e527")]
    public long Part2(string input)
    {
        var fileSystem = ParseFileSystem(input);
        var spaceToDelete = SpaceNeededForUpdate - (FileSystemSize - fileSystem.Size);
        return FindDirectories(fileSystem).Select(o => o.Size).Where(o => o > spaceToDelete).MinBy(o => o);
    }

    private static List<ElfDirectory> FindDirectories(ElfDirectory currentDir, int? sizeLimit = null)
    {
        var dirs = new List<ElfDirectory>();
        if (sizeLimit is null || currentDir.Size <= sizeLimit.Value)
            dirs.Add(currentDir);

        foreach (var child in currentDir.Directories.Values)
            dirs.AddRange(FindDirectories(child, sizeLimit));

        return dirs;
    }

    private static ElfDirectory ParseFileSystem(string input)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0).Skip(1);

        var fileSystem = new ElfDirectory();
        var currentDir = fileSystem;
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var isCommand = parts[0] == "$";
            var isDirectory = parts[0] == "dir";
            var isFile = !isCommand && !isDirectory;
            if (isCommand && parts[1] == "cd")
            {
                var directory = parts[2];
                currentDir = directory == ".." && currentDir.Parent is not null
                    ? currentDir.Parent
                    : currentDir.Directories[directory];
            }
            else if (isDirectory)
                currentDir.Directories.Add(parts[1], new ElfDirectory(currentDir));
            else if (isFile) 
                currentDir.Files.Add(parts[1], long.Parse(parts[0]));
        }

        return fileSystem;
    }

    public class ElfDirectory(ElfDirectory? parent = null)
    {
        public ElfDirectory? Parent { get; } = parent;
        public IDictionary<string, ElfDirectory> Directories { get; } = new Dictionary<string, ElfDirectory>();
        public IDictionary<string, long> Files { get; } = new Dictionary<string, long>();

        public long Size => Directories.Values.ToList().Sum(o => o.Size) + Files.Values.Sum();
    }
}