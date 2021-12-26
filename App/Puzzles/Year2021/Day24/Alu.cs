using System;
using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day24;

public class Alu
{
    private readonly IEnumerable<AluInstruction> _instructions;
    private readonly int[] _params1;
    private readonly int[] _params2;
    private readonly int[] _params3;

    public Alu(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        _instructions = lines.Select(ParseInstruction);
        _params1 = new[] { 1, 1, 1, 26, 1, 1, 26, 1, 1, 26, 26, 26, 26, 26 };
        _params2 = new[] { 12, 11, 11, -6, 15, 12, -9, 14, 14, -5, -9, -5, -2, -7 };
        _params3 = new[] { 4, 10, 10, 14, 6, 16, 1, 7, 8, 11, 8, 3, 1, 8 };
    }

    private AluInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var operation = parts[0];
        var a = parts[1][..1].ToCharArray().First();
        var b = parts.Length > 2 ? parts[2] : null;

        return new AluInstruction(operation, a, b);
    }

    public AluState Process(long input, Dictionary<char, long> memory = null)
    {
        var inputs = input.ToString().Select(o => int.Parse(o.ToString())).ToList();
        var state = new AluState(inputs, memory);

        foreach (var instruction in _instructions)
        {
            instruction.Execute(state);
        }

        return state;
    }

    public long Process2(long input)
    {
        var inputs = input.ToString().Select(o => int.Parse(o.ToString())).ToList();

        long z = 0;
        for (var i = 0; i < inputs.Count; i++)
        {
            z = ProcessInstruction(inputs[i], z, _params1[i], _params2[i], _params3[i]);
        }
        
        return z;
    }

    private long ProcessInstruction(int input, long z, int p1, int p2, int p3)
    {
        var z1 = (long)Math.Floor((double)z / p1);
        if (input == z % 26 + p2)
            return z1;

        return 26 * z1 + input + p3;
    }
}