using Common.Cryptography;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq23;

public class Aquaq23 : AquaqPuzzle
{
    public override string Name => "Fair Play";

    protected override PuzzleResult Run()
    {
        var result = new PlayfairCipher("power plant").Decrypt("vepcundbyoaeirotivluxnotpstfnbwept");

        return new PuzzleResult(result, null, "e4f41dc49cad58c30f23b591da055e2f");
    }
}