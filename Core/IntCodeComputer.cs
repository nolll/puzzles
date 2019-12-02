using System.Linq;

namespace Core
{
    public class IntCodeComputer
    {
        private readonly int[] _integers;

        public IntCodeComputer(string input)
        {
            _integers = GetIntegers(input);

            var pos = 0;
            while (pos < _integers.Length)
            {
                var opCode = _integers[pos];

                if (opCode == 1)
                {
                    var pos1 = _integers[pos + 1];
                    var pos2 = _integers[pos + 2];
                    var pos3 = _integers[pos + 3];
                    _integers[pos3] = _integers[pos1] + _integers[pos2];
                }
                else if (opCode == 2)
                {
                    var pos1 = _integers[pos + 1];
                    var pos2 = _integers[pos + 2];
                    var pos3 = _integers[pos + 3];
                    _integers[pos3] = _integers[pos1] * _integers[pos2];
                }
                else if (opCode == 99)
                {
                    break;
                }
                else
                {
                    throw new UnknownOpcodeException(opCode);
                }

                pos += 4;
            }
        }

        public string GetOutput()
        {
            return string.Join(',', _integers.Select(o => o.ToString()));
        }

        public int GetFirstPos()
        {
            return _integers[0];
        }

        private int[] GetIntegers(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(int.Parse).ToArray();
        }
    }
}