using Common.Compression;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq24;

public class Aquaq24 : AquaqPuzzle
{
    public override string Name => "Huff and Puff";

    protected override PuzzleResult Run()
    {
        var parts = InputFile.Split(Environment.NewLine);

        var charset = parts[0];
        var encoded = parts[1];

        var huffman = new HuffmanCompression(charset);
        var decoded = huffman.Decode(encoded);

        // The answer is just a part of the string
        var result = decoded.Split(" ").Last().Trim();

        return new PuzzleResult(result, null, "23ad8be7b57a17a9bee0021b20637f29");
    }
}