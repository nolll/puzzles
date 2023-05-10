using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2022.Day07;

public class ElfDirectory
{
    public ElfDirectory Parent { get; }
    public IDictionary<string, ElfDirectory> Directories { get; }
    public IDictionary<string, long> Files { get; }

    public ElfDirectory(ElfDirectory parent = null)
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