using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Spinlock")]
public class Aoc201717 : AocPuzzle
{
    [Puzzle("ddce3b9888bd1dd2364ae8ba030b674f")]
    public int Part1(string input)
    {
        var runner1 = new SpinlockRunnerPart1(int.Parse(input));
        runner1.Run(2017);
        return runner1.NextValue;
    }

    [Puzzle("9d9ce3fec64cbea9caf918562df54fe4")]
    public int Part2(string input)
    {
        var runner2 = new SpinlockRunnerPart2(int.Parse(input));
        runner2.Run(50_000_000);
        return runner2.SecondValue;
    }
    
    public class SpinlockRunnerPart1
    {
        private readonly int _steps;
        private readonly LinkedList<int> _list;
        private LinkedListNode<int> _current;

        public int NextValue => _current.Next?.Value ?? 0;
        public int SecondValue => _list.First?.Next?.Value ?? 0;

        public SpinlockRunnerPart1(int steps)
        {
            _steps = steps;
            _list = new LinkedList<int>();
            _current = _list.AddLast(0);
        }

        public void Run(int target)
        {
            var v = 1;
            while (v <= target)
            {
                for (var i = 0; i < _steps; i++)
                {
                    _current = _current.NextOrFirst();
                }

                _current = _list.AddAfter(_current, v);
                v++;
            }
        }
    }
    
    public class SpinlockRunnerPart2
    {
        private readonly int _steps;
        public int SecondValue { get; private set; }

        public SpinlockRunnerPart2(int steps)
        {
            _steps = steps;
            SecondValue = 0;
        }

        public void Run(int target)
        {
            var v = 1;
            var pos = 0;
            while (v <= target)
            {
                pos += _steps;
                while (pos > v - 1) 
                    pos -= v;

                if (pos == 0)
                    SecondValue = v;
                pos++;
                v++;
            }
        }
    }
}