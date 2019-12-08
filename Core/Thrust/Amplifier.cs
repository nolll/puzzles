using System;
using Core.Computer;

namespace Core.Thrust
{
    public class Amplifier
    {
        private int _input;
        private bool _isStarted;
        private readonly IntCodeComputer _computer;

        public Amplifier NextAmp { get; set; }
        public int Phase { get; set; }
        public string Name { get; }
        public int Output { get; private set; }

        public Amplifier(string name, string memory)
        {
            Name = name;
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
            Output = output;
            Console.WriteLine($"{Name} output: {output}");
            NextAmp?.Start(output);
        }

        public void Start(int input)
        {
            _input = input;
            if(_isStarted)
                _computer.Resume();
            else
                _computer.Start();
        }
    }
}