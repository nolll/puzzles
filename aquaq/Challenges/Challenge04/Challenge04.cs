using AquaQ.Platform;
using common.Puzzles;

namespace AquaQ.Challenges.Challenge04;

public class Challenge04 : AquaQPuzzle
{
    public override string Name => "Short walks";

    public override PuzzleResult Run()
    {
        var walker = new Walker();
        var result = walker.Walk(FileInput);

        return new PuzzleResult(result, 2543);
    }
}