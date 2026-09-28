using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("No Space Left On Device")]
public class Aoc202207 : AocPuzzle
{
    [Puzzle("4f30884d94a8463608dcc378747e00f7")]
    public long Part1(string input) => new FileSystem(input).Part1();

    [Puzzle("e619d2b3e6e0cf1c93c956785cb6e527")]
    public long Part2(string input) => new FileSystem(input).Part2();

    public class FileSystem(string input)
    {
        private readonly ElfDirectory _fileSystem = ParseFileSystem(input);

        public long Part1()
        {
            var smallDirs = new List<ElfDirectory>();
            FindSmallDirectories(_fileSystem, smallDirs);
            return smallDirs.Sum(o => o.Size);
        }

        public long Part2()
        {
            const int fileSystemSize = 70_000_000;
            const int spaceNeededForUpdate = 30_000_000;
            var spaceUsed = _fileSystem.Size;
            var freeSpace = fileSystemSize - spaceUsed;
            var spaceToDelete = spaceNeededForUpdate - freeSpace;

            var allDirs = new List<ElfDirectory>();
            FindAllDirectories(_fileSystem, allDirs);

            return allDirs
                .Select(o => o.Size)
                .Where(o => o > spaceToDelete)
                .MinBy(o => o);
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
                {
                    currentDir.Directories.Add(parts[1], new ElfDirectory(currentDir));
                }
                else if (isFile)
                {
                    currentDir.Files.Add(parts[1], long.Parse(parts[0]));
                }
            }

            return fileSystem;
        }

        private static void FindAllDirectories(ElfDirectory currentDir, IList<ElfDirectory> allDirs)
        {
            allDirs.Add(currentDir);

            foreach (var child in currentDir.Directories.Values)
            {
                FindAllDirectories(child, allDirs);
            }
        }

        private static void FindSmallDirectories(ElfDirectory currentDir, IList<ElfDirectory> smallDirs)
        {
            if (currentDir.Size <= 100000)
                smallDirs.Add(currentDir);

            foreach (var child in currentDir.Directories.Values)
            {
                FindSmallDirectories(child, smallDirs);
            }
        }
    }
    
    public class ElfDirectory
    {
        public ElfDirectory? Parent { get; }
        public IDictionary<string, ElfDirectory> Directories { get; }
        public IDictionary<string, long> Files { get; }

        public ElfDirectory(ElfDirectory? parent = null)
        {
            Parent = parent;
            Directories = new Dictionary<string, ElfDirectory>();
            Files = new Dictionary<string, long>();
        }

        public long Size
        {
            get
            {
                return Directories.Values.ToList().Sum(o => o.Size) + Files.Values.Sum();
            }
        }
    }
}