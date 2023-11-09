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
        var hash = GetHash(result.Answer);
        var status = GetStatus(result.Type, result.Answer, hash, result.CheckHash);
        return new VerifiedPuzzleResult(result, hash, status);
    }

    private string GetHash(string answer)
    {
        return answer != string.Empty 
            ? _hashFactory.StringHashFromString($"{_seed}{answer}") 
            : string.Empty;
    }

    private static PuzzleResultStatus GetStatus(
        PuzzleType type, 
        string? answer, 
        string answerHash,
        string? checkHash)
    {
        if (type is PuzzleType.Empty)
            return PuzzleResultStatus.Missing;

        if (answer is null)
            return PuzzleResultStatus.Wrong;
        
        if (checkHash is not null)
            return answerHash == checkHash
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;

        return PuzzleResultStatus.Completed;
    }
}