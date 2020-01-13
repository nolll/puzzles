using System;
using System.Text;

namespace Core.ExperimentalCompression
{
    public class FileDecompressor
    {
        public string Decompressed { get; }

        public FileDecompressor(string input)
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

                if(!string.IsNullOrWhiteSpace(stringToMove))
                    result.Append(stringToMove);
            }

            Decompressed = result.ToString();
        }
    }
}