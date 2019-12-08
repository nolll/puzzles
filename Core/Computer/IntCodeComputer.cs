namespace Core.Computer
{
    public abstract class IntCodeComputer
    {
        private readonly int[] _startMemory;
        private IntCodeProcess _process;

        public int Result => _process.Result;

        protected IntCodeComputer(string input)
        {
            _startMemory = MemoryParser.Parse(input);
        }

        public void Start(int? noun = null, int? verb = null)
        {
            var memory = CopyMemory(_startMemory);
            if (noun != null) memory[1] = noun.Value;
            if(verb != null) memory[2] = verb.Value;
            _process = new IntCodeProcess(memory, ReadInput, WriteOutput);
            _process.Run();
        }

        public void Resume()
        {
            _process.Run();
        }

        protected abstract int ReadInput();
        protected abstract void WriteOutput(int output);

        private static int[] CopyMemory(int[] memory)
        {
            var copy = new int[memory.Length];
            for (var i = 0; i < memory.Length; i++)
            {
                copy[i] = memory[i];
            }

            return copy;
        }
    }
}