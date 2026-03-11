using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler026;

[Name("Reciprocal cycles")]
public class Euler026 : EulerPuzzle
{
    [Puzzle("dbf66eed8ad4924ee0ac82e9f5354934")]
    public int Solve() => Solve(999);

    public int Solve(int maxDivisor)
    {
        var sequenceLength = 0;
        var numberWithlongestSequence = 0;

        for (var i = maxDivisor; i > 1; i--)
        {
            if (sequenceLength >= i)
                break;

            var foundRemainders = new int[i];
            var value = 1;
            var position = 0;

            while (foundRemainders[value] == 0 && value != 0)
            {
                foundRemainders[value] = position;
                value *= 10;
                value %= i;
                position++;
            }

            if (position - foundRemainders[value] <= sequenceLength)
                continue;
            
            sequenceLength = position - foundRemainders[value];
            numberWithlongestSequence = i;
        }

        return numberWithlongestSequence;
    }
}