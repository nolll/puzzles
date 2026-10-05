using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Memory Reallocation")]
public class Aoc201706 : AocPuzzle
{
    [Puzzle("5cc5e4c13f678b66cbe8e4c449049395")]
    public int Part1(string input)
    {
        var (steps, _) = Run(input);
        return steps;
    }

    [Puzzle("9db0fcedbdf5df5cc87a97b23d4e1414")]
    public int Part2(string input)
    {
        var (_, loopSize) = Run(input);
        return loopSize;
    }
    
    public (int, int) Run(string input)
    {
        var steps = 0;
        var loopSize = 0;
        var banks = input.Replace('\t', ',').Split(',').Select(int.Parse).ToList();
        var earlierStates = new List<string>();
        while (true)
        {
            var index = GetNextIndex(banks);
            var blocks = banks[index];
            banks[index] = 0;
            while (blocks > 0)
            {
                index += 1;
                if (index >= banks.Count)
                    index = 0;
                banks[index] += 1;
                blocks -= 1;
            }

            steps += 1;
            var currentState = string.Join(',', banks);
            if (earlierStates.Contains(currentState))
            {
                var earlierStateIndex = earlierStates.IndexOf(currentState);
                loopSize = earlierStates.Count - earlierStateIndex;
                break;
            }

            earlierStates.Add(currentState);
        }

        return (steps, loopSize);
    }   

    private static int GetNextIndex(List<int> banks)
    {
        var max = 0;
        var maxIndex = 0;
        for (var i = 0; i < banks.Count; i++)
        {
            if (banks[i] <= max)
                continue;
                
            max = banks[i];
            maxIndex = i;
        }

        return maxIndex;
    }
}