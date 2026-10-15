using System.Text;
using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Cryostasis")]
public class Aoc201925 : AocPuzzle
{
    [Puzzle("378fea8b73ddddacf10ae3b5978e47ab")]
    public string Part1(string input)
    {
        Queue<char> currentCommand = [];
        var output = new StringBuilder();
        var commands = new Queue<string>(GetCommands());
        var computer = new IntCodeComputer(input, ReadInput, WriteOutput);
        computer.Start();

        var lastSentence = output.ToString().Trim().Split(LineBreaks.Single).Last().Trim();
        return lastSentence.Split(' ')[11];

        long ReadInput()
        {
            if (currentCommand.Count == 0 && commands.Count != 0)
            {
                var nextCommand = new Queue<char>(commands.Dequeue());
                nextCommand.Enqueue((char)10);
                currentCommand = nextCommand;
            }

            return currentCommand.Count != 0 
                ? currentCommand.Dequeue()
                : Console.Read();
        }

        bool WriteOutput(long o)
        {
            output.Append((char)o);
            return true;
        }
    }

    private static string[] GetCommands() =>
    [
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
        "north",
        .. GetBruteForceCommands()
    ];

    private static IList<string> GetBruteForceCommands()
    {
        string[] inv =
        [
            "polygon",
            "fixed point",
            "astronaut ice cream",
            "easter egg",
            "dark matter",
            "food ration",
            "asterisk",
            "weather machine"
        ];

        var commands = inv.Select(i => $"drop {i}").ToList();

        var permutations = CombinationGenerator.GetUniqueCombinationsMaxSize(inv, inv.Length);
        foreach (var perm in permutations)
        {
            commands.AddRange(perm.Select(i => $"take {i}"));
            commands.Add("north");
            commands.AddRange(perm.Select(i => $"drop {i}"));
        }

        return commands;
    }
}