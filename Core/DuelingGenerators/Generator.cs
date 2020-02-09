using System;

namespace Core.DuelingGenerators
{
    public class Generator
    {
        private const long Divisor = 2147483647;

        public long StartValue { get; }
        public long Factor { get; }
        public long LastValue { get; private set; }
        public string BinaryString => Convert.ToString(LastValue, 2).PadLeft(32, '0');
        public string BinaryLast16 => BinaryString.Substring(16);

        public Generator(in long startValue, in long factor)
        {
            StartValue = startValue;
            Factor = factor;
            LastValue = startValue;
        }

        public void Process()
        {
            var product = LastValue * Factor;
            LastValue = product % Divisor;
        }
    }
}