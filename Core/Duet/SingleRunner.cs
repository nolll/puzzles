using System.Collections.Generic;
using Core.Tools;

namespace Core.Duet
{
    public class SingleRunner
    {
        private readonly IList<string> _operations;

        public long RecoveredFrequency { get; private set; }

        public SingleRunner(string input)
        {
            _operations = PuzzleInputReader.Read(input);
        }

        public void Run()
        {
            var program = new DuetProgramPart1(_operations);
            RecoveredFrequency = program.FindFrequency();
        }
    }
}