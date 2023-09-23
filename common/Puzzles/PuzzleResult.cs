﻿using System.Numerics;

namespace Common.Puzzles;

public class PuzzleResult
{
    public string Answer { get; }
    public PuzzleResultStatus Status { get; }

    public PuzzleResult(string? answer, string? correctAnswer = null)
        : this(answer, VerifyResult(answer, correctAnswer))
    {
    }

    public PuzzleResult(int? answer, int? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(long? answer, long? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    public PuzzleResult(BigInteger? answer, BigInteger? correctAnswer = null)
        : this(answer?.ToString(), correctAnswer?.ToString())
    {
    }

    protected PuzzleResult(string? answer, PuzzleResultStatus status)
    {
        Answer = answer ?? string.Empty;
        Status = status;
    }

    public static PuzzleResult Empty => new PuzzleResult("No puzzle here", PuzzleResultStatus.Empty);
    public static PuzzleResult Failed => new PuzzleResult("Failed", PuzzleResultStatus.Failed);

    private static PuzzleResultStatus VerifyResult(string? answer, string? correctAnswer)
    {
        if (answer == null)
            return PuzzleResultStatus.Wrong;

        if (correctAnswer == null)
            return PuzzleResultStatus.Completed;

        return answer == correctAnswer
            ? PuzzleResultStatus.Correct
            : PuzzleResultStatus.Wrong;
    }
}