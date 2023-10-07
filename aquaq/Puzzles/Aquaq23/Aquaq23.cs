using Common.Cryptography;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq23;

public class Aquaq23 : AquaqPuzzle
{
    public override string Name => "Fair Play";

    protected override PuzzleResult Run()
    {
        var result = new PlayfairCipher("power plant").Decrypt("vepcundbyoaeirotivluxnotpstfnbwept");

        return new PuzzleResult(result, "youlxlhavetospeakupimwearingatowel");
    }
}