using System.Collections.Generic;

namespace Core.Computer
{
    public class BoostTester
    {
        private long _lastOutput;
        private IList<long> _outputs;

        public Result Run(string program)
        {
            _outputs = new List<long>();

            var computer = new AmplifierComputer(program, ReadInput, WriteOutput);
            computer.Start();

            return new Result(_lastOutput, _outputs);
        }

        public long ReadInput()
        {
            return 1;
        }

        public void WriteOutput(long output)
        {
            _lastOutput = output;
            _outputs.Add(output);
        }

        public class Result
        {
            public long LastOutput { get; }
            public IList<long> AllOutputs { get; }

            public Result(long lastOutput, IList<long> allOutputs)
            {
                AllOutputs = allOutputs;
                LastOutput = lastOutput;
            }
        }
    }
}