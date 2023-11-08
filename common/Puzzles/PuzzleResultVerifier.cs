using Common.Cryptography;

namespace Common.Puzzles;

public class PuzzleResultVerifier
{
    private readonly string _seed;
    private readonly Hashfactory _hashFactory = new();

    public PuzzleResultVerifier(string seed)
    {
        _seed = seed;
    }

    public VerifiedPuzzleResult Verify(PuzzleResult result)
    {
        var status = GetStatus(result.Answer, _hashFactory.StringHashFromString(result.Answer), result.CorrectAnswer, result.CorrectAnswerHash);
        return new VerifiedPuzzleResult(result, status);
    }

    private string GetHash(string answer)
    {
        return _hashFactory.StringHashFromString($"{_seed}{answer}");
    }

    private static PuzzleResultStatus GetStatus(string? answer, string answerHash, string? correctAnswer, string? correctAnswerHash)
    {
        if (answer is null)
            return PuzzleResultStatus.Wrong;

        if (correctAnswer is not null)
            return answer == correctAnswer
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        if (correctAnswerHash is not null)
            return answerHash == correctAnswerHash
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        return PuzzleResultStatus.Completed;
    }
}