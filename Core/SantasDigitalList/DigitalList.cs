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
            s = s.Trim('"');
            s = s.Replace("\\\"", "\"");
            s = s.Replace("\\\\", "\\");

            while (s.Contains("\\x"))
            {
                var ascii = s.Substring(s.IndexOf("\\x"), 4);
                s = s.Replace(ascii, "-");
            }

            return s.Length;
        }
    }
}