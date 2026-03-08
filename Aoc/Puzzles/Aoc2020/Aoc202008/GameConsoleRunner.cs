using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202008;

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