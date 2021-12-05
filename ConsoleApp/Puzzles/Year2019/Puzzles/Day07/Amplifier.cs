using Core.Computer;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day07
{
    public class Amplifier
    {
        private long _input;
        private bool _isStarted;
        private readonly IntCodeComputer _computer;

        public Amplifier NextAmp { get; set; }
        public int Phase { get; set; }
        public string Name { get; }
        public long Output { get; private set; }

        public Amplifier(string name, string memory)
        {
            Name = name;
            _computer = new ComputerInterface(memory, ComputerInput, ComputerOutput);
        }

        private long ComputerInput()
        {
            if (_isStarted)
                return _input;
            _isStarted = true;
            return Phase;
        }

        private void ComputerOutput(long output)
        {
            Output = output;
            NextAmp?.Start(output);
        }

        public void Start(long input)
        {
            _input = input;
            if(_isStarted)
                _computer.Resume();
            else
                _computer.Start();
        }
    }
}