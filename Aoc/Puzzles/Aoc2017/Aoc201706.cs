using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Memory Reallocation")]
public class Aoc201706 : AocPuzzle
{
    [Puzzle("5cc5e4c13f678b66cbe8e4c449049395")]
    public int Part1(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return reallocator.Steps;
    }

    [Puzzle("9db0fcedbdf5df5cc87a97b23d4e1414")]
    public int Part2(string input)
    {
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();
        return reallocator.LoopSize;
    }
    
    public class MemoryReallocator
    {
        private readonly IList<int> _banks;

        public int Steps { get; private set; }
        public int LoopSize { get; private set; }

        public MemoryReallocator(string input)
        {
            _banks = input.Replace('\t', ',').Split(',').Select(int.Parse).ToList();
        }

        public void Run()
        {
            Steps = 0;
            var earlierStates = new List<string>();
            while (true)
            {
                var index = GetNextIndex();
                var blocks = _banks[index];
                _banks[index] = 0;
                while (blocks > 0)
                {
                    index += 1;
                    if (index >= _banks.Count)
                        index = 0;
                    _banks[index] += 1;
                    blocks -= 1;
                }

                Steps += 1;
                var currentState = string.Join(',', _banks);
                if (earlierStates.Contains(currentState))
                {
                    var earlierStateIndex = earlierStates.IndexOf(currentState);
                    LoopSize = earlierStates.Count - earlierStateIndex;
                    break;
                }

                earlierStates.Add(currentState);
            }
        }   

        private int GetNextIndex()
        {
            var max = 0;
            var maxIndex = 0;
            for (var i = 0; i < _banks.Count; i++)
            {
                if (_banks[i] > max)
                {
                    max = _banks[i];
                    maxIndex = i;
                }

            }

            return maxIndex;
        }
    }
}