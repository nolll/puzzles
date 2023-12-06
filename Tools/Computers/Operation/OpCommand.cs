namespace Pzl.Tools.Computers.Operation;

public class OpCommand
{
    public string Operation { get; }
    public long A { get; }
    public long B { get; }
    public long C { get; }

    public OpCommand(string operation, long a, long b, long c)
    {
        Operation = operation;
        A = a;
        B = b;
        C = c;
    }
}