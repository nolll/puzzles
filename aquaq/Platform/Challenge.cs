using System.IO;
using System.Text;

namespace AquaQ.Platform;

public abstract class Challenge
{
    public abstract string Name { get; }
    public virtual string? Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;

    public abstract ChallengeResult Run();

    protected string FileInput
    {
        get
        {
            var filePath = FilePath;
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }

    private string FilePath
    {
        get
        {
            var type = GetType();
            var challengeId = ChallengeParser.ParseType(type);
            var paddedChallengeId = challengeId.ToString().PadLeft(2, '0');
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Challenges",
                $"Challenge{paddedChallengeId}",
                $"Challenge{paddedChallengeId}.txt");
        }
    }
}