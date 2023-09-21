using common.Strings;

namespace Aoc.Puzzles.Year2020.Day25;

public class EncryptionKeyFinder
{
    private const int DivideBy = 20_201_227;
    private readonly long _cardPublicKey;
    private readonly long _doorPublicKey;

    public EncryptionKeyFinder(string input)
    {
        var rows = PuzzleInputReader.ReadLines(input);
        _cardPublicKey = long.Parse(rows[0]);
        _doorPublicKey = long.Parse(rows[1]);
    }

    public long FindKey()
    {
        var cardLoopSize = GetLoopSize(_cardPublicKey);
        var key = GetKey(cardLoopSize, _doorPublicKey);
        return key;
    }

    private long GetLoopSize(long publicKey)
    {
        long value = 1;
        const long subjectNumber = 7;
        long loopSize = 1;
        while (true)
        {
            value = Transform(value, subjectNumber);
            if (value == publicKey)
                return loopSize;

            loopSize++;
        }
    }

    private long GetKey(long loopSize, long publicKey)
    {
        long value = 1;
        var subjectNumber = publicKey;
        for (var i = 0; i < loopSize; i++)
        {
            value = Transform(value, subjectNumber);
        }

        return value;
    }

    private static long Transform(long value, long subjectNumber)
    {
        return (value * subjectNumber) % DivideBy;
    }
}