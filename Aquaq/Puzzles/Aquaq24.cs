using Pzl.Common;
using Pzl.Tools.Compression;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Huff and Puff")]
public class Aquaq24 : AquaqPuzzle
{
    [Puzzle("23ad8be7b57a17a9bee0021b20637f29")]
    public string Solve(string input)
    {
        var (charset, encoded) = input.Split(LineBreaks.Single);
        return new HuffmanCompression(charset).Decode(encoded).Split(" ").Last();
    }
}