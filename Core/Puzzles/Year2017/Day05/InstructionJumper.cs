using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2017.Day05
{
    public class InstructionJumper
    {
        private int _index;
        private readonly List<int> _numbers;
        private bool IsInRange => _index >= 0 && _index < _numbers.Count;

        public int StepCount { get; private set; }

        public InstructionJumper(string input)
        {
            StepCount = 0;
            _numbers = input.Trim().Split('\n').Select(o => int.Parse((string) o.Trim())).ToList();
        }

        public void Start1()
        {
            while (IsInRange)
            {
                var val = _numbers[_index];
                _numbers[_index] = val + 1;
                _index += val;
                StepCount += 1;
            }
        }

        public void Start2()
        {
            while (IsInRange)
            {
                var val = _numbers[_index];
                var change = val >= 3 ? -1 : 1;
                _numbers[_index] = val + change;
                _index += val;
                StepCount += 1;
            }
        }
    }
}