using Puzzles.Common.Cryptography;
using Puzzles.Common.Puzzles;

namespace Puzzles.Aquaq.Puzzles.Aquaq23;

public class Aquaq23 : AquaqPuzzle
{
    public override string Name => "Fair Play";

    protected override PuzzleResult Run()
    {
        var result = new PlayfairCipher("power plant").Decrypt("vepcundbyoaeirotivluxnotpstfnbwept");

        return new PuzzleResult(result, "bf98b9864ec8815e9bfb28dcdba4c0d6");
    }
}