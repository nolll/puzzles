using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Springdroid Adventure")]
public class Aoc201921 : AocPuzzle
{
    [Puzzle("94b1bc03281d28814cbce9dd5bcc5806")]
    public long RunPart1(string input)
    {
        var walkingDroid = new SpringDroid(input, WalkProgram);
        walkingDroid.Run();
        return walkingDroid.HullDamage;
    }

    [Puzzle("4b70c64b560c7856fb229521380a084d")]
    public long Part2(string input)
    {
        var runningDroid = new SpringDroid(input, RunProgram);
        runningDroid.Run();
        return runningDroid.HullDamage;
    }
    
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

    private const string WalkProgram = """
                                       OR A T
                                       AND B T
                                       AND C T
                                       NOT T J
                                       AND D J
                                       WALK
                                       """;

    private const string RunProgram = """
                                      OR A T
                                      AND B T
                                      AND C T
                                      NOT T J
                                      OR E T
                                      OR H T
                                      AND T J
                                      AND D J
                                      RUN
                                      """;
}