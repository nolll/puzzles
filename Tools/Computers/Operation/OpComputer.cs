using System.Threading;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Computers.Operation;

public class OpComputer
{
    protected readonly IDictionary<string, Operation> _operationsDictionary;

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

    public long RunInstructionPointerProgram(string programInput, long register0Value, bool useOptimization, bool debug)
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

    protected OpCommand ParseStringCommand(string s)
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