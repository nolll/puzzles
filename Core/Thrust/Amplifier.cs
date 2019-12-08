using Core.Computer;

namespace Core.Thrust
{
    public class Amplifier
    {
        private int _input;
        private bool _isStarted;
        private int _output;
        private readonly IntCodeComputer _computer;

        public Amplifier NextAmp { get; set; }
        public int Phase { get; set; }

        public Amplifier(string memory)
        {
            _computer = new AmplifierComputer(memory, ComputerInput, ComputerOutput);
        }

        private int ComputerInput()
        {
            if (_isStarted)
                return _input;
            _isStarted = true;
            return Phase;
        }

        private void ComputerOutput(int output)
        {
            _output = NextAmp?.GetOutput(output) ?? output;
        }

        public int GetOutput(int input)
        {
            _input = input;
            _computer.Run();
            return _output;
        }
    }
}