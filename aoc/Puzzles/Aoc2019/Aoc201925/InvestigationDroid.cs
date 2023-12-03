using System.Text;
using Puzzles.Common.Computers.IntCode;

namespace Puzzles.Aoc.Puzzles.Aoc2019.Aoc201925;

public class InvestigationDroid
{
    private readonly IntCodeComputer _computer;
    private readonly List<string> _commands;
    private List<char> _currentCommand;
    private readonly StringBuilder _output = new();

    public InvestigationDroid(string program)
    {
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        _currentCommand = new List<char>();
        _commands = new List<string>
        {
            "west",
            "south",
            "south",
            "south",
            "take asterisk",
            "north",
            "north",
            "north",
            "west",
            "west",
            "west",
            "take dark matter",
            "east",
            "south",
            "take fixed point",
            "west",
            "take food ration",
            "east",
            "north",
            "east",
            "south",
            "take astronaut ice cream",
            "south",
            "take polygon",
            "east",
            "take easter egg",
            "east",
            "take weather machine",
            "north"
        };

        _commands.AddRange(GetBruteForceCommands());
    }

    private IList<string> GetBruteForceCommands()
    {
        var inv = new List<string>
        {
            "polygon",
            "fixed point",
            "astronaut ice cream",
            "easter egg",
            "dark matter",
            "food ration",
            "asterisk",
            "weather machine"
        };

        var commands = new List<string>();
        foreach (var i in inv)
        {
            commands.Add($"drop {i}");
        }

        var permutations = Permutations(inv);
        foreach (var perm in permutations)
        {
            foreach (var i in perm)
            {
                commands.Add($"take {i}");
            }

            commands.Add("north");

            foreach (var i in perm)
            {
                commands.Add($"drop {i}");
            }
        }

        return commands;
    }

    public static IEnumerable<T[]> Permutations<T>(IEnumerable<T> source)
    {
        if (null == source)
            throw new ArgumentNullException(nameof(source));

        T[] data = source.ToArray();

        return Enumerable
            .Range(0, 1 << (data.Length))
            .Select(index => data
                .Where((v, i) => (index & (1 << i)) != 0)
                .ToArray());
    }

    public string Run()
    {
        _computer.Start();

        var lastSentence = _output.ToString().Trim().Split('\n').Last().Trim();
        return lastSentence.Split(' ')[11];
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
        _output.Append((char)output);
        //Console.Write((char)output);
        return true;
    }
}