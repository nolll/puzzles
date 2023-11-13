namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201916;

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