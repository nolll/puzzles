using Pzl.Common;
using Pzl.Tools.Computers.Operation;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Go With The Flow")]
public class Aoc201819 : AocPuzzle
{
    [Puzzle("890a7c516b44326128b9127982864c47")]
    public long Part1(string input) => new Computer().RunInstructionPointerProgram(input, 0, true);

    [Puzzle("6d3b9449a0d40e62ed9c6b32e16d95e9")]
    public long Part2(string input) => new Computer().RunInstructionPointerProgram(input, 1, true);

    public class Computer : OpComputer
    {
        public long RunInstructionPointerProgram(string programInput, long register0Value, bool useOptimization)
        {
            var inputRows = programInput.Split(LineBreaks.Single);
            var pointerRegister = int.Parse(inputRows.First().Split(' ').Last());
            var commands = inputRows.Skip(1).Select(ParseStringCommand).ToList();
            var registers = new[] { register0Value, 0, 0, 0, 0, 0 };
            var pointer = (int)registers[pointerRegister];
            while (pointer >= 0 && pointer < commands.Count)
            {
                if (useOptimization && pointer == 2)
                {
                    var factors = FindIntFactors(registers[2]).ToList();
                    registers[0] = factors.Sum();
                    break;
                }

                registers[pointerRegister] = pointer;
                var command = commands[pointer];
                var operation = OperationsDictionary[command.Operation];
                operation.Execute(registers, command.A, command.B, command.C);

                pointer = (int)registers[pointerRegister];
                pointer++;
            }

            return registers[0];
        }

        private static IEnumerable<long> FindIntFactors(long target)
        {
            var i = 1;
            while (i <= target)
            {
                if (target % i == 0)
                    yield return i;
                i++;
            }
        }
    }
}