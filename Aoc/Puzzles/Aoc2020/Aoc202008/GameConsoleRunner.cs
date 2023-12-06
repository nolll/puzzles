using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202008;

public class GameConsoleRunner
{
    private readonly string _input;
    private readonly int _instructionCount;

    public GameConsoleRunner(string input)
    {
        _input = input;
        _instructionCount = StringReader.ReadLines(input).Count;
    }

    public static IList<GameConsoleInstruction> ParseInstructions(string input)
    {
        var rows = StringReader.ReadLines(input);
        return rows.Select(GameConsoleInstruction.Parse).ToList();
    }

    public int RunUntilLoop()
    {
        var instructions = ParseInstructions(_input);
        var console = new GameConsole(instructions);
        return console.Run().ExitValue;
    }

    public int RunUntilTermination()
    {
        for (var i = 0; i < _instructionCount; i++)
        {
            var instructions = ParseInstructions(_input);
            var currentInstruction = instructions[i];
            if (currentInstruction.Name == "acc")
                continue;

            if (currentInstruction.Name == "nop" || currentInstruction.Name == "jmp")
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