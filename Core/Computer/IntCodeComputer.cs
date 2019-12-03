using System.Linq;

namespace Core.Computer
{
    public class IntCodeComputer
    {
        private readonly int[] _startMemory;

        public IntCodeComputer(string input)
        {
            _startMemory = GetStartMemory(input);
        }

        public IntCodeResult Run(int? noun = null, int? verb = null)
        {
            var memory = CopyMemory(_startMemory);
            if (noun != null) memory[1] = noun.Value;
            if(verb != null) memory[2] = verb.Value;
            return new IntCodeProcess(memory).Run();
        }

        private int[] CopyMemory(int[] memory)
        {
            var copy = new int[memory.Length];
            for (var i = 0; i < memory.Length; i++)
            {
                copy[i] = memory[i];
            }

            return copy;
        }

        private static int[] GetStartMemory(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(int.Parse).ToArray();
        }
    }
}