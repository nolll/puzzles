using System.IO;
using System.Text;
using common.Puzzles;

namespace AquaQ.Platform;

public abstract class Challenge : Puzzle
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public abstract ChallengeResult Run();
    
    protected sealed override string FilePath
    {
        get
        {
            var type = GetType();
            var challengeId = ChallengeParser.GetChallengeId(type);
            var paddedChallengeId = challengeId.ToString().PadLeft(2, '0');
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Challenges",
                $"Challenge{paddedChallengeId}",
                $"Challenge{paddedChallengeId}.txt");
        }
    }
}