using System;

namespace Core.Spinlock
{
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
                pos = (pos - 1) % v;
                if (pos == 0)
                    SecondValue = v;
                Console.WriteLine($"pos {pos} == {v}. second == {SecondValue}");
                v++;
            }
        }
    }
}