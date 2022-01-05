using System;
using System.Text;

namespace Core.Puzzles.Year2016.Day09;

public class FileDecompressor
{
    public int DecompressedLengthV1 { get; }
    public long DecompressedLengthV2 { get; }

    public FileDecompressor(string input)
    {
        DecompressedLengthV1 = GetLengthV1(input);
        DecompressedLengthV2 = GetLengthV2(input);
    }

    private int GetLengthV1(string input)
    {
        var result = new StringBuilder();
        while (input.Length > 0)
        {
            var stringToMove = input.Substring(0, 1);
            input = input.Remove(0, 1);

            if (stringToMove == "(")
            {
                var instructionEndIndex = input.IndexOf(")", StringComparison.InvariantCulture);
                var instruction = input.Substring(0, instructionEndIndex);
                input = input.Remove(0, instructionEndIndex + 1);
                var instructionParts = instruction.Split('x');
                var charCount = int.Parse(instructionParts[0]);
                var repeatCount = int.Parse(instructionParts[1]);
                var str = input.Substring(0, charCount);
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
            var stringToMove = input.Substring(0, 1);
            input = input.Remove(0, 1);

            if (stringToMove == "(")
            {
                var instructionEndIndex = input.IndexOf(")", StringComparison.InvariantCulture);
                var instruction = input.Substring(0, instructionEndIndex);
                input = input.Remove(0, instructionEndIndex + 1);
                var instructionParts = instruction.Split('x');
                var charCount = int.Parse(instructionParts[0]);
                var repeatCount = int.Parse(instructionParts[1]);
                var str = input.Substring(0, charCount);
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