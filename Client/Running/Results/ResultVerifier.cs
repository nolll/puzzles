using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Client.Running.Results;

public class ResultVerifier(HashFactory hashFactory, string seed)
{
    private readonly bool _isEnabled = seed != string.Empty;

    public VerifiedPuzzleResult Verify(PuzzleResult result)
    {
        if (!_isEnabled)
            return new VerifiedPuzzleResult(result, "", ResultStatus.Unverified);

        var hash = GetHash(result.Answer);
        var status = GetStatus(result.ResultType, result.Answer, hash, result.Hash);
        return new VerifiedPuzzleResult(result, hash, status);
    }

    private string GetHash(string answer) => answer != string.Empty
        ? hashFactory.StringHash($"{seed}{answer}")
        : string.Empty;

    private static ResultStatus GetStatus(
        PuzzleResultType resultType, 
        string? answer, 
        string answerHash,
        string? checkHash)
    {
        if (resultType is PuzzleResultType.Empty)
            return ResultStatus.Missing;

        if (answer is null)
            return ResultStatus.Wrong;
        
        if (checkHash is not null)
            return answerHash == checkHash
                ? ResultStatus.Correct
                : ResultStatus.Wrong;

        return ResultStatus.Completed;
    }
}