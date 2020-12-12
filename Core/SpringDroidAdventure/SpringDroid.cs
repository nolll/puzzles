using System;
using System.Collections.Generic;
using System.Linq;
using Core.Computer;
using Core.Tools;

namespace Core.SpringDroidAdventure
{
    public class SpringDroid
    {
        private readonly ComputerInterface _computer;
        private readonly IList<string> _commands;
        private List<char> _currentCommand;

        public long HullDamage { get; private set; }

        public SpringDroid(string program, string script)
        {
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
            _currentCommand = new List<char>();
            _commands = PuzzleInputReader.ReadLines(script);
        }

        public void Run()
        {
            _computer.Start();
        }

        private long ReadInput()
        {
            if (!_currentCommand.Any())
            {
                if (_commands.Any())
                {
                    var nextCommand = _commands.First().ToCharArray().ToList();
                    nextCommand.Add((char)10);
                    _commands.RemoveAt(0);
                    _currentCommand = nextCommand;
                }
            }

            if (_currentCommand.Any())
            {
                var c = _currentCommand.First();
                _currentCommand.RemoveAt(0);
                return c;
            }

            return Console.Read();
        }

        private void WriteOutput(long output)
        {
            if (output > 200)
                HullDamage = output;
            //else
            //    Console.Write((char)output);
        }
    }
}