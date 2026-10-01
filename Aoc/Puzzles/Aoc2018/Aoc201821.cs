using Pzl.Common;
using Pzl.Tools.Computers.Operation;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[IsSlow] // 18s for part 2
[Name("Chronal Conversion")]
[Comment("OpComputer")]
public class Aoc201821 : AocPuzzle
{
    [Puzzle("cbaac5c05e7a649e9d578813a7d96c60")]
    public long Part1(string input) => new Computer().Run(input, 0, true);

    [Puzzle("ea87eb4b91f7e0c9373c7ce75f369320")]
    public long Part2(string input) => new Computer().Run(input, 0, false);

    private class Computer : OpComputer
    {
        public long Run(string programInput, long register0Value, bool findFirst)
        {
            long lastRegisterZeroValue = 0;
            var registerZeroValues = new HashSet<long>();
            var inputRows = programInput.Split(LineBreaks.Single);
            var pointerRegister = int.Parse(inputRows.First().Split(' ').Last());
            var commands = inputRows.Skip(1).Select(ParseStringCommand).ToList();
            var registers = new[] { register0Value, 0, 0, 0, 0, 0 };
            var pointer = (int)registers[pointerRegister];
            while (pointer >= 0 && pointer < commands.Count)
            {
                registers[pointerRegister] = pointer;
                var command = commands[pointer];
                var operation = _operationsDictionary[command.Operation];
                if (operation.Type == OperationType.Eqrr)
                {
                    var v = registers[command.A];
                    if (findFirst && !registerZeroValues.Any())
                        return v;
                    if (registerZeroValues.Contains(v))
                        return lastRegisterZeroValue;
                    lastRegisterZeroValue = v;
                    registerZeroValues.Add(v);
                }
                operation.Execute(registers, command.A, command.B, command.C);
                pointer = (int)registers[pointerRegister];
                pointer++;
            }
            return 0;
        }
    }
}