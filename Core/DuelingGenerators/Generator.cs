using System;

namespace Core.DuelingGenerators
{
    public class Generator
    {
        private readonly int _validationMultiple;
        private const long Divisor = 2147483647;
        private readonly long _factor;
        private long _lastValue;
        
        private string BinaryString => Convert.ToString(_lastValue, 2).PadLeft(32, '0');
        
        public string BinaryLast16 => BinaryString.Substring(16);
        public bool IsValid => _lastValue % _validationMultiple == 0;

        public Generator(in long startValue, in long factor, in int validationMultiple)
        {
            _lastValue = startValue;
            _factor = factor;
            _validationMultiple = validationMultiple;
        }

        public void Process()
        {
            var product = _lastValue * _factor;
            _lastValue = product % Divisor;
        }
    }
}