using System;
using System.Linq;
using Core.Tools;

namespace Core.SantasDigitalList
{
    public class DigitalList
    {
        public int CountDiff { get; }

        public DigitalList(string input)
        {
            var strings = PuzzleInputReader.Read(input);
            var codeCount = strings.Sum(CountCode);
            var memoryCount = strings.Sum(CountMemory);
            CountDiff = codeCount - memoryCount;
        }

        private int CountCode(string s)
        {
            return s.Length;
        }

        private int CountMemory(string s)
        {
            s = s.Remove(0, 1);
            s = s.Remove(s.Length - 1);

            while (s.Contains("\\"))
            {
                var backslashIndex = s.IndexOf("\\", StringComparison.InvariantCulture);
                var nextChar = s[backslashIndex + 1];
                var charactersToRemove = nextChar == '\"' || nextChar == '\\' ? 2 : 4;
                s = s.Remove(backslashIndex, charactersToRemove);
                s = s.Insert(backslashIndex, "-");
            }

            return s.Length;
        }
    }
}