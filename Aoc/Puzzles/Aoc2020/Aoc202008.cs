using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Handheld Halting")]
public class Aoc202008 : AocPuzzle
{
    [Puzzle("2a2e64378fc4cf027efb60009544e68b")]
    public int Part1(string input)
    {
        var instructions = ParseInstructions(input);
        var console = new GameConsole(instructions);
        return console.Run().ExitValue;
    }

    [Puzzle("e903a634ebeec273f64636f8b241c21b")]
    public int Part2(string input)
    {
        var instructionCount = input.Split(LineBreaks.Single).Length;
        for (var i = 0; i < instructionCount; i++)
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

    private static IList<GameConsoleInstruction> ParseInstructions(string input) =>
        input.Split(LineBreaks.Single).Select(GameConsoleInstruction.Parse).ToList();

    private enum ExitStatus
    {
        End,
        Loop
    }

    private class GameConsole(IList<GameConsoleInstruction> instructions)
    {
        private int _acc;
        private int _pos;

        public GameConsoleExit Run()
        {
            var wasRun = true;
            while (wasRun)
            {
                if (_pos >= instructions.Count)
                    return new GameConsoleExit(ExitStatus.End, _acc);
                wasRun = RunInstruction(instructions[_pos]);
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
            }

            _pos += 1;
            return true;
        }
    }

    private record GameConsoleExit(ExitStatus Status, int ExitValue);

    public class GameConsoleInstruction(string name, int value)
    {
        public string Name { get; } = name;
        public int Value { get; } = value;
        public int ExecutionCount { get; private set; }

        public static GameConsoleInstruction Parse(string s)
        {
            var parts = s.Split(' ');
            var name = parts[0];
            var value = int.Parse(parts[1]);
            return new GameConsoleInstruction(name, value);
        }

        public void IncreaseExecutionCount() => ExecutionCount += 1;
    }
}