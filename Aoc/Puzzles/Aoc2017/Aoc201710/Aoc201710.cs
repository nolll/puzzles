using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201710;

[Name("Knot Hash")]
public class Aoc201710 : AocPuzzle
{
    [Puzzle("9c105df09bcd0a4924f4fd2f82cc37db")]
    public int Part1(string input) => new IntKnotHasher(input).Checksum;

    [Puzzle("184cedf831647600e6b64716e141b2e9")]
    public string Part2(string input) => new AsciiKnotHasher(input).Hash;
}