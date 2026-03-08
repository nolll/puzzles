using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201921;

public class SpringDroid
{
    private readonly IntCodeComputer _computer;
    private readonly IList<string> _commands;
    private List<char> _currentCommand;

    public long HullDamage { get; private set; }

    public SpringDroid(string program, string script)
    {
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        _currentCommand = [];
        _commands = script.Trim().Split(LineBreaks.Single).ToList();
    }

    public void Run() => _computer.Start();

    private long ReadInput()
    {
        if (_currentCommand.Count == 0)
        {
            if (_commands.Any())
            {
                var nextCommand = _commands.First().ToCharArray().ToList();
                nextCommand.Add((char)10);
                _commands.RemoveAt(0);
                _currentCommand = nextCommand;
            }
        }

        if (_currentCommand.Count != 0)
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

        return true;
    }
}