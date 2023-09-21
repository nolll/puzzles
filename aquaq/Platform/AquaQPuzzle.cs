using System.IO;
using System.Text;
using common.Puzzles;

namespace AquaQ.Platform;

public abstract class AquaQPuzzle : OnePartPuzzle
{
    protected sealed override string GetFilePath(Type t)
    {
        var challengeId = ChallengeParser.GetChallengeId(t);
        var paddedChallengeId = challengeId.ToString().PadLeft(2, '0');
        return Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Puzzles",
            $"Aquaq{paddedChallengeId}",
            $"Aquaq{paddedChallengeId}.txt");
    }
}