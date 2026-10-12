using Pzl.Common;
using Pzl.Tools.Computers.Operation;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Classification")]
public class Aoc201816 : AocPuzzle
{
    [Puzzle("4f397654d0fda9404b23756deb7529aa")]
    public int Part1(string input)
    {
        var (section1, _) = input.Split(LineBreaks.Triple);
        return new Computer().InputsMatchingThreeOrMore(section1);
    }

    [Puzzle("d1dc18eac2526ddd22d5eb33e4f04011")]
    public long Part2(string input)
    {
        var (section1, section2) = input.Split(LineBreaks.Triple);
        return new Computer().RunTestProgram(section1, section2);
    }

    public class Computer : OpComputer
    {
        public long RunTestProgram(string operationsInput, string programInput)
        {
            var operationNames = GetOperationNameDictionary(operationsInput);
            var commands = programInput.Split(LineBreaks.Single).Where(o => o.Length > 0).Select(s => ParseIntCommand(s, operationNames));
            var registers = new long[] { 0, 0, 0, 0 };
            foreach (var command in commands)
            {
                var operation = OperationsDictionary[command.Operation];
                operation.Execute(registers, command.A, command.B, command.C);
            }
            return registers[0];
        }
        
        private IDictionary<int, string> GetOperationNameDictionary(string input)
        {
            var operationMatches = MapMatchingOperations(input);
            var operations = new Dictionary<int, string>();

            while (operations.Count < OperationsDictionary.Values.Count)
            {
                var singles = operationMatches.Where(o => o.Operations.Count == 1);
                foreach (var match in singles)
                {
                    if (operations.ContainsKey(match.Opcode))
                        continue;
                    
                    var operation = match.Operations.First();
                    operations.Add(match.Opcode, operation.Name);
                    foreach (var m in operationMatches)
                    {
                        m.Operations.Remove(operation);
                    }

                    break;
                }
            }

            return operations;
        }
        
        public int InputsMatchingThreeOrMore(string input) => 
            MapMatchingOperations(input).Count(o => o.Operations.Count >= 3);

        private IList<OperationMatch> MapMatchingOperations(string input)
        {
            var rows = input.Replace([":", "[", "]", ","], "").Split(LineBreaks.Single);
            long[] before = [];
            int[] command = [];
            var matchingOperations = new List<OperationMatch>();
            foreach (var row in rows)
            {
                if (row.StartsWith("Before"))
                {
                    before = row.Replace("Before", "").Trim().Split(' ').Select(long.Parse).ToArray();
                }
                else if (row.StartsWith("After"))
                {
                    var after = row.Replace("After", "").Trim().Split(' ').Select(long.Parse).ToArray();
                    var matches = GetMatchingOperations(before, after, command[1], command[2], command[3]);
                    matchingOperations.Add(new OperationMatch(command[0], matches));
                }
                else if (!string.IsNullOrEmpty(row))
                {
                    command = row.Split(' ').Select(int.Parse).ToArray();
                }
            }

            return matchingOperations;
        }
        
        private static OpCommand ParseIntCommand(string s, IDictionary<int, string> operationNames)
        {
            var parts = s.Split(' ');
            var name = parts.First();
            var values = parts.Skip(1).Select(int.Parse).ToList();
            if (int.TryParse(name, out var id)) 
                name = operationNames[id];

            return new OpCommand(name, values[0], values[1], values[2]);
        }
        
        public IList<Operation> GetMatchingOperations(long[] before, long[] after, long a, long b, long c)
        {
            var matchingOperations = new List<Operation>();
            foreach (var operation in OperationsDictionary.Values)
            {
                var register = new long[4];
                before.CopyTo(register, 0);
                operation.Execute(register, a, b, c);
                if (IsEqual(register, after))
                    matchingOperations.Add(operation);
            }

            return matchingOperations;
        }

        private static bool IsEqual(IReadOnlyList<long> a, IReadOnlyList<long> b)
        {
            if (a.Count != b.Count)
                return false;

            var index = 0;
            while (index < a.Count)
            {
                if (a[index] != b[index])
                    return false;
                index++;
            }
            return true;
        }
    }
}