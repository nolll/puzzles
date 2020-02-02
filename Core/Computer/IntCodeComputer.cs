using System.Collections;
using System.Collections.Generic;

namespace Core.Computer
{
    public abstract class IntCodeComputer
    {
        private readonly IList<long> _startMemory;
        private IntCodeProcess _process;

        public long Result => _process.Result;

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

        public void SetMemory(int address, int value)
        {
            _startMemory[address] = value;
        }

        public void Resume()
        {
            _process.Run();
        }

        public void Stop()
        {
            _process.Stop();
        }

        public IList<long> Memory => _process.Memory;

        protected abstract long ReadInput();
        protected abstract void WriteOutput(long output);

        private static IList<long> CopyMemory(IList<long> memory)
        {
            var copy = new List<long>();
            for (var i = 0; i < memory.Count; i++)
            {
                copy.Add(memory[i]);
            }

            return copy;
        }
    }
}