namespace Pzl.Tools.Computers.Operation;

public class OpComputer
{
    protected readonly IDictionary<string, Operation> OperationsDictionary;

    public OpComputer()
    {
        OperationsDictionary = GetOperations().ToDictionary(o => o.Name);
    }

    private static List<Operation> GetOperations() =>
    [
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
    ];

    protected OpCommand ParseStringCommand(string s)
    {
        var parts = s.Split(' ');
        var name = parts.First();
        var values = parts.Skip(1).Select(int.Parse).ToList();

        return new OpCommand(name, values[0], values[1], values[2]);
    }
}