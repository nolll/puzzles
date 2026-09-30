using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Explosives in Cyberspace")]
public class Aoc201609 : AocPuzzle
{
    [Puzzle("963b04cd929c376aa9a75d813a774205")]
    public int Part1(string input) => GetLengthV1(input);

    [Puzzle("bfe4afdea90f1f177895b3bbde55f5a5")]
    public long Part2(string input) => GetLengthV2(input);

    private int GetLengthV1(string input)
    {
        var result = new StringBuilder();
        while (input.Length > 0)
        {
            var stringToMove = input[..1];
            input = input.Remove(0, 1);

            if (stringToMove == "(")
            {
                var instructionEndIndex = input.IndexOf(')');
                var instruction = input[..instructionEndIndex];
                input = input.Remove(0, instructionEndIndex + 1);
                var instructionParts = instruction.Split('x');
                var charCount = int.Parse(instructionParts[0]);
                var repeatCount = int.Parse(instructionParts[1]);
                var str = input[..charCount];
                input = input.Remove(0, charCount);
                var repeatStr = new StringBuilder();
                for (var i = 0; i < repeatCount; i++)
                {
                    repeatStr.Append(str);
                }

                stringToMove = repeatStr.ToString();
            }

            if (!string.IsNullOrWhiteSpace(stringToMove))
                result.Append(stringToMove);
        }

        return result.ToString().Length;
    }

    private long GetLengthV2(string input)
    {
        long length = 0;
        while (input.Length > 0)
        {
            var stringToMove = input[..1];
            input = input.Remove(0, 1);

            if (stringToMove == "(")
            {
                var instructionEndIndex = input.IndexOf(')');
                var instruction = input[..instructionEndIndex];
                input = input.Remove(0, instructionEndIndex + 1);
                var instructionParts = instruction.Split('x');
                var charCount = int.Parse(instructionParts[0]);
                var repeatCount = int.Parse(instructionParts[1]);
                var str = input[..charCount];
                input = input.Remove(0, charCount);
                length += repeatCount * GetLengthV2(str);
            }
            else
            {
                length += 1;
            }
        }

        return length;
    }
}