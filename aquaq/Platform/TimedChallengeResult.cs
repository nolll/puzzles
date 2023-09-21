namespace AquaQ.Platform;

public class TimedChallengeResult : ChallengeResult
{
    public TimeSpan TimeTaken { get; }

    public TimedChallengeResult(ChallengeResult result, TimeSpan timeTaken)
        : base(result.Answer, result.CorrectAnswer, result.Status)
    {
        TimeTaken = timeTaken;
    }
}