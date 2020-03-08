using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.OperationComputer
{
    public class OpComputer
    {
        private readonly IDictionary<string, Operation> _operationsDictionary;

        public OpComputer()
        {
            var operations = new List<Operation>
            {
                new AddrOperation(),
                new AddiOperation(),
                new MulrOperation(),
                new MuliOperation(),
                new BanrOperation(),
                new BaniOperation(),
                new BorrOperation(),
                new BoriOperation(),
                new SetrOperation(),
                new SetiOperation(),
                new GtirOperation(),
                new GtriOperation(),
                new GtrrOperation(),
                new EqirOperation(),
                new EqriOperation(),
                new EqrrOperation()
            };

            _operationsDictionary = operations.ToDictionary(o => o.Name);
        }

        public int RunTestProgram(string operationsInput, string programInput)
        {
            var operationNames = GetOperationNameDictionary(operationsInput);
            var commands = PuzzleInputReader.Read(programInput).Select(s => ParseCommand(s, operationNames));
            var registers = new[] { 0, 0, 0, 0 };
            foreach (var command in commands)
            {
                var operation = _operationsDictionary[command.Operation];
                registers = operation.Execute(registers, command.A, command.B, command.C);
            }
            return registers[0];
        }

        public class OpCommand
        {
            public string Operation { get; }
            public int A { get; }
            public int B { get; }
            public int C { get; }

            public OpCommand(string operation, int a, int b, int c)
            {
                Operation = operation;
                A = a;
                B = b;
                C = c;
            }
        }

        private IDictionary<int, string> GetOperationNameDictionary(string input)
        {
            var operationMatches = MapMatchingOperations(input);
            var operations = new Dictionary<int, string>();

            while (operations.Count < _operationsDictionary.Values.Count)
            {
                var singles = operationMatches.Where(o => o.Operations.Count == 1);
                foreach (var match in singles)
                {
                    if (!operations.ContainsKey(match.Opcode))
                    {
                        var operation = match.Operations.First();
                        operations.Add(match.Opcode, operation.Name);
                        foreach (var m in operationMatches)
                        {
                            m.Operations.Remove(operation);
                        }

                        break;
                    }
                }
            }

            return operations;
        }

        public int InputsMatchingThreeOrMore(string input)
        {
            var matchingOperations = MapMatchingOperations(input);
            return matchingOperations.Count(o => o.Operations.Count >= 3);
        }

        private IList<OperationMatch> MapMatchingOperations(string input)
        {
            var rows = PuzzleInputReader.Read(input.Replace(":", "").Replace("[", "").Replace("]", "").Replace(",", ""));
            var before = new int[0];
            var command = new int[0];
            var matchingOperations = new List<OperationMatch>();
            foreach (var row in rows)
            {
                if (row.StartsWith("Before"))
                {
                    before = row.Replace("Before", "").Trim().Split(' ').Select(int.Parse).ToArray();
                }
                else if (row.StartsWith("After"))
                {
                    var after = row.Replace("After", "").Trim().Split(' ').Select(int.Parse).ToArray();
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

        private OpCommand ParseCommand(string s, IDictionary<int, string> operationNames)
        {
            var parts = s.Split(' ');
            var name = parts.First();
            var values = parts.Skip(1).Select(int.Parse).ToList();
            if (int.TryParse(name, out var id))
            {
                name = operationNames[id];
            }

            return new OpCommand(name, values[0], values[1], values[2]);
        }

        public IList<Operation> GetMatchingOperations(int[] before, int[] after, int a, int b, int c)
        {
            var matchingOperations = new List<Operation>();
            foreach (var operation in _operationsDictionary.Values)
            {
                var register = new int[4];
                before.CopyTo(register, 0);
                var result = operation.Execute(register, a, b, c);
                if (IsEqual(result, after))
                    matchingOperations.Add(operation);
            }

            return matchingOperations;
        }

        private static bool IsEqual(IReadOnlyList<int> a, IReadOnlyList<int> b)
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