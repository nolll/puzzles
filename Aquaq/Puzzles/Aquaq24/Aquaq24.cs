using Pzl.Common;
using Pzl.Tools.Compression;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq24;

[Name("Huff and Puff")]
public class Aquaq24 : AquaqPuzzle
{
    [Puzzle("23ad8be7b57a17a9bee0021b20637f29")]
    public string Solve(string input)
    {
        var parts = input.Split(LineBreaks.Single);

        var charset = parts[0];
        var encoded = parts[1];

        var huffman = new HuffmanCompression(charset);
        var decoded = huffman.Decode(encoded);

        // The answer is just a part of the string
        return decoded.Split(" ").Last().Trim();
    }
}