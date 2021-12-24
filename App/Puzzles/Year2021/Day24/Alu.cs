using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day24;

public class Alu
{
    private readonly IEnumerable<AluInstruction> _instructions;

    public Alu(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        _instructions = lines.Select(ParseInstruction);
    }

    private AluInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var operation = parts[0];
        var a = parts[1][..1].ToCharArray().First();
        var b = parts.Length > 2 ? parts[2] : null;

        return new AluInstruction(operation, a, b);
    }

    public AluState Process(long input)
    {
        var inputs = input.ToString().Select(o => int.Parse(o.ToString())).ToList();
        var state = new AluState(inputs);

        foreach (var instruction in _instructions)
        {
            instruction.Execute(state);
        }

        return state;
    }
}