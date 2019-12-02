namespace Core.Computer
{
    public class IntCodeProcess
    {
        private readonly int[] _memory;
        private int _pointer;

        public IntCodeProcess(int[] memory)
        {
            _memory = memory;
            _pointer = 0;
        }

        public IntCodeResult Run()
        {
            while (_pointer < _memory.Length)
            {
                var instruction = GetInstruction(_memory[_pointer]);

                if (instruction == IntCodeInstruction.End)
                    break;

                if (instruction == IntCodeInstruction.Unknown)
                    throw new UnknownInstructionException();

                PerformOperation(instruction);
                IncrementPointer();
            }

            return new IntCodeResult(_memory);
        }

        private void PerformOperation(IntCodeInstruction instruction)
        {
            var a = _memory[_pointer + 1];
            var b = _memory[_pointer + 2];
            var c = _memory[_pointer + 3];
            _memory[c] = instruction == IntCodeInstruction.Add
                ? Add(a, b)
                : Multiply(a, b);
        }

        private int Add(int a, int b) => _memory[a] + _memory[b];
        private int Multiply(int a, int b) => _memory[a] * _memory[b];
        private void IncrementPointer() => _pointer += 4;
        private static IntCodeInstruction GetInstruction(int num) => (IntCodeInstruction)num;
    }
}