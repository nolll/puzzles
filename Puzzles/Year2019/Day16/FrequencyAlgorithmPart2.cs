using System;
using System.Linq;
using System.Text;

namespace Aoc.Puzzles.Year2019.Day16;

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