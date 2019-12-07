using Core.Computer;

namespace Core.Thrust
{
    public class Amplifier
    {
        private int _firstInput;
        private int _secondInput;
        private int _inputCount;
        private int _output;
        private readonly IntCodeComputer _computer;

        public Amplifier(string memory)
        {
            _computer = new AmplifierComputer(memory, ComputerInput, ComputerOutput);
        }

        private int ComputerInput()
        {
            _inputCount++;
            if (_inputCount == 1)
                return _firstInput;
            return _secondInput;
        }

        private void ComputerOutput(int output)
        {
            _output = output;
        }

        public int GetOutput(int firstInput, int secondInput)
        {
            _firstInput = firstInput;
            _secondInput = secondInput;
            _inputCount = 0;
            _output = 0;
            _computer.Run();
            return _output;
        }
    }
}