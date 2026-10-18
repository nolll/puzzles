using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Combo Breaker")]
public class Aoc202025 : AocPuzzle
{
    private const int DivideBy = 20_201_227;
    private const long SubjectNumber = 7;

    [Puzzle("340def679154dbcee66df7e80ce2dd0d")]
    public long Part1(string input)
    {
        var (cardInput, doorInput) = input.Split(LineBreaks.Single);
        var cardPublicKey = long.Parse(cardInput);
        var doorPublicKey = long.Parse(doorInput);

        var cardLoopSize = GetLoopSize(cardPublicKey);
        return GetKey(cardLoopSize, doorPublicKey);
    }

    private static long GetLoopSize(long publicKey)
    {
        long value = 1;
        long loopSize = 1;
        while (true)
        {
            value = Transform(value, SubjectNumber);
            if (value == publicKey)
                return loopSize;

            loopSize++;
        }
    }

    private static long GetKey(long loopSize, long publicKey)
    {
        long value = 1;
        for (var i = 0; i < loopSize; i++)
            value = Transform(value, publicKey);

        return value;
    }

    private static long Transform(long value, long subjectNumber) => value * subjectNumber % DivideBy;
}