using System.Linq;

namespace Core.Computer
{
    public class IntCodeResult
    {
        private readonly int[] _memory;

        public string Output => string.Join(',', _memory.Select(o => o.ToString()));
        public int Integer => _memory[0];

        public IntCodeResult(int[] memory)
        {
            _memory = memory;
        }
    }
}