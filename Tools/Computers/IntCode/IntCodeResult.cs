namespace Pzl.Tools.Computers.IntCode;

public class IntCodeResult
{
    private readonly int[] _memory;

    public string Output => string.Join(',', _memory.Select(o => o.ToString()));
    public int Integer => _memory[0];

    public IntCodeResult(int[] memory)
    {
        _memory = memory;
    }
}