using System.Threading;
using Puzzles.Common.Strings;

namespace Puzzles.Common.Computers.Operation;

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

    public long RunTestProgram(string operationsInput, string programInput)
    {
        var operationNames = GetOperationNameDictionary(operationsInput);
        var commands = StringReader.ReadLines(programInput, false).Select(s => ParseIntCommand(s, operationNames));
        var registers = new long[] { 0, 0, 0, 0 };
        foreach (var command in commands)
        {
            var operation = _operationsDictionary[command.Operation];
            operation.Execute(registers, command.A, command.B, command.C);
        }
        return registers[0];
    }

    public long RunInstructionPointerProgram(string programInput, long register0Value, bool useOptimization, bool debug)
    {
        var inputRows = StringReader.ReadLines(programInput);
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
            var operation = _operationsDictionary[command.Operation];
            operation.Execute(registers, command.A, command.B, command.C);
            if (debug)
            {
                var shortDescription = operation.GetShortDescription(registers, command.A, command.B, command.C);
                var description = operation.GetDescription(registers, command.A, command.B, command.C);
                Console.WriteLine($"{pointer}. {operation.Name}. {description}");
                Console.WriteLine(shortDescription);
                Console.WriteLine(string.Join(',', registers));
                Console.WriteLine();
                Thread.Sleep(500);
            }
            pointer = (int)registers[pointerRegister];
            pointer++;
        }
        return registers[0];
    }

    public long RunSpecialForDay21(string programInput, long register0Value, bool findFirst)
    {
        long lastRegisterZeroValue = 0;
        var registerZeroValues = new HashSet<long>();
        var inputRows = StringReader.ReadLines(programInput);
        var pointerRegister = int.Parse(inputRows.First().Split(' ').Last());
        var commands = inputRows.Skip(1).Select(ParseStringCommand).ToList();
        var registers = new[] { register0Value, 0, 0, 0, 0, 0 };
        var pointer = (int)registers[pointerRegister];
        while (pointer >= 0 && pointer < commands.Count)
        {
            registers[pointerRegister] = pointer;
            var command = commands[pointer];
            var operation = _operationsDictionary[command.Operation];
            if (operation.Name == "eqrr")
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

    private static IEnumerable<long> FindIntFactors(long target)
    {
        var i = 1;
        while (i <= target)
        {
            if(target % i == 0)
                yield return i;
            i++;
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
        var rows = StringReader.ReadLines(input.Replace(":", "").Replace("[", "").Replace("]", "").Replace(",", ""));
        var before = new long[0];
        var command = new int[0];
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

    private OpCommand ParseIntCommand(string s, IDictionary<int, string> operationNames)
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

    private OpCommand ParseStringCommand(string s)
    {
        var parts = s.Split(' ');
        var name = parts.First();
        var values = parts.Skip(1).Select(int.Parse).ToList();

        return new OpCommand(name, values[0], values[1], values[2]);
    }

    public IList<Operation> GetMatchingOperations(long[] before, long[] after, long a, long b, long c)
    {
        var matchingOperations = new List<Operation>();
        foreach (var operation in _operationsDictionary.Values)
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