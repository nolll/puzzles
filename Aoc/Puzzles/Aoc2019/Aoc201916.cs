using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Flawed Frequency Transmission")]
public class Aoc201916 : AocPuzzle
{
    [Puzzle("e995b448fd31fb067432b47f11ac0e67")]
    public string Part1(string input) => new FrequencyAlgorithmPart1(input).Run(100);

    [Puzzle("0b00b51e4f1b1d517a2bb16008f7af58")]
    public string Part2(string input) => new FrequencyAlgorithmPart2(input).Run(100);
    
    public class FrequencyAlgorithmPart1
    {
        private readonly string _input;
        private readonly int[] _basePattern = { 0, 1, 0, -1 };

        public FrequencyAlgorithmPart1(string input)
        {
            _input = input;
        }

        public string Run(int phaseCount)
        {
            var result = Run(_input, phaseCount);
            return result.Substring(0, 8);
        }

        private string Run(string input, int phaseCount)
        {
            var list = input.ToCharArray().Select(o => int.Parse((string) o.ToString())).ToArray();
            for (var i = 0; i < phaseCount; i++)
            {
                list = RunPhase(list);
            }

            return string.Join("", list);
        }

        private int[] RunPhase(int[] inputList)
        {
            var outputList = new int[inputList.Length];
            for (var i = 0; i < inputList.Length; i++)
            {
                var pos = i;
                var patternPos = 0;
                var sum = 0;
                foreach (var val in inputList)
                {
                    var calculatedPatternValue = GetPatternValue(pos + 1, patternPos);
                    sum += val * calculatedPatternValue;
                    patternPos += 1;
                }

                outputList[i] = Math.Abs(sum % 10);
            }

            return outputList;
        }

        private int GetPatternValue(int iteration, int patternPos)
        {
            var pos = (int)Math.Floor((double)((patternPos + 1) % (4 * iteration)) / iteration);
            return _basePattern[pos];
        }
    }
    
    public class FrequencyAlgorithmPart2
    {
        private readonly string _input;
        private readonly int[] _basePattern = { 0, 1, 0, -1 };

        public FrequencyAlgorithmPart2(string input)
        {
            _input = input;
        }

        public string Run(int phaseCount)
        {
            var input = GetLongInput();
            var offset = int.Parse(input.Substring(0, 7).TrimStart('0'));
            var result = Run(input, phaseCount, offset);
            return result.Substring(0, 8);
        }

        private string Run(string input, int phaseCount, int offset)
        {
            var list = input.ToCharArray().Select(o => int.Parse((string) o.ToString())).Skip(offset).ToArray();
            for (var i = 0; i < phaseCount; i++)
            {
                list = RunPhase(list);
            }

            return string.Join("", list);
        }

        private int[] RunPhase(int[] inputList)
        {
            var runningSum = 0;
            var outputList = new int[inputList.Length];
            for (var i = inputList.Length - 1; i >= 0; i--)
            {
                runningSum += inputList[i];
                outputList[i] = Math.Abs(runningSum % 10);
            }

            return outputList;
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
    }
}