using System.Text;
using Core.Computer;

namespace Core.Scaffolding
{
    public class ScaffoldingComputer
    {
        private readonly ComputerInterface _computer;
        private readonly StringBuilder _sb;

        public ScaffoldingComputer(string program)
        {
            _sb = new StringBuilder();
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
        }

        public string Run()
        {
            _computer.Start();
            return _sb.ToString();
        }

        private long ReadInput()
        {
            return 0;
        }

        private void WriteOutput(long output)
        {
            _sb.Append((char)output);
        }
    }
}