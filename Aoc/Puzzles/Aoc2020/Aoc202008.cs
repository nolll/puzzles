using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Handheld Halting")]
public class Aoc202008 : AocPuzzle
{
    [Puzzle("2a2e64378fc4cf027efb60009544e68b")]
    public int Part1(string input) => new GameConsoleRunner(input).RunUntilLoop();

    [Puzzle("e903a634ebeec273f64636f8b241c21b")]
    public int Part2(string input) => new GameConsoleRunner(input).RunUntilTermination();
    
    public class GameConsoleRunner(string input)
    {
        private readonly int _instructionCount = input.Split(LineBreaks.Single).Length;

        public static IList<GameConsoleInstruction> ParseInstructions(string input)
        {
            var rows = input.Split(LineBreaks.Single);
            return rows.Select(GameConsoleInstruction.Parse).ToList();
        }

        public int RunUntilLoop()
        {
            var instructions = ParseInstructions(input);
            var console = new GameConsole(instructions);
            return console.Run().ExitValue;
        }

        public int RunUntilTermination()
        {
            for (var i = 0; i < _instructionCount; i++)
            {
                var instructions = ParseInstructions(input);
                var currentInstruction = instructions[i];
                if (currentInstruction.Name == "acc")
                    continue;

                if (currentInstruction.Name is "nop" or "jmp")
                {
                    var newName = currentInstruction.Name == "nop" ? "jmp" : "nop";
                    instructions[i] = new GameConsoleInstruction(newName, currentInstruction.Value);
                }

                var console = new GameConsole(instructions);
                var exit = console.Run();
                if (exit.Status == ExitStatus.End)
                    return exit.ExitValue;
            }

            return 0;
        }
    }
    
    public enum ExitStatus
    {
        End,
        Loop
    }
    
    public class GameConsole
    {
        private readonly IList<GameConsoleInstruction> _instructions;
        private int _acc;
        private int _pos;

        public GameConsole(IList<GameConsoleInstruction> instructions)
        {
            _instructions = instructions;
        }

        public GameConsoleExit Run()
        {
            var wasRun = true;
            while (wasRun)
            {
                if(_pos >= _instructions.Count)
                    return new GameConsoleExit(ExitStatus.End, _acc);
                wasRun = RunInstruction(_instructions[_pos]);
            }

            return new GameConsoleExit(ExitStatus.Loop, _acc);
        }

        private bool RunInstruction(GameConsoleInstruction instruction)
        {
            if (instruction.ExecutionCount == 1)
                return false;

            instruction.IncreaseExecutionCount();

            if (instruction.Name == "jmp")
            {
                _pos += instruction.Value;
                return true;
            }

            if (instruction.Name == "acc")
            {
                _acc += instruction.Value;
                _pos += 1;
                return true;
            }

            _pos += 1;
            return true;
        }
    }
    
    public class GameConsoleExit
    {
        public ExitStatus Status { get; }
        public int ExitValue { get; }

        public GameConsoleExit(ExitStatus status, int exitValue)
        {
            Status = status;
            ExitValue = exitValue;
        }
    }
    
    public class GameConsoleInstruction
    {
        public string Name { get; }
        public int Value { get; }
        public int ExecutionCount { get; private set; }

        public GameConsoleInstruction(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static GameConsoleInstruction Parse(string s)
        {
            var parts = s.Split(' ');
            var name = parts[0];
            var value = int.Parse(parts[1]);
            return new GameConsoleInstruction(name, value);
        }

        public void IncreaseExecutionCount()
        {
            ExecutionCount += 1;
        }
    }
}