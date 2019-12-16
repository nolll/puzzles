using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.FlawedFrequencyTransmission
{
    public class FrequencyAlgorithm
    {
        private readonly string _input;

        public FrequencyAlgorithm(string input)
        {
            _input = input;
        }

        public string Run(int phaseCount)
        {
            var result = Run(_input, phaseCount);
            return result.Substring(0, 8);
        }

        public string RunReal(int phaseCount)
        {
            var input = GetLongInput();
            var result = Run(input, phaseCount);
            var messageOffset = int.Parse(_input.Substring(0, 7).TrimStart('0'));
            return result.Substring(messageOffset, 8);
        }

        private string Run(string input, int phaseCount)
        {
            var list = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToList();
            for (var i = 0; i < phaseCount; i++)
            {
                list = RunPhase(list).ToList();
                Console.WriteLine(string.Join("", list));
            }

            return string.Join("", list);
        }

        private string GetLongInput()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 10000; i++)
            {
                sb.Append(_input);
            }
            return sb.ToString();
        }

        private IEnumerable<int> RunPhase(IList<int> inputList)
        {
            var basePattern = new[] { 0, 1, 0, -1 };
            var outputList = new List<int>();
            for (var i = 0; i < inputList.Count; i++)
            {
                var pattern = GetRowPattern(basePattern, i + 1).ToArray();
                var patternPos = 1;
                var sum = 0;
                foreach (var val in inputList)
                {
                    sum += val * pattern[patternPos];
                    patternPos += 1;
                    if (patternPos >= pattern.Length)
                        patternPos = 0;
                }

                var str = sum.ToString();
                str = str.Substring(str.Length - 1);
                outputList.Add(int.Parse(str));
                Console.Write(str);
            }

            return outputList;
        }

        private IEnumerable<int> GetRowPattern(IEnumerable<int> basePattern, int row)
        {
            foreach (var num in basePattern)
            {
                for (var i = 0; i < row; i++)
                {
                    yield return num;
                }
            }
        }
    }
}