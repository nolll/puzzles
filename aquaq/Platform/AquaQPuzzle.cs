using System.IO;
using System.Text;
using common.Puzzles;

namespace AquaQ.Platform;

public abstract class AquaQPuzzle : Puzzle
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public abstract PuzzleResult Run();
    
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