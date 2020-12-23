using System;

namespace Core.DuelingGenerators
{
    public class Generator
    {
        private readonly int _validationMultiple;
        private const long Divisor = 2147483647;
        private readonly long _factor;
        
        public string BinaryLast16 => Convert.ToString(ShortLastValue, 2).PadLeft(16, '0');

        public long LastValue { get; private set; }
        public short ShortLastValue => (short) LastValue;
        public bool IsValid => LastValue % _validationMultiple == 0;

        public Generator(in long startValue, in long factor, in int validationMultiple)
        {
            LastValue = startValue;
            _factor = factor;
            _validationMultiple = validationMultiple;
        }

        public void Process()
        {
            var product = LastValue * _factor;
            LastValue = product % Divisor;
        }
    }
}