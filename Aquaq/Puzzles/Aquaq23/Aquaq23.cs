using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Aquaq.Puzzles.Aquaq23;

[Name("Fair Play")]
public class Aquaq23 : AquaqPuzzle
{
    [Puzzle("bf98b9864ec8815e9bfb28dcdba4c0d6")]
    public PuzzleResult Solve(string input)
    {
        var result = new PlayfairCipher("power plant").Decrypt("vepcundbyoaeirotivluxnotpstfnbwept");

        return new PuzzleResult(result);
    }
}