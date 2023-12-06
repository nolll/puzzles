using Puzzles.Common.Computers.IntCode;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2019.Aoc201921;

public class SpringDroid
{
    private readonly IntCodeComputer _computer;
    private readonly IList<string> _commands;
    private List<char> _currentCommand;

    public long HullDamage { get; private set; }

    public SpringDroid(string program, string script)
    {
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        _currentCommand = new List<char>();
        _commands = InputReader.ReadLines(script.Trim());
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

    private bool WriteOutput(long output)
    {
        if (output > 200)
            HullDamage = output;
        //else
        //    Console.Write((char)output);

        return true;
    }
}