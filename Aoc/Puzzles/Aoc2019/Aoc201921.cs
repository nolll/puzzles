using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Springdroid Adventure")]
public class Aoc201921 : AocPuzzle
{
    [Puzzle("94b1bc03281d28814cbce9dd5bcc5806")]
    public long RunPart1(string input) => Run(input, WalkProgram);

    [Puzzle("4b70c64b560c7856fb229521380a084d")]
    public long Part2(string input) => Run(input, RunProgram);

    private long Run(string program, string script)
    {
        var damage = 0L;
        List<char> currentCommand = [];
        var commands = script.Trim().Split(LineBreaks.Single).ToList();
        var computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        computer.Start();

        return damage;

        long ReadInput()
        {
            if (currentCommand.Count == 0 && commands.Count != 0)
            {
                var nextCommand = commands.First().ToCharArray().ToList();
                nextCommand.Add((char)10);
                commands.RemoveAt(0);
                currentCommand = nextCommand;
            }

            if (currentCommand.Count != 0)
            {
                var c = currentCommand.First();
                currentCommand.RemoveAt(0);
                return c;
            }

            return Console.Read();
        }

        bool WriteOutput(long output)
        {
            if (output > 200)
                damage = output;

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