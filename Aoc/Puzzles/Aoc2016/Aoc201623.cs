using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[IsSlow] // 28s for part 2
[Name("Safe Cracking")]
[Comment("Factorial of 12")]
public class Aoc201623 : AocPuzzle
{
    [Puzzle("11e66781d74c9188561ba3937d053d99")]
    public int Part1(string input) => RunPart1(input, 7, 0);

    [Puzzle("eb0c83e21e8bd77e7f0b5686e8f1c31a")]
    public int Part2(string input) => RunPart2(input, 12, 0);

    public int RunPart1(string input, int a, int c)
    {
        var instructions = Parse(input);
        var registers = new Dictionary<char, int>
        {
            ['a'] = a,
            ['b'] = 0,
            ['c'] = c,
            ['d'] = 0
        };
        var index = 0;

        while (index < instructions.Length)
        {
            var instruction = instructions[index];
            try
            {
                switch (instruction.Type)
                {
                    case InstructionType.Copy:
                    {
                        if (instruction.HasIntegerArg1)
                            registers[instruction.CharArg2] = instruction.IntegerArg1;
                        else
                            registers[instruction.CharArg2] = registers[instruction.CharArg1];

                        index++;
                        break;
                    }
                    case InstructionType.Increment:
                    {
                        registers[instruction.CharArg1]++;
                        index++;
                        break;
                    }
                    case InstructionType.Decrement:
                    {
                        registers[instruction.CharArg1]--;
                        index++;
                        break;
                    }
                    case InstructionType.Jump:
                    {
                        var steps = instruction.HasIntegerArg2 ? instruction.IntegerArg2 : registers[instruction.CharArg2];

                        if (instruction.HasIntegerArg1)
                            index += instruction.IntegerArg1 != 0 ? steps : 1;
                        else
                            index += registers[instruction.CharArg1] != 0 ? steps : 1;
                        break;
                    }
                    case InstructionType.Toggle:
                    {
                        var target = instruction.CharArg1;
                        var val = registers[target];
                        var indexToToggle = index + val;
                        if (indexToToggle >= 0 && indexToToggle < instructions.Length)
                        {
                            var instructionToToggle = instructions[indexToToggle];
                            if (instructionToToggle.Type is InstructionType.Increment or InstructionType.Decrement)
                            {
                                instructionToToggle.Type = instructionToToggle.Type == InstructionType.Increment
                                    ? InstructionType.Decrement
                                    : InstructionType.Increment;
                            }
                            else
                            {
                                instructionToToggle.Type = instructionToToggle.Type == InstructionType.Jump
                                    ? InstructionType.Copy
                                    : InstructionType.Jump;
                            }
                        }

                        index++;
                        break;
                    }
                }
            }
            catch
            {
                index++;
            }
        }

        return registers['a'];
    }

    public int RunPart2(string input, int a, int c)
    {
        var instructions = Parse(input);
        var registers = new Dictionary<char, int>
        {
            ['a'] = a,
            ['b'] = 0,
            ['c'] = c,
            ['d'] = 0
        };
        var index = 0;

        while (index < instructions.Length)
        {
            var s = instructions[index];
            switch (s.Type)
            {
                case InstructionType.Copy:
                {
                    registers[s.CharArg2] = s.HasIntegerArg1
                        ? s.IntegerArg1
                        : registers[s.CharArg1];

                    index++;;
                    break;
                }
                case InstructionType.Increment:
                {
                    registers[s.CharArg1]++;
                    index++;
                    break;
                }
                case InstructionType.Decrement:
                {
                    registers[s.CharArg1]--;
                    index++;;
                    break;
                }
                case InstructionType.Jump:
                {
                    var steps = s.HasIntegerArg2 ? s.IntegerArg2 : registers[s.CharArg2];

                    if (s.HasIntegerArg1)
                        index += s.IntegerArg1 != 0 ? steps : 1;
                    else
                        index += registers[s.CharArg1] != 0 ? steps : 1;
                    break;
                }
                case InstructionType.Toggle:
                {
                    var indexToToggle = index + registers[s.CharArg1];
                    if (indexToToggle >= 0 && indexToToggle < instructions.Length)
                    {
                        var instructionToToggle = instructions[indexToToggle];
                        if (!instructionToToggle.HasTwoArgs)
                        {
                            instructionToToggle.Type = instructionToToggle.Type == InstructionType.Increment
                                ? InstructionType.Decrement
                                : InstructionType.Increment;
                        }
                        else
                        {
                            instructionToToggle.Type = instructionToToggle.Type == InstructionType.Jump
                                ? InstructionType.Copy
                                : InstructionType.Jump;
                        }
                    }

                    index++;
                    break;
                }
            }
        }
        
        return registers['a'];
    }

    private static Instruction[] Parse(string input)
    {
        return input.Split(LineBreaks.Single).Select(o => new Instruction(o)).ToArray();
    }

    private class Instruction
    {
        public InstructionType Type { get; set; }
        public int IntegerArg1 { get; }
        public bool HasIntegerArg1 { get; }
        public int IntegerArg2 { get; }
        public bool HasIntegerArg2 { get; }
        public char CharArg1 { get; }
        public bool HasTwoArgs { get; set; }
        public char CharArg2 { get; }

        public Instruction(string s)
        {
            var parts = s.Split(' ');
            var args = parts.Skip(1).ToList();
            Type = GetType(parts.First());

            if (int.TryParse(args[0], out var intArg1))
            {
                IntegerArg1 = intArg1;
                HasIntegerArg1 = true;
            }
            else
            {
                CharArg1 = args[0][0];
            }

            if (args.Count == 1)
                return;

            HasTwoArgs = true;
            if (int.TryParse(args[1], out var intArg2))
            {
                IntegerArg2 = intArg2;
                HasIntegerArg2 = true;
            }
            else
            {
                CharArg2 = args[1][0];
            }
        }

        private static InstructionType GetType(string name) => name switch
        {
            "cpy" => InstructionType.Copy,
            "inc" => InstructionType.Increment,
            "dec" => InstructionType.Decrement,
            "jnz" => InstructionType.Jump,
            "tgl" => InstructionType.Toggle,
            _ => throw new Exception($"Unknown instruction {name}")
        };
    }

    private enum InstructionType
    {
        Copy,
        Increment,
        Decrement,
        Jump,
        Toggle
    }
}